using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

namespace Kursovaya
{
    public partial class Auth : Form
    {
        int AuthAtt = 0;
        
        public Auth()
        {
            InitializeComponent();
            TestDataBaseConn();
        }
        string ConnStr = ConnectionString.GetConnectionString();
        bool inCaptcha = false;
        private void LogInButton_Click(object sender, EventArgs e)
        {
            getUserID();
            if (AuthAtt >= 1 && !inCaptcha)
            {
                this.Height = 530;
                inCaptcha = true;
            }
            if (inCaptcha)
            {
                if(CaptchaTextBox.Text.Trim() == captchaAnewer)
                {
                    inCaptcha = false;
                    CheckUser();
                    this.Height = 350;
                }
                else
                {
                    MessageBox.Show("Капча введена не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Captcha(); loginTextBox.Text = "";
                    pwdTextBox.Text = "";
                }
            }
            else
            {
                if (loginTextBox.Text.Length > 3 && pwdTextBox.Text.Length > 3) // Проверка длинны пароля
                {
                    CheckUser();
                }
                else
                {
                    MessageBox.Show("Логин или пароль слишком короткие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    loginTextBox.Text = "";
                    pwdTextBox.Text = "";
                }
            }
        }
        private void getUserID()
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT id from staff where login = '{loginTextBox.Text.Trim()}';", conn);
                int user_id = Convert.ToInt32(cmd.ExecuteScalar());
                user.Default.userID = user_id;
                //MessageBox.Show($"{user_id}");
            }
        } 
        private void CheckUser()
        {
            string query = $"SELECT password FROM staff WHERE login = '{loginTextBox.Text.Trim()}';";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object pwd_db = cmd.ExecuteScalar();
                    if (pwd_db == null)
                    {
                        MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        AuthAtt++; loginTextBox.Text = "";
                        pwdTextBox.Text = "";
                        Captcha();
                        this.Height = 530;
                    }
                    else
                    {
                        string actual_pwd = GetHashPwd(pwdTextBox.Text);
                        if (pwd_db.ToString() == actual_pwd)
                        {
                            int role = GetUserRole();
                            if(role == 1)
                            {
                                // новая форма меню юзера
                                getUserID();
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                User.UserMenu menu = new User.UserMenu();
                                Hide();
                                menu.ShowDialog();
                                Show();
                                loginTextBox.Text = "";
                                pwdTextBox.Text = "";
                            }
                            else if(role == 2)
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                ProdExpert.ExpertMenu menu = new ProdExpert.ExpertMenu();
                                Hide();
                                menu.ShowDialog();
                                Show();
                                loginTextBox.Text = "";
                                pwdTextBox.Text = "";
                            }
                            else if(role == 3)
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Administrator.AdminMenu menu = new Administrator.AdminMenu();
                                Hide();
                                menu.ShowDialog();
                                Show();
                                loginTextBox.Text = "";
                                pwdTextBox.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            loginTextBox.Text = "";
                            pwdTextBox.Text = "";
                            AuthAtt++;
                            this.Height = 530;
                            Captcha();
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = "";}
        }



        private string GetHashPwd(string pwd)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }



        int captchaId = 4;
        int i = 0;
        string captchaAnewer = "";
        private void Captcha()
        {            
            Random r = new Random();
            captchaId = r.Next(1, 4);
            while (true)
            {
                if (captchaId == i)
                {
                    captchaId = r.Next(1, 4);
                }
                else
                {
                    break;
                }
            }            
            i = captchaId;
            if (captchaId == 1)
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/1.png");
                captchaAnewer = "hP%4";
            }
            else if (captchaId == 2)
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/2.png");
                captchaAnewer = "%9RR";
            }
            else if (captchaId == 3)
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/3.png");
                captchaAnewer = "52$V";
            }
        }

        private void ReCaptcha_Click(object sender, EventArgs e)
        {
            Captcha();
        }


        private int GetUserRole()
        {
            string query = $"SELECT role FROM staff WHERE login = '{loginTextBox.Text.Trim()}';";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmd.ExecuteScalar() == null)
                    {
                        
                    }
                    else
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }                
            }
            catch (Exception EX)
            {
                MessageBox.Show($"{EX.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = "";
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginTextBox.Text = "petr";
            pwdTextBox.Text = "password";
        }

        private void TestDataBaseConn()
        {            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    EditConn ed = new EditConn();
                    ed.ShowDialog();
                }
            }
                
        }

        private void connedit_Click(object sender, EventArgs e)
        {
            EditConn ec = new EditConn();
            ec.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginTextBox.Text = "ivan";
            pwdTextBox.Text = "ivan";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginTextBox.Text = "anton";
            pwdTextBox.Text = "anton";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
