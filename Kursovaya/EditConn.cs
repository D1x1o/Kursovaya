using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ФОРМА настройки подключения к базе данных

namespace Kursovaya
{
    public partial class EditConn : Form
    {
        string pepeConn; // переменная для хранения пути к файлу хранящему данные для подключения
        public EditConn()
        {
            InitializeComponent();
            CheckFolderAndCSV(); // проверяем есть ли папка AppAData/pepeShop и в ней connection.csv - файл хранящий данные для подключения к БД
        }
        private void CheckFolderAndCSV()
        {
            // Путь к AppData/Roaming
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Путь к AppData/Roaming/pepeShop
            string pepeShopPath = Path.Combine(appDataPath, "pepeShop");

            // Создание папки (если не существует)
            if (!Directory.Exists(pepeShopPath))
            {
                Directory.CreateDirectory(pepeShopPath);
            }

            // Путь к файлу connection.csv
            pepeConn = Path.Combine(pepeShopPath, "connection.csv");

            // Создание файла (если не существует)
            if (!File.Exists(pepeConn))
            {
                File.WriteAllText(pepeConn, "Host,Login,Password"); // записываем шапку в csv файл
                showConnData(); // отображаем данные в поля ввода даже если данных нет
            }
            else
            {
                showConnData(); // здесь уже мы из ранее существующего файла берём данные то есть там они должны быть
            }
        }

        private void showConnData() // функция отображения данных подлючения в textbox-ы
        {
            using (StreamReader reader = new StreamReader(pepeConn)) // инициируем потоковое чтоние файла 
            {
                reader.ReadLine(); // читаем перую строку - шапку
                string input2 = reader.ReadLine(); // читаем вторую строку наши данные
                if(input2 == null)
                {
                    return;
                }
                string[] connItems = input2.Split(',').ToArray(); // разбиваем строку из csv файла на массив, каждый элемент заканчивается запятой
                serverAddres.Text = connItems[0]; // айпи сервера заносим в соответствующий textbox
                serverUser.Text = connItems[1]; // имя пользователя заносим также в textbox
                serverPassword.Text = connItems[2]; // и пароль также в свой textbox
            }
        } 

        private void saveConnData_Click(object sender, EventArgs e) // обработчик нажатия кнопки сохранения данных 
        {
            using (StreamWriter writer = new StreamWriter(pepeConn)) // инициилизируем потоковую запись
            {
                writer.WriteLine("Host,Login,Password"); // перезаписываем шапку csv файла
                writer.WriteLine($"{serverAddres.Text.Trim()},{serverUser.Text.Trim()},{serverPassword.Text.Trim()}"); // и перезаписываем данные подключения
            }
            MessageBox.Show("Данные для подключения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information );
            this.Hide(); // когда данные записаны прячем форму
        }

        private void checkConnectionButton_Click(object sender, EventArgs e) // обработчик нажатия кнопки проверки подключения
        {
            try
            {
                string connStr = $"Server={serverAddres.Text.Trim()}; User Id={serverUser.Text.Trim()}; Password={serverPassword.Text.Trim()}"; // берём из textbox-ов адрес сервера, имя пользователя и пароль и по этим данным пытаемся подключится
                using (MySqlConnection conn = new MySqlConnection(connStr)) // инициируем подключение 
                {
                    conn.Open(); // если подключение успешно пойдём дальше если нет то упадём в ошибку
                    MessageBox.Show($"Подключение успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); // сообщение если подключение успешно
                    saveConnData.Enabled = true; // даём пользователю доступ к сохранению данных если они корректные 
                }
            }
            catch (Exception ex) { saveConnData.Enabled = false; MessageBox.Show($"Ошибка подключения проверьте введённые данные! \n\n {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error); } // соответственно сообщение о не удачной попытке подключения 
        }
    }
}
