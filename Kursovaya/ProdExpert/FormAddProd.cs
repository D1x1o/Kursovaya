using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

// ФОРМА добавления товаров
// в комментариях в коду исползуется сокращение 'DGV' что означает DataGridView

namespace Kursovaya.ProdExpert
{
    public partial class FormAddProd : Form
    {
        string globalTheme; // переменная хранящая в какую категорию пользователь хочет добавить товар
        string picPath = ""; // переменная хранения пути к изображению
        string connStr = ConnectionString.GetConnectionString(); // получаем из класса строку подключения
        public FormAddProd()
        {
            InitializeComponent();
            fillComboBox(); //заполняем DGV
            SetDefaultPicture(); // устанавливаем заглушку на место изображения товара
            // дизайн DGV
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;            
        }
        class Category // объект категории
        {
            public string SystemName { get; set; }
            public string DisplayName { get; set; }
        }

        private void fillComboBox() // функция заполнения ComboBox-а
        {
            try
            {
                var categories = new List<Category>
                {
                    new Category { SystemName = "processors", DisplayName = "Процессоры" },
                    new Category { SystemName = "videocards", DisplayName = "Видеокарты" },
                    new Category { SystemName = "motherboards", DisplayName = "Материнские платы" },
                    new Category { SystemName = "ram", DisplayName = "Оперативная память" },
                    new Category { SystemName = "cpu_cooler", DisplayName = "Кулеры" },
                    new Category { SystemName = "case", DisplayName = "Корпусы" },
                    new Category { SystemName = "power_supplier", DisplayName = "Блоки питания" },
                    new Category { SystemName = "case_coolers", DisplayName = "Корпусные кулеры" },
                    new Category { SystemName = "storage", DisplayName = "Накопители" },
                    new Category { SystemName = "thermo_interface", DisplayName = "Термопаста" },
                };
                // если есть категории добавленные пользователем, берем данные из Json
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json");
                if (File.Exists(path))
                {

                    string json = File.ReadAllText(path);
                    if (string.IsNullOrWhiteSpace(json))
                    {

                    }
                    else
                    {
                        JObject root = JObject.Parse(json);

                        JArray tables = (JArray)root["tables"];
                        foreach (JObject table in tables)
                        {
                            categories.Add(new Category
                            {
                                SystemName = table["systemName"].ToString(),
                                DisplayName = table["displayName"].ToString()
                            });
                        }
                    }
                        
                }

                categoryComboBox.DisplayMember = "DisplayName"; // наименование категории которая видна пользователю
                categoryComboBox.ValueMember = "SystemName"; // системное наименование категории
                categoryComboBox.DataSource = categories;                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); // обработчик ошибок
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e) // обработчик изменения выбранного элеменоа в ComboBox-е
        {
            try
            {
                if (categoryComboBox.SelectedValue == null) // если ничего не выбранно выходим из функции
                    return;

                string theme = categoryComboBox.SelectedValue.ToString(); // получаем выбранную категорию
                globalTheme = theme; // сохраняем ваыбранную категорию
                fillDgv(theme); // заполняем DGV в зависимости от выбранной категории

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } // обработчик ошибок
        }
        public List<string> GetColumnNames(string connectionString, string theme) // получаем из БД какие характеристики есть у товаров
        {
            var columns = new List<string>();

            string query = $"SELECT COLUMN_NAME  FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '{theme}'; ";

            using (var connection = new MySqlConnection(connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(0));
                    }
                }
            }

            return columns;
        }
        private void fillDgv(string theme)
        {
            dataGridView1.Columns.Clear();
            var rows = GetColumnNames(connStr, theme);
            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn();
            valueColumn.Name = "value";
            valueColumn.HeaderText = "Названия характеристик";
            dataGridView1.Columns.Add(valueColumn);   
            foreach (var row in rows)
            {
                if(row == "id" || row == "image" || row == "inStock")
                {
                    continue; 
                }
                dataGridView1.Rows.Add(ColumnsNameMap.GetRussianName(row));
            }
            DataGridViewTextBoxColumn dataColumn = new DataGridViewTextBoxColumn();
            dataColumn.Name = "data";
            dataColumn.HeaderText = "Характеристики";
            dataGridView1.Columns.Add(dataColumn);
            dataGridView1.Columns["value"].ReadOnly = true;
            dataGridView1.Columns["data"].ReadOnly = false;
        }


        private void SetDefaultPicture()
        {
            try
            {
                string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pepeShop/img");

                string imagePath = Path.Combine(imgFolder, "no-image.png");

                productPictureBox.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex) {MessageBox.Show(ex.Message);  }    
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= TextBox_KeyPress;
                tb.KeyPress += TextBox_KeyPress;
                string columnName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                var maxLengths = new Dictionary<string, int>()
        {
            { "Модель", 50 },
            { "Производитель", 50 },
            { "Сокет", 10 },
            { "Частота", 10 },
            { "Количество ядер", 3 },
            { "Стоимость", 10 },
            { "Объём", 10 }
        };

                if (maxLengths.ContainsKey(columnName))
                {
                    tb.MaxLength = maxLengths[columnName];
                }
                else
                {
                    tb.MaxLength = 50; // дефолтное ограничение
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1) // колонка значений
            {
                string columnName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                // Список полей, которые должны быть только числа
                string[] numericFields = { "Стоимость", "Количество ядер", "Частота", "Объём", "L3 кэш", "Тепловыделение","Количество слотов ОЗУ",
                "Максимальный объём ОЗУ","Количество слотов расширения","Слоты для M.2 SSD","Объём","Скорость записи", "Скорость чтения"
                , "Максимальная длина видеокарты", "Максимальная высота кулера", "Количество отсеков", "Размер вентилятора", "Объём видеопамяти", "Разрядность шины памяти"
                , "Потребляемая мощность", "Длина видеокарты", "Частота памяти", "Мощность", "Рассеиваемая мощность", "Высота кулера", "Теплопроводность", "Вес", "Срок годности"
                };

                if (numericFields.Contains(columnName))
                {
                    // Разрешаем только цифры, Backspace и запятую/точку
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                    {
                        e.Handled = true; // запрещаем ввод
                    }
                    // Ограничиваем длину ввода
                    int maxLength;
                    string currentText = dataGridView1.CurrentCell.EditedFormattedValue.ToString();

                    if (numericFields.Contains(columnName))
                    {
                        // Разрешаем только цифры, Backspace и запятую/точку
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                        {
                            e.Handled = true; // запрещаем ввод
                            return;
                        }

                        maxLength = 10; // ограничение для числовых полей
                    }
                    else
                    {
                        maxLength = 50; // ограничение для остальных полей
                    }

                    // Разрешаем Backspace даже если длина достигнута
                    if (!char.IsControl(e.KeyChar) && currentText.Length >= maxLength)
                    {
                        e.Handled = true; // запрещаем ввод
                    }
                }
            }
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openFileDialog.Title = "Выберите изображение";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Получаем расширение файла
                string extension = Path.GetExtension(filePath);

                // Генерируем уникальное имя файла
                string uniqueName = Guid.NewGuid().ToString("N") + extension;

                long fileSize = new FileInfo(filePath).Length;
                if (fileSize > 5 * 1024 * 1024)
                {
                    MessageBox.Show("Файл слишком большой! Выберите изображение меньше 5 МБ.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string imgFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "pepeShop",
                    "img"
                );

                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }

                string destPath = Path.Combine(imgFolder, uniqueName);

                File.Copy(filePath, destPath, true);

                picPath = $"img/{uniqueName}";

                // Чтобы файл не блокировался системой
                using (var stream = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                {
                    productPictureBox.Image = Image.FromStream(stream);
                }

                MessageBox.Show("Изображение добавлено",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addProd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                    return;

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    List<string> columns = new List<string>();
                    List<string> values = new List<string>();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string displayName = row.Cells[0].Value?.ToString();
                        string value = row.Cells[1].Value?.ToString()?.Trim();

                        // Пропускаем пустые значения
                        if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(value))
                            continue;

                        // Проверяем наличие соответствия в ColumnsNameMap
                        if (!ColumnsNameMap.ReverseMap.ContainsKey(displayName))
                            continue;

                        string columnName = ColumnsNameMap.ReverseMap[displayName];

                        // Экранируем строку для MySQL
                        string escapedValue = MySqlHelper.EscapeString(value);

                        columns.Add(columnName);
                        values.Add($"'{escapedValue}'");
                    }

                    if (columns.Count == 0)
                    {
                        MessageBox.Show("Нет данных для добавления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string insertQuery = "";
                    if (picPath == "")
                    {
                        insertQuery = $"INSERT INTO {globalTheme} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)});";
                    }
                    else
                    {
                        insertQuery = $"INSERT INTO {globalTheme} ({string.Join(", ", columns)}, image) VALUES ({string.Join(", ", values)}, '{picPath}');";
                    }

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                                MessageBox.Show("Новая запись успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("Не удалось добавить запись.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clear();
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }
        private void clear()
        {
            SetDefaultPicture();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }
    }
}
