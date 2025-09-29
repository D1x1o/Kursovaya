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
        string ConnStr = ConnectionString.GetConnectionString();
        public Auth()
        {
            InitializeComponent();
            //this.Height = 350;
        }
        bool inCaptcha = false;
        private void LogInButton_Click(object sender, EventArgs e)
        {
            
            if (AuthAtt >= 1 && !inCaptcha)
            {
                this.Height = 530;
                Captcha();
                inCaptcha = true;
            }
            if (inCaptcha)
            {
                if(CaptchaTextBox.Text.Trim() == captchaAnewer)
                {
                    CheckUser();
                    this.Height = 350;
                }
                else
                {
                    MessageBox.Show("Капча введена не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Captcha();
                }
            }




            if(loginTextBox.Text.Length > 3 && pwdTextBox.Text.Length > 3) // Проверка длинны пароля
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
                        MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    }
                    else
                    {
                        string actual_pwd = GetHashPwd(pwdTextBox.Text);
                        if (pwd_db.ToString() == actual_pwd)
                        {
                            // новая форма меню
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            loginTextBox.Text = "";
                            pwdTextBox.Text = "";
                            AuthAtt++;                           
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = "";
            }
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
    }
}
