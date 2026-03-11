using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Kursovaya.Administrator
{
    public partial class FormExportImport : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public FormExportImport()
        {
            InitializeComponent();

        }
        public static void ExportMySQLDatabase(string connectionString)
        {
            try
            {
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Выберите папку для сохранения структуры и данных базы данных";

                    if (folderDialog.ShowDialog() == DialogResult.OK)
                    {
                        var builder = new MySqlConnectionStringBuilder(connectionString);
                        string databaseName = builder.Database;

                        if (string.IsNullOrEmpty(databaseName))
                        {
                            MessageBox.Show("Не удалось определить имя базы данных из строки подключения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string fileName = $"{databaseName}_backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                        string fullPath = Path.Combine(folderDialog.SelectedPath, fileName);

                        using (var connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            using (var writer = new StreamWriter(fullPath))
                            {
                                writer.WriteLine($"-- MySQL Backup: {databaseName} - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                                writer.WriteLine("/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;\n");

                                var tables = new List<string>();
                                using (var cmd = new MySqlCommand($"SELECT table_name FROM information_schema.tables WHERE table_schema = '{databaseName}' AND table_type = 'BASE TABLE'", connection))
                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read()) tables.Add(reader.GetString(0));
                                }

                                foreach (var table in tables)
                                {
                                    // Структура
                                    using (var cmd = new MySqlCommand($"SHOW CREATE TABLE `{databaseName}`.`{table}`", connection))
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            writer.WriteLine($"-- Table: {table}");
                                            writer.WriteLine($"DROP TABLE IF EXISTS `{table}`;");
                                            writer.WriteLine(reader.GetString(1) + ";\n");
                                        }
                                    }

                                    // Данные
                                    using (var cmd = new MySqlCommand($"SELECT * FROM `{databaseName}`.`{table}`", connection))
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        var columns = Enumerable.Range(0, reader.FieldCount).Select(i => reader.GetName(i)).ToArray();

                                        while (reader.Read())
                                        {
                                            writer.Write($"INSERT INTO `{table}` ({string.Join(", ", columns.Select(c => $"`{c}`"))}) VALUES (");

                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                if (i > 0) writer.Write(", ");

                                                if (reader.IsDBNull(i))
                                                    writer.Write("NULL");
                                                else
                                                {
                                                    var val = reader.GetValue(i);
                                                    if (val is string || val is DateTime || val is TimeSpan)
                                                        writer.Write($"'{val.ToString().Replace("'", "''")}'");
                                                    else if (val is bool)
                                                        writer.Write((bool)val ? "1" : "0");
                                                    else if (val is byte[])
                                                        writer.Write($"0x{BitConverter.ToString((byte[])val).Replace("-", "")}");
                                                    else
                                                        writer.Write(val);
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

                        MessageBox.Show($"База данных экспортирована:\n{fullPath}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void importButton_Click(object sender, EventArgs e)
        {

        }

        private void OpenDumpButton_Click(object sender, EventArgs e)
        {
            OpenSQLFileInRichTextBoxAdvanced(richTextBox1);
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportMySQLDatabase(connStr);
        }
        public static void OpenSQLFileInRichTextBoxAdvanced(RichTextBox richTextBox1)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Выберите SQL файл для загрузки";
                    openFileDialog.Filter = "SQL files (*.sql)|*.sql|SQL Backup files (*.bak)|*.bak|Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        FileInfo fileInfo = new FileInfo(filePath);

                        // Проверяем размер файла (если больше 10 MB, предупреждаем)
                        if (fileInfo.Length > 10 * 1024 * 1024)
                        {
                            var result = MessageBox.Show("Файл очень большой. Загрузка может занять некоторое время. Продолжить?",
                                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (result == DialogResult.No)
                                return;
                        }

                        // Показываем индикатор загрузки (если есть)
                        // progressBar1.Visible = true;

                        // Читаем файл с определением кодировки
                        string fileContent = ReadFileWithEncoding(filePath);

                        // Обновляем RichTextBox
                        richTextBox1.Clear();
                        richTextBox1.Text = fileContent;

                        // Применяем форматирование
                        richTextBox1.SelectAll();
                        richTextBox1.SelectionFont = new System.Drawing.Font("Consolas", 10);
                        richTextBox1.Select(0, 0);

                        // Добавляем информацию о файле в начало (опционально)
                        string header = $"-- Файл: {fileInfo.Name}\r\n-- Размер: {fileInfo.Length:N0} байт\r\n-- Загружен: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\r\n-- Количество строк: {fileContent.Split('\n').Length}\r\n\r\n";

                        // Вставляем заголовок, если его еще нет
                        if (!richTextBox1.Text.StartsWith("-- Файл:"))
                        {
                            richTextBox1.Select(0, 0);
                            richTextBox1.SelectedText = header;
                        }

                        // Прокручиваем в начало
                        richTextBox1.SelectionStart = 0;
                        richTextBox1.ScrollToCaret();

                        // Скрываем индикатор загрузки
                        // progressBar1.Visible = false;

                        MessageBox.Show($"Файл успешно загружен:\n{fileInfo.Name}\nРазмер: {fileInfo.Length:N0} байт\nСтрок: {fileContent.Split('\n').Length}",
                            "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Вспомогательная функция для чтения файла с определением кодировки
        private static string ReadFileWithEncoding(string filePath)
        {
            try
            {
                // Пробуем прочитать с UTF-8
                return File.ReadAllText(filePath, System.Text.Encoding.UTF8);
            }
            catch
            {
                try
                {
                    // Если не получилось, пробуем с ANSI
                    return File.ReadAllText(filePath, System.Text.Encoding.GetEncoding(1251));
                }
                catch
                {
                    // Если всё еще не получилось, читаем как есть
                    return File.ReadAllText(filePath);
                }
            }
        }
    }
}
