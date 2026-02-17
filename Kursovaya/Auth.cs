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

// ФОРМА Авторизации

namespace Kursovaya
{
    public partial class Auth : Form
    {
        int AuthAtt = 0; // количество попыток входа

        public Auth()
        {
            InitializeComponent();
            TestDataBaseConn();
            pwdTextBox.UseSystemPasswordChar = true; // скрываем пароль
        }
        string ConnStr = ConnectionString.GetConnectionString(); // строка подключения к БД
        bool inCaptcha = false; // булева должен ли пользователь ввести капчу для входа
        // обработчик на надатие кнопки "Войти"
        private void LogInButton_Click(object sender, EventArgs e)
        {
            getUserID(); // получаем айди пользователя по введённым данным
            if (AuthAtt >= 1 && !inCaptcha) // если была не успешная попытка входа то при слудующем нужно ввести капчу
            {
                this.Height = 530; // расширяем окно чтобы показать капчу
                inCaptcha = true; // булева должен ли пользователь ввести капчу для входа
            }
            if (inCaptcha) // если нужно решение капчи
            {
                if(CaptchaTextBox.Text.Trim() == captchaAnewer) // проверяем корректность капчи
                {
                    inCaptcha = false; 
                    CheckUser(); // проверяем пользователя
                    this.Height = 350; // уменьшаем форму если капча решена правильно
                }
                else
                {
                    MessageBox.Show("Капча введена не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                    Captcha(); loginTextBox.Text = ""; // генерируем новую капчу и затираем введённые данные для входа
                    pwdTextBox.Text = "";
                }
            }
            else 
            {
                if (loginTextBox.Text.Length > 3 && pwdTextBox.Text.Length > 3) // Проверка длинны пароля
                {
                    CheckUser(); // проверяем пользователя
                }
                else
                {
                    MessageBox.Show("Логин или пароль слишком короткие!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                    loginTextBox.Text = ""; // затираем введённые данные для входа
                    pwdTextBox.Text = "";
                }
            }
        }
        private void getUserID() // получение айди пользователя
        {
            using (MySqlConnection conn = new MySqlConnection(ConnStr)) // инициируем подключение 
            {
                conn.Open(); // открываем подключение
                MySqlCommand cmd = new MySqlCommand($"SELECT id from staff where login = '{loginTextBox.Text.Trim()}';", conn); // выполняем запрос
                int user_id = Convert.ToInt32(cmd.ExecuteScalar()); // получаем ответ и записываем его в переменную
                user.Default.userID = user_id; // сохраняем айди для дальнейшей работы 
            }
        } 
        private void CheckUser() // функция проверки пользователя
        {
            string query = $"SELECT password FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос для получения хэш пароля по логину
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr)) // инициируем подключение 
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand(query, conn); // выполняем запрос
                    object pwd_db = cmd.ExecuteScalar(); // записываем в переменную
                    if (pwd_db == null)  // проверяем что хэш пароль не пустой
                    {
                        MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомление
                        AuthAtt++; loginTextBox.Text = "";  // засчитываем попытку входа и затираем данные для входа
                        pwdTextBox.Text = "";
                        Captcha();  // отображаем капчу
                        this.Height = 530; // расширяем форму для отображения капчи
                    }
                    else
                    {
                        string actual_pwd = GetHashPwd(pwdTextBox.Text);  // вычисляем хэш пароль из того пароля которы ввёл пользователь
                        if (pwd_db.ToString() == actual_pwd)  // сравниваем хэш от того пароля сто ввёл пользователь с тем что хранится в БД
                        {
                            int role = GetUserRole();  // плучаем роль пользователя
                            if (role == 1) // если пользователь имеет роль "Пользователь"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                User.UserMenu menu = new User.UserMenu(); // создаём экземпляр класса меню пользователя
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog(); // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                            else if(role == 2) // если пользователь имеет роль "Товаровед"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                ProdExpert.ExpertMenu menu = new ProdExpert.ExpertMenu(); // создаём экземпляр класса меню товароведа
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog(); // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                            else if(role == 3) // если пользователь имеет роль "Администратор"
                            {
                                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                                Administrator.AdminMenu menu = new Administrator.AdminMenu(); // создаём экземпляр класса меню администратора
                                Hide(); // скрываем форму авторизации
                                menu.ShowDialog();  // отображаем меню
                                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                                loginTextBox.Text = ""; // затираем данные для входа
                                pwdTextBox.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль введены не верно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // уведомляем о неверных данных для входа
                            loginTextBox.Text = ""; // затираем данные для входа
                            pwdTextBox.Text = "";
                            AuthAtt++; // засчитываем попытку входа
                            this.Height = 530; // расширяем форму для отображения капчи
                            Captcha();  // отображаем капчу
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"{ex.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = "";} // обработка ошибок
        }



        private string GetHashPwd(string pwd) // функция принимает строку пароль вычисляет и возвращает хэш строку 
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd); // получаем массив байтов
                byte[] hash = sha256.ComputeHash(bytes); // получаем байтовый массив хэша

                StringBuilder result = new StringBuilder(); // собираем байты в строку
                foreach (byte b in hash) // перебираме все байты
                {
                    result.Append(b.ToString("x2")); // записываем в строку
                }
                return result.ToString(); // возвращаем хэш строку
            }
        }



        int captchaId = 4; // айди капчи которая отобразится
        int i = 0;  // дополнительная временная переменная для хранения айди капчи
        string captchaAnewer = ""; // строка хранения ответа на капчу
        private void Captcha()  // отображение капчи
        {            
            Random r = new Random(); // экземпляр класса рандома
            captchaId = r.Next(1, 4); // генерируем айди 
            while (true) // цикл генерации чтобы капча не повторялась
            {
                if (captchaId == i)
                {
                    captchaId = r.Next(1, 4); // генерируем айди 
                }
                else
                {
                    break;
                }
            }            
            i = captchaId; // сохраняем новый айди капчи 
            if (captchaId == 1) // если айди капчи 1 то отображаем изображение 1
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/1.png"); // отображаем изображение
                captchaAnewer = "hP%4"; // ответ на капчу
            }
            else if (captchaId == 2) // если айди капчи 2 то отображаем изображение 2
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/2.png"); // отображаем изображение
                captchaAnewer = "%9RR"; // ответ на капчу
            }
            else if (captchaId == 3) // если айди капчи 3 то отображаем изображение 3
            {
                CaptcaImg.Image = Image.FromFile("captchaImg/3.png"); // отображаем изображение
                captchaAnewer = "52$V"; // ответ на капчу
            }
        }

        private void ReCaptcha_Click(object sender, EventArgs e) // обработчик кнопки перегенерации капчи
        {
            Captcha();
        }


        private int GetUserRole() // функция получения роли пользователя
        {
            string query = $"SELECT role FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr)) // подключение
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand(query, conn); // выполняем запрос
                    if (cmd.ExecuteScalar() == null) // если роль отсутствует пропускаем
                    {
                        
                    }
                    else
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar()); // если роль есть то возвращаем её айди
                    }
                }                
            }
            catch (Exception EX) // обработка ошибок
            {
                MessageBox.Show($"{EX.Message}"); loginTextBox.Text = "";
                pwdTextBox.Text = ""; // перезатираем введённые данные
            }
            return 0; // если ранее ничего не вернули возвращаем 0
        }

        private void button1_Click(object sender, EventArgs e) // перед защитой будет удалено
        {
            loginTextBox.Text = "petr";
            pwdTextBox.Text = "password";
        }

        private void TestDataBaseConn() // проверка подключения к БД
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

        private void ShowPwdButton_Click(object sender, EventArgs e) // отображаем или скрываем пароль
        {
            pwdTextBox.UseSystemPasswordChar = !pwdTextBox.UseSystemPasswordChar;
        }
    }
}
