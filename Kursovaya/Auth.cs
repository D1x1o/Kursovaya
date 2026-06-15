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
        private Timer blockTimer = new Timer();
        private int blockSeconds = 10;
        public Auth()
        {
            InitializeComponent();
            TestDataBaseConn();
            EnsurePepeShopJson();
            pwdTextBox.UseSystemPasswordChar = true; // скрываем пароль
            CopyDefaultImagesToAppData(); // метод копирования изображений
            blockTimer.Interval = 1000; // 1 секунда            
            blockTimer.Tick += BlockTimer_Tick;
        }
        public static string EnsurePepeShopJson()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(appDataPath, "pepeShop");
            string filePath = Path.Combine(folderPath, "tables.json");

            // создаём папку, если нет
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // создаём json файл, если нет
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "{}");
            }

            return filePath;
        }
        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            blockSeconds--;

            LogInButton.Text = $"Подождите {blockSeconds} сек.";

            if (blockSeconds <= 0)
            {
                blockTimer.Stop();

                LogInButton.Enabled = true;
                LogInButton.Text = "Войти";

                blockSeconds = 10;
            }
        }
        void CopyDefaultImagesToAppData() // метод копирования изображений по умолчанию из папки приложения в папку appdata
        {
            try // блок обработки исключений
            {
                // формирование пути к папке с изображениями в директории запуска приложения
                string exeImgFolder = Path.Combine(Application.StartupPath, "img");

                // формирование пути к папке для сохранения изображений в папке appdata пользователя
                string appDataImgFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), // получение пути к appdata
                    "pepeShop", // папка приложения в appdata
                    "img" // подпапка для изображений
                );

                // создание директории в appdata, если она не существует (включая все вложенные папки)
                Directory.CreateDirectory(appDataImgFolder);

                // массив имен файлов, которые нужно скопировать
                string[] filesToCopy = { "no-image.png", "gigabyte3060.png",
                    "02182b27-94b5-49a5-b08d-6817143dc2e3.png",
"02401176-4f13-4e6a-ab12-437201b53ebc.png",
"02a8030f-db38-4348-9009-df990cf81d3a.jpg",
"02ad5e7e-a471-46ad-93dc-79940c15007e.jpg",
"02d79836-baf2-42fa-95bc-5de45663c168.jpg",
"02df6ee0-2bec-4a14-bb99-1e58936300f6.png",
"06cf694c-04f7-4f05-8fd4-602742ac0ac4.jpg",
"07e3afa1-0d13-4c59-a8c6-1c9bee1ab9ad.jpg",
"088e008b-e1c4-4ab8-9aad-937b1194c38e.png",
"09c530d3-8c50-4568-9d1a-f28366023a2d.jpg",
"0abf3f3e-c702-4d74-86a9-47a66aab3816.jpg",
"0c762237-0f96-4a73-8bea-c4c5bba12ba1.jpg",
"0cb40683-abea-4617-80e2-25d64ec738f4.jpg",
"0d0fcc7c-6728-4cb4-8b2b-6427646b4fc3.jpg",
"0d3f0315-5436-4c08-b8e1-2684ca859488.jpg",
"0e641764-e1c5-46a5-9702-b4eededa248f.jpg",
"12c93530-5568-4ce4-8329-2ff66cedb880.png",
"13d8baba-6439-45dd-b862-10b5eaa25b7e.jpg",
"17e29c15-acdb-4489-a231-cae8a9979701.jpg",
"17fa9a5a-8898-4330-af83-5520427a9e6c.jpg",
"1908b75a-bbe5-4387-bf28-5071c9f24bcd.jpg",
"1d6f933f-364b-40c3-a1bb-92d1bf6096a1.jpg",
"1d727ac2-7efd-47a7-a44e-a45598653b6b.jpg",
"1f5ac2fa-c331-4d1a-9d00-906fb7dd1f82.jpg",
"1f84ac08-8623-41ed-b86a-3359e8ab9634.jpg",
"2155dfff-f347-4553-b4fd-029d90cac0cb.jpg",
"242441d1-4d25-44fa-824a-182af6302eee.jpg",
"2495fc99-dbbb-4f89-80cc-b6734c9a186f.jpg",
"27438a53-821d-4d03-b0d0-bbbe3c8e4cbf.png",
"2b01da6d-5226-4bd0-8c4a-6d42c9f6e1a1.jpg",
"2ba28e76-104d-4384-a141-858be5b1c602.png",
"2d0b1a85-5f92-46b0-a3cd-cee4a375c187.jpg",
"2e7bae5c-1213-46fc-9a99-f7f12103db84.jpg",
"2ee93c78-6b17-4690-8f39-c0e506cc91f8.png",
"304d6f7d-cd40-4272-8045-fcf11b0108cc.jpg",
"30b636d4-867f-43cd-b2a3-64a545884287.jpg",
"32f2c0bf-00a7-4858-a70c-ebfdb6f8562d.jpg",
"379baaa2-a723-4aa7-ab5f-2a66f3dd654b.jpg",
"39244606-5bc6-43cc-aad0-ceb776b7c66d.jpg",
"3925d384-54b4-4b5d-a449-615912397b70.jpg",
"3986206c-f64a-486e-9849-d30c31e6fb70.png",
"3ab755f0-c3fd-4d1c-abce-e6d00c4739ae.png",
"3e567ee9-a23b-466a-ae49-56643fa86577.jpg",
"406a9896-b8f2-4eeb-bbd6-eeb64edbf7af.jpg",
"40ca8ea8-585a-4d0a-907b-39054ff587c5.jpg",
"412d6e33-8bdd-4329-88e0-a613b4291d63.png",
"41cda25b-a5f5-467f-833b-2c66375446ff.jpg",
"4350e5b5-8902-47fa-8fb4-6f2af3cec10a.jpg",
"440b4e41-591a-4e63-bdbe-3d2f9bf8e634.jpg",
"459a1607-b388-46f8-afbe-5c2b6727a594.jpg",
"472c2e56-cb34-41cf-94a9-53665b114bf2.jpg",
"48f4022f-5a3a-4199-a4be-8c04b2e5517d.jpg",
"49915d24-26fd-4114-beee-2c2474514f6e.jpg",
"4a0cd561-f177-48c5-b3f9-8ba05723bc28.png",
"4c895d41-9553-43a5-acda-8e20fd34fd9b.jpg",
"4d189d0a-86d8-4b05-8d03-1aa54a53b332.jpg",
"4dc6ce29-1a73-460b-819f-2af8527e59c7.png",
"4dff63f4-dc16-462b-8d9c-d672f37688bb.jpg",
"4f7d2e2b-9c7d-4005-9da6-36bb45510787.jpg",
"500e4814-3c7a-4402-ae03-3ad2c03d9aa1.jpg",
"51f138a0-c006-4274-af8b-6201da9af41a.png",
"523c5ec4-9bd7-42c5-8586-66a406124dec.jpg",
"534275bc-460f-4c38-8fb0-b422ca22ede9.png",
"534f77c2-00f8-476e-9f59-1ebcad527d7e.jpg",
"54d6762d-a433-40aa-93bb-9fcf0ae09b2b.jpg",
"56af6399-f189-44b9-93ee-41e5f6b5bc6a.jpg",
"573ae400-7f90-4c15-bfc4-114ea4a4333d.jpg",
"580803ea-f297-4d8e-ba7d-12d958aa692e.png",
"590c86aa-9e78-4044-a768-c214a9e1313f.jpg",
"59bef808-9c5f-4b4a-b259-bcf71f4e47d2.jpg",
"5b8df801-8b0a-4ca8-8b54-3336f85d4bd0.jpg",
"5c952f17-30ea-4366-94f9-cc647f22d518.jpg",
"5e255c7c-16ac-46cb-8672-33fd29bb6ab9.jpg",
"5eaf4207-a000-418c-9733-21065319d576.png",
"5f1a8e9a-3cc8-4408-872c-4b832ba8ede9.png",
"61349a7b-e55c-4232-b12f-f50fdd630f9c.jpg",
"61f21e7e-9d6a-4d8e-8f46-0d93edf6b49a.jpg",
"62308db8-439e-443d-9b8e-683111adeb62.jpg",
"629e3bc5-123a-4a95-8e1b-76db2ae7a2a9.jpg",
"6754713f-1d1b-4474-9359-3c2fc2a634bc.png",
"6964d822-8a65-4ec2-bf66-c8c16c31e81e.jpg",
"6cee49d7-be23-4d63-9cc2-9e2b30d67385.jpg",
"6e5e17ea-13ed-4dc8-b80f-5ff2d947afc9.jpg",
"703f4990-96e2-4865-a0ad-6ebef0335a73.jpg",
"7046505c-3e53-4b23-924f-eb8105385f89.png",
"741281f1-9b4c-4c2e-8cae-2de95b4fa63f.png",
"7693f528-85ef-4695-bf85-9d6d124dfdc4.jpg",
"7763d6ec-c31d-42eb-ba65-558ba24c6e89.jpg",
"799471bb-94c8-4132-af49-a36489ee4004.jpg",
"7a487d98-01e6-4a82-b17f-4045b6958b9a.jpg",
"7ac75326-0aeb-4e77-8e13-1205a4d07051.png",
"7cc35a1e-cd84-4e95-98a9-aa53078e2b4e.jpg",
"7ed31d0e-2c6b-4063-b1be-3aaeb8ba0c19.jpg",
"7f06306d-7a20-46d1-9004-90a00d0b6e02.jpg",
"7f0cb99d-e124-4c4e-80a4-9c0023635485.png",
"80b7ff1e-9dbd-47d3-bc67-7319cf7a3b41.jpg",
"8211e643-61d6-458d-9f5e-46440e98301a.png",
"829a2e59-dd86-46c9-a5ff-b04905cd34c4.jpg",
"83e59933-66c8-43f8-b488-d91eef6852d6.jpg",
"85e357b9-157b-4696-92ad-c208f5b99730.jpg",
"8905300e-64cc-4374-af9d-c2bf2964d31e.jpg",
"890cd3e9-56b8-4cd3-8001-af448b89963c.jpg",
"899b404a-7177-4e17-aace-b9170cfe2497.png",
"8a3abba4-94bd-47fe-9944-26817db332e5.jpg",
"8a9f0689-807d-498b-bbd9-4438630a9e92.jpg",
"8c783181-03d1-48fe-aae2-eb04223cdec7.jpg",
"8d3751dc-e177-40cf-b8ba-e1693a5670c3.jpg",
"8dec5fc5-f5e8-496c-981b-3d738d6a0bf2.jpg",
"8e8199a6-5e9a-451b-b097-2efe0eb81be5.jpg",
"8f35f067-aa17-4053-b7c9-d6f83c934b00.png",
"8fbef24c-36c4-48ae-9a4a-8c0a8ff5e16d.jpg",
"909e44ab-5166-4769-97de-25dd86b2e077.jpg",
"9173236d-29ea-4aec-a7d2-3d599735653c.jpg",
"925a2ba2-3a13-424f-ab5e-f399870f4608.jpg",
"9386ac50-849e-46d9-8c06-f3decf86b938.png",
"94ac72fe-6f21-42f5-ac87-f38c39e8997f.jpg",
"94cbb010-47d3-4714-b3f3-747ad637294f.jpg",
"95ebaa2b-cd7d-4465-a93d-ed69b61a3198.jpg",
"96f9e68d-3394-40c9-90bc-9ef46b39b326.png",
"9858efa3-e6ac-4294-be7c-e42d71bf4919.jpg",
"9ba5561c-9b44-44c1-a114-0d41acf45dcb.jpg",
"9d38d4ef-dd40-4e40-835a-40cbc903929f.jpg",
"a0579f8d-c6f1-49b0-8c69-1daedfb74731.jpg",
"a26f3f8a-ed68-47ae-9a93-7c01cc083948.jpg",
"a300c7cc-043f-4f73-ba89-f3ea0e69533c.jpg",
"a72634f3-1bee-4f0b-b67d-d6b9a5527592.jpg",
"a76bb4c5-49b9-4e8b-90c1-32b0cd601615.jpg",
"a92e6774-97db-482a-975c-0227928c3341.jpg",
"a96b10e1-a90e-4392-b60f-d01d1c3d319e.jpg",
"a9aac13f-dde8-4441-b181-9e03c9ee159d.jpg",
"aa36bacb-7483-4866-9790-700c626bfce1.jpg",
"aaa19b17-f643-41c4-8419-7e38ed3abc85.jpg",
"acebd105-25d3-49b2-8583-83cc6befa820.jpg",
"ad66a25b-4082-4621-9c73-78a69d90ca60.jpg",
"b46f82d3-611e-4f88-b58a-4986c8fb8ccf.png",
"b7e07d60-e5eb-4829-9213-638b65f3cf82.png",
"b8d76109-2f13-4223-a7bb-1f584cd4ca0d.jpg",
"bc9af00d-ad59-46e1-b289-c0df1ea832b3.jpg",
"bdb8e04f-56d5-4b3e-aee7-9818b5b88ca5.jpg",
"bea24d4e-5c66-4c0e-af33-29018e93156d.jpg",
"bf4121d7-f881-4a35-bc39-263ba0e8afb5.jpg",
"bf845aa1-4496-461d-b666-70e20ec1abb2.jpg",
"c0e64589-1138-4a20-af03-428a952a5d1d.jpg",
"c19e0748-8c6d-43ab-90fb-ccfe3a1592ec.png",
"c4471513-5549-4b07-bb03-2345039cb82d.jpg",
"c8ec1ad8-9dcb-4364-a854-4e0d2d054422.jpg",
"c9a7ad41-6e37-428d-ab95-82edb3355664.jpg",
"cdcc6e4e-7d78-4cf4-814d-9af6668782c1.png",
"d0caa1f2-773b-4dea-9d70-6c43de25385a.png",
"d2e45ac5-f929-4413-ad8e-392ab24604b7.jpg",
"d2e671f3-a6d2-4b57-835d-879b5b1a389c.jpg",
"d30fccbf-a111-417a-8b61-bb9ce195a2b1.jpg",
"d589cd75-4ed2-43a9-92bc-184cccd2db3b.jpg",
"d6b095e6-61dc-4294-a661-0dfe245ef11a.jpg",
"d6ff09fa-8760-4572-bcfe-935153e213a6.jpg",
"d74f4eed-8017-4421-a483-69c766e53f36.jpg",
"d81503ae-d504-49ea-ba6e-ef4d331ef8d3.jpg",
"dadf0cb6-4f57-4441-94c9-36a7346a4de8.png",
"de20b06d-467f-4fa4-90c7-0948c65e9d9e.jpg",
"e0f437bc-d53e-44ec-a217-25406c3e8eaf.jpg",
"e1a527f3-e719-4435-ad6d-38d13d444184.jpg",
"e20954f8-3797-4dfe-b0b9-7d083e762f98.jpg",
"e2a1d884-8f75-476a-a4c5-230de20614ea.png",
"e921354c-61ea-40ba-8449-f9755c18b3d4.jpg",
"ec29b98b-41ae-41c8-aa9d-e65503bbf030.jpg",
"ee7ef93b-d408-4eee-b1ba-b58bc8065bbc.jpg",
"ee97d7a5-1553-4ef2-988f-412bf253c203.jpg",
"efa2fb31-1785-4b88-8557-227b02f6936f.jpg",
"f08a7714-e183-473b-bb99-2f92634d47b2.jpg",
"f18111cc-bdce-4ecc-98e3-22c65ef9fa31.jpg",
"f1a10640-8233-405f-985e-635ee6a907f0.jpg",
"f3fb4b5a-c51e-4773-bf5f-bb2ca349a1ce.jpg",
"f5decd06-0a31-4b96-9628-3accb918ad0b.png",
"f72efe79-26e6-4c1c-aaae-66775fb7ece3.jpg",
"f7bcce50-2919-4530-ac6e-ba5e0061a72e.png",
"f8e16a87-fe55-41d8-b733-707f73801fb5.jpg",
"fdf1800b-179e-40d7-99b1-52ee69544e0f.jpg"};

                // перебор всех файлов из массива
                foreach (string fileName in filesToCopy)
                {
                    // полный путь к исходному файлу в папке приложения
                    string sourcePath = Path.Combine(exeImgFolder, fileName);

                    // полный путь к целевому файлу в папке appdata
                    string destPath = Path.Combine(appDataImgFolder, fileName);

                    // проверка: существует ли исходный файл и нет ли уже такого файла в appdata
                    if (File.Exists(sourcePath) && !File.Exists(destPath))
                    {
                        // копирование файла из папки приложения в папку appdata
                        File.Copy(sourcePath, destPath);
                    }
                }
            }
            catch (Exception e) // перехват любого исключения
            {
                MessageBox.Show(e.Message); // вывод сообщения об ошибке пользователю
            }
        }
        bool inCaptcha = false; // булева должен ли пользователь ввести капчу для входа
        // обработчик на надатие кнопки "Войти"
        private void LogInButton_Click(object sender, EventArgs e)
        {
            if (loginTextBox.Text == "admin" && pwdTextBox.Text == "admin") // проверка на "вшитого админа"
            {
                MessageBox.Show("Вход выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // уведомляем о успешном входе
                Administrator.AdminMenu menu = new Administrator.AdminMenu(); // создаём экземпляр класса меню администратора
                Hide(); // скрываем форму авторизации
                menu.ShowDialog();  // отображаем меню
                Show(); // когда пользователь закроет меню отобразится форма авторизации 
                loginTextBox.Text = ""; // затираем данные для входа
                pwdTextBox.Text = "";
            }
            getUserID(); // получаем айди пользователя по введённым данным
            if (AuthAtt >= 1 && !inCaptcha) // если была не успешная попытка входа то при слудующем нужно ввести капчу
            {
                this.Height = 530; // расширяем окно чтобы показать капчу
                inCaptcha = true; // булева должен ли пользователь ввести капчу для входа
            }
            if (inCaptcha) // если нужно решение капчи
            {
                if (CaptchaTextBox.Text.Trim() == captchaAnewer) // проверяем корректность капчи
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

                    LogInButton.Enabled = false; // блокируем кнопку
                    blockTimer.Start(); // запускаем таймер
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
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // инициируем подключение 
                {
                    conn.Open(); // открываем подключение
                    MySqlCommand cmd = new MySqlCommand($"SELECT id from staff where login = '{loginTextBox.Text.Trim()}';", conn); // выполняем запрос
                    int user_id = Convert.ToInt32(cmd.ExecuteScalar()); // получаем ответ и записываем его в переменную
                    user.Default.userID = user_id; // сохраняем айди для дальнейшей работы 
                }
            }
            catch(Exception ex) { MessageBox.Show($"Ошибка {ex.Message}"); }
        } 
        private void CheckUser() // функция проверки пользователя
        {
            string query = $"SELECT password FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос для получения хэш пароля по логину
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // инициируем подключение 
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
            CaptchaTextBox.Text = "";
        }


        private int GetUserRole() // функция получения роли пользователя
        {
            string query = $"SELECT role FROM staff WHERE login = '{loginTextBox.Text.Trim()}';"; // запрос
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString())) // подключение
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

        private void TestDataBaseConn() // проверка подключения к БД
        {            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString.GetConnectionString()))
                {
                    conn.Open(); // инициируем подключение к базе данных
                }
            }
            catch (Exception) { MessageBox.Show("Ошибка подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                {
                    EditConn ed = new EditConn(); 
                    ed.ShowDialog(); // если подлючение не произошло вызываем форму настроцки подключения
                }
            }
                
        }

        private void connedit_Click(object sender, EventArgs e)
        {
            EditConn ec = new EditConn();
            ec.ShowDialog();
        }        

        private void ShowPwdButton_Click(object sender, EventArgs e) // отображаем или скрываем пароль
        {
            pwdTextBox.UseSystemPasswordChar = !pwdTextBox.UseSystemPasswordChar;
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
