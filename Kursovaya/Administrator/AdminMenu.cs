using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ФОРМА меню админисратора 

namespace Kursovaya.Administrator
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void ShowUsers_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Пользователи" 
        {
            Users prod = new Users(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму работы с пользователями
            Show(); // после окончания работы с пользователями обратно отображаем меню
        }

        private void ShowOrders_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Заказы" 
        {
            Orders prod = new Orders(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму работы с заказами
            Show(); // после окончания работы с заказами обратно отображаем меню
        }

        private void ShowProducts_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Товары" 
        {
            Prod prod = new Prod(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму просмотра товаров
            Show(); // после окончания работы с товарами обратно отображаем меню
        }

        private void exportImport_Click(object sender, EventArgs e)
        {
            FormExportImport prod = new FormExportImport(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму 
            Show(); // после окончания работы отображаем меню
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminSettings settings = new AdminSettings(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            settings.ShowDialog(); // отображаем форму 
            Show(); // после окончания работы отображаем меню
        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExportMySQLDatabase(ConnectionString.GetConnectionString());
        }
        public static void ExportMySQLDatabase(string connectionString)
        {
            try
            {
                var builder = new MySqlConnectionStringBuilder(connectionString);
                string databaseName = builder.Database;

                if (string.IsNullOrEmpty(databaseName))
                {
                    MessageBox.Show(
                        "Не удалось определить имя базы данных из строки подключения.",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

                // Папка Документы
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Папка для backup
                string backupFolder = Path.Combine(documentsPath, "pepeShopBackUp");

                // Создать папку если её нет
                if (!Directory.Exists(backupFolder))
                {
                    Directory.CreateDirectory(backupFolder);
                }

                // Имя файла
                string fileName = $"{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

                // Полный путь
                string fullPath = Path.Combine(backupFolder, fileName);

                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var writer = new StreamWriter(fullPath))
                    {
                        writer.WriteLine($"-- MySQL Backup: {databaseName} - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                        writer.WriteLine("/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;\n");

                        var tables = new List<string>();

                        using (var cmd = new MySqlCommand(
                            $"SELECT table_name FROM information_schema.tables WHERE table_schema = '{databaseName}' AND table_type = 'BASE TABLE'",
                            connection))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tables.Add(reader.GetString(0));
                            }
                        }

                        foreach (var table in tables)
                        {
                            // Структура таблицы
                            using (var cmd = new MySqlCommand(
                                $"SHOW CREATE TABLE `{databaseName}`.`{table}`",
                                connection))
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    writer.WriteLine($"-- Table: {table}");
                                    writer.WriteLine($"DROP TABLE IF EXISTS `{table}`;");
                                    writer.WriteLine(reader.GetString(1) + ";\n");
                                }
                            }

                            // Данные таблицы
                            using (var cmd = new MySqlCommand(
                                $"SELECT * FROM `{databaseName}`.`{table}`",
                                connection))
                            using (var reader = cmd.ExecuteReader())
                            {
                                var columns = Enumerable
                                    .Range(0, reader.FieldCount)
                                    .Select(i => reader.GetName(i))
                                    .ToArray();

                                while (reader.Read())
                                {
                                    writer.Write(
                                        $"INSERT INTO `{table}` ({string.Join(", ", columns.Select(c => $"`{c}`"))}) VALUES ("
                                    );

                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        if (i > 0)
                                            writer.Write(", ");

                                        if (reader.IsDBNull(i))
                                        {
                                            writer.Write("NULL");
                                        }
                                        else
                                        {
                                            var val = reader.GetValue(i);

                                            if (val is string || val is DateTime || val is TimeSpan)
                                            {
                                                writer.Write($"'{val.ToString().Replace("'", "''")}'");
                                            }
                                            else if (val is bool)
                                            {
                                                writer.Write((bool)val ? "1" : "0");
                                            }
                                            else if (val is byte[])
                                            {
                                                writer.Write($"0x{BitConverter.ToString((byte[])val).Replace("-", "")}");
                                            }
                                            else
                                            {
                                                writer.Write(val);
                                            }
                                        }
                                    }

                                    writer.WriteLine(");");
                                }
                            }

                            writer.WriteLine();
                        }

                        writer.WriteLine("/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;");
                        writer.WriteLine($"-- Backup completed: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    }
                }

                MessageBox.Show(
                    $"База данных экспортирована:\n{fullPath}",
                    "Back UP",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                //Process.Start("explorer.exe", backupFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ошибка: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            }
        }
    }
}
