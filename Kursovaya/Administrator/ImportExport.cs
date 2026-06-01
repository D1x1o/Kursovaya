using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.Administrator
{
    public partial class FormExportImport : Form
    {
        bool addInTable = false;
        string connStr = ConnectionString.GetConnectionString();
        public FormExportImport()
        {
            InitializeComponent();
            SetComboBox();
            dataGridView1.RowHeadersVisible = false;
        }
        public void SetComboBox()
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Add("Процессоры");
            categoryComboBox.Items.Add("Видеокарты");
            categoryComboBox.Items.Add("Материнские платы");
            categoryComboBox.Items.Add("Оперативная память");
            categoryComboBox.Items.Add("Кулеры");
            categoryComboBox.Items.Add("Корпусы");
            categoryComboBox.Items.Add("Блоки питания");
            categoryComboBox.Items.Add("Корпусные кулеры");
            categoryComboBox.Items.Add("Накопители");
            categoryComboBox.Items.Add("Термопаста");
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pepeShopFolder = Path.Combine(appDataPath, "pepeShop");
            string path = Path.Combine(pepeShopFolder, "tables.json");
            if (File.Exists(path))
            {

                string json = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(json) || json.Length < 3)
                {

                }
                else
                {
                    JObject root = JObject.Parse(json);

                    JArray tables = (JArray)root["tables"];
                    foreach (JObject table in tables)
                    {
                        categoryComboBox.Items.Add(table["displayName"].ToString());
                    }
                }

            }
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
            try
            {
                if (!addInTable)
                {
                    DialogResult q = MessageBox.Show("ВНИМАНИЕ\nИмпорт базы данных перезапишет все данные\nВы действительно хотите выполнить импорт", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (q == DialogResult.Yes)
                    {
                        string sql = richTextBox1.Text;

                        using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                        {
                            conn.Open();

                            using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                            {
                                cmd.CommandTimeout = 0;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Импорт базы данных успешно выполнен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (addInTable)
                {
                    if (string.IsNullOrEmpty(categoryComboBox.Text))
                    {
                        MessageBox.Show($"Выберите категорию товаров для добавления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if(dataGridView1.Columns.Count == 0)
                    {
                        MessageBox.Show($"Выберите файл источник данных для добавления товаров!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    DialogResult q = MessageBox.Show($"Вы действительно хотите добавить товар(ы) в категорию {categoryComboBox.Text}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (q != DialogResult.Yes)
                    {
                        return;
                    }
                    using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                    {
                        conn.Open();
                        string tableName = categoryComboBox.Text;
                        switch (tableName)
                        {
                            case "Процессоры":
                                tableName = "processors";
                                break;
                            case "Видеокарты":
                                tableName = "videocards";
                                break;
                            case "Материнские платы":
                                tableName = "motherboards";
                                break;
                            case "Оперативная память":
                                tableName = "ram";
                                break;
                            case "Кулеры":
                                tableName = "cpu_cooler";
                                break;
                            case "Корпусы":
                                tableName = "cases";
                                break;
                            case "Блоки питания":
                                tableName = "power_supplier";
                                break;
                            case "Корпусные кулеры":
                                tableName = "case_coolers";
                                break;
                            case "Накопители":
                                tableName = "storage";
                                break;
                            case "Термопаста":
                                tableName = "thermo_interface";
                                break;
                        }
                        int result = 0;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow)
                                continue;

                            List<string> columns = new List<string>();
                            List<string> parameters = new List<string>();

                            var cmd = new MySql.Data.MySqlClient.MySqlCommand();
                            cmd.Connection = conn;

                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                // Пропускаем id
                                if (col.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                                    continue;
                                if (col.Name.Equals("image", StringComparison.OrdinalIgnoreCase))
                                    continue;

                                string paramName = "@" + col.Name;

                                columns.Add(col.Name);
                                parameters.Add(paramName);

                                cmd.Parameters.AddWithValue(
                                    paramName,
                                    row.Cells[col.Index].Value ?? DBNull.Value);
                            }

                            cmd.CommandText =
                                $"INSERT INTO {tableName} ({string.Join(",", columns)}) " +
                                $"VALUES ({string.Join(",", parameters)})";

                            result += cmd.ExecuteNonQuery();
                                                       
                        }
                        if (result > 0)
                        {
                            MessageBox.Show($"Добавлено {result} товара(ов)!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(GetFriendlyError(ex), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
        }
        private string GetFriendlyError(Exception ex)
        {
            if (ex is MySql.Data.MySqlClient.MySqlException mysqlEx)
            {
                switch (mysqlEx.Number)
                {
                    case 1054:
                        return "Ошибка: указан несуществующий столбец в таблице.";

                    case 1146:
                        return "Ошибка: таблица не найдена в базе данных.";

                    case 1049:
                        return "Ошибка: база данных не существует.";

                    case 1452:
                        return "Ошибка: нарушение связей между таблицами (внешний ключ).";

                    case 1062:
                        return "Ошибка: запись с такими данными уже существует (дубликат).";

                    case 1045:
                        return "Ошибка: неверный логин или пароль к базе данных.";

                    case 0:
                        return "Ошибка соединения с сервером базы данных.";

                    default:
                        return $"Неизвестная ошибка базы данных: {ex.Message}";
                }
            }
            else
            {
                return $"Неизвестная ошибка базы данных: {ex.Message}";
            }
        }

        private void OpenDumpButton_Click(object sender, EventArgs e)
        {
            OpenSQLFileInRichTextBoxAdvanced(richTextBox1);
        }
        public  void showdgv(string filePath)
        {
            try
            {
                categoryComboBox.Visible = true;
                label1.Visible = true;
                dataGridView1.Visible = true;
                richTextBox1.Visible = false;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                System.Data.DataTable dt = new System.Data.DataTable();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    if (worksheet.Dimension == null)
                        return;

                    int rows = worksheet.Dimension.Rows;
                    int cols = worksheet.Dimension.Columns;

                    // Первая строка — заголовки
                    for (int col = 1; col <= cols; col++)
                    {

                        string header = worksheet.Cells[1, col].Text;
                        if (string.IsNullOrWhiteSpace(header))
                            header = $"Column{col}";

                        dt.Columns.Add(header);
                    }
                    
                    // Остальные строки — данные
                    for (int row = 2; row <= rows; row++)
                    {
                        DataRow dr = dt.NewRow();

                        for (int col = 1; col <= cols; col++)
                        {
                            dr[col - 1] = worksheet.Cells[row, col].Text;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                dataGridView1.DataSource = dt;
                if (dataGridView1.Columns.Contains("id"))
                {
                    dataGridView1.Columns["id"].Visible = false;
                }

                dataGridView1.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportMySQLDatabase(connStr);
        }
        public  void OpenSQLFileInRichTextBoxAdvanced(RichTextBox richTextBox1)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Выберите SQL файл для загрузки";
                    openFileDialog.Filter = "SQL files (*.sql)|*.sql|Excel files (*.xlsx)|*.xlsx";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        FileInfo fileInfo = new FileInfo(filePath);

                        if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                        {
                            addInTable = true;
                            showdgv(filePath);
                            return;
                        }
                        else
                        {
                            addInTable = false;
                            dataGridView1.Visible = false;
                            richTextBox1.Visible = true;
                            categoryComboBox.Visible = false;
                            label1.Visible = false;
                        }
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

                        MessageBox.Show($"Файл успешно загружен: {fileInfo.Name}",
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
