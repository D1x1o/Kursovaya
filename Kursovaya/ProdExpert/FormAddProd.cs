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
            fillComboBox(); //заполняем ComboBox
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
        private void fillDgv(string theme) // метод заполнения dataGridView названиями характеристик для выбранной темы
        {
            dataGridView1.Columns.Clear(); // очистка всех колонок таблицы

            var rows = GetColumnNames(connStr, theme); // получение списка имен колонок из таблицы бд

            DataGridViewTextBoxColumn valueColumn = new DataGridViewTextBoxColumn(); // создание колонки для названий характеристик
            valueColumn.Name = "value"; // установка внутреннего имени колонки
            valueColumn.HeaderText = "Названия характеристик"; // установка отображаемого заголовка
            dataGridView1.Columns.Add(valueColumn); // добавление колонки в таблицу

            foreach (var row in rows) // перебор всех имен колонок из бд
            {
                if (row == "id" || row == "image" || row == "inStock") // проверка, является ли колонка служебной
                {
                    continue; // пропуск служебных колонок (id, image, instock)
                }
                dataGridView1.Rows.Add(ColumnsNameMap.GetRussianName(row)); // добавление строки с русским названием характеристики
            }

            DataGridViewTextBoxColumn dataColumn = new DataGridViewTextBoxColumn(); // создание колонки для значений характеристик
            dataColumn.Name = "data"; // установка внутреннего имени колонки
            dataColumn.HeaderText = "Характеристики"; // установка отображаемого заголовка
            dataGridView1.Columns.Add(dataColumn); // добавление колонки в таблицу

            dataGridView1.Columns["value"].ReadOnly = true; // колонка с названиями только для чтения
            dataGridView1.Columns["data"].ReadOnly = false; // колонка со значениями доступна для редактирования
        }

        private void SetDefaultPicture() // метод установки изображения по умолчанию
        {
            try // блок обработки исключений
            {
                // формирование пути к папке с изображениями в папке appdata пользователя
                string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pepeShop\\img");

                // формирование полного пути к файлу заглушки
                string imagePath = Path.Combine(imgFolder, "no-image.png");

                productPictureBox.Image = Image.FromFile(imagePath); // загрузка изображения в picturebox
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } // вывод сообщения об ошибке при возникновении исключения
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) // обработчик отображения элемента редактирования
        {
            if (e.Control is TextBox tb) // проверка, что редактирование происходит в текстовом поле
            {
                tb.KeyPress -= TextBox_KeyPress; // удаление предыдущего обработчика нажатия клавиш
                tb.KeyPress += TextBox_KeyPress; // добавление нового обработчика нажатия клавиш

                // получение названия текущей характеристики из первой колонки
                string columnName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                // словарь с максимальной длиной для различных полей
                var maxLengths = new Dictionary<string, int>()
        {
            { "Модель", 50 }, // модель не длиннее 50 символов
            { "Производитель", 50 }, // производитель не длиннее 50 символов
            { "Сокет", 10 }, // сокет не длиннее 10 символов
            { "Частота", 10 }, // частота не длиннее 10 символов
            { "Количество ядер", 3 }, // количество ядер не длиннее 3 символов (до 999)
            { "Стоимость", 10 }, // стоимость не длиннее 10 символов
            { "Объём", 10 } // объем не длиннее 10 символов
        };

                if (maxLengths.ContainsKey(columnName)) // если для данного поля задано ограничение длины
                {
                    tb.MaxLength = maxLengths[columnName]; // установка специфического ограничения
                }
                else // если специфического ограничения нет
                {
                    tb.MaxLength = 50; // установка стандартного ограничения в 50 символов
                }
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) // обработчик нажатия клавиш при вводе
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 1) // проверка, что редактируется вторая колонка (значения)
            {
                // получение названия характеристики из первой колонки текущей строки
                string columnName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                // массив полей, которые должны содержать только числа
                string[] numericFields = { "Стоимость", "Количество ядер", "Частота", "Объём", "L3 кэш", "Тепловыделение","Количество слотов ОЗУ",
        "Максимальный объём ОЗУ","Количество слотов расширения","Слоты для M.2 SSD","Объём","Скорость записи", "Скорость чтения"
        , "Максимальная длина видеокарты", "Максимальная высота кулера", "Количество отсеков", "Размер вентилятора", "Объём видеопамяти", "Разрядность шины памяти"
        , "Потребляемая мощность", "Длина видеокарты", "Частота памяти", "Мощность", "Рассеиваемая мощность", "Высота кулера", "Теплопроводность", "Вес", "Срок годности"
        };

                if (numericFields.Contains(columnName)) // если текущее поле должно содержать числа
                {
                    // разрешаем только цифры, backspace и запятую/точку
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                    {
                        e.Handled = true; // запрещаем ввод
                        return; // выход из метода
                    }

                    int maxLength = 10; // ограничение для числовых полей
                    string currentText = dataGridView1.CurrentCell.EditedFormattedValue.ToString(); // получение текущего текста

                    // разрешаем backspace даже если длина достигнута
                    if (!char.IsControl(e.KeyChar) && currentText.Length >= maxLength)
                    {
                        e.Handled = true; // запрещаем ввод при превышении длины
                    }
                }
                else // для остальных полей
                {
                    int maxLength = 50; // ограничение для остальных полей
                    string currentText = dataGridView1.CurrentCell.EditedFormattedValue.ToString(); // получение текущего текста

                    // разрешаем backspace даже если длина достигнута
                    if (!char.IsControl(e.KeyChar) && currentText.Length >= maxLength)
                    {
                        e.Handled = true; // запрещаем ввод при превышении длины
                    }
                }
            }
        }

        private void addPic_Click(object sender, EventArgs e) // обработчик нажатия кнопки добавления изображения
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создание диалога выбора файла
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;"; // фильтр только для изображений
            openFileDialog.Title = "Выберите изображение"; // заголовок окна

            if (openFileDialog.ShowDialog() == DialogResult.OK) // если пользователь выбрал файл и нажал ок
            {
                string filePath = openFileDialog.FileName; // получение пути к выбранному файлу

                // получение расширения файла
                string extension = Path.GetExtension(filePath);

                // генерация уникального имени файла с помощью guid
                string uniqueName = Guid.NewGuid().ToString("N") + extension;

                // получение размера файла
                long fileSize = new FileInfo(filePath).Length;
                if (fileSize > 5 * 1024 * 1024) // если размер больше 5 мегабайт
                {
                    MessageBox.Show("Файл слишком большой! Выберите изображение меньше 5 МБ.",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // выход из метода
                }

                // формирование пути к папке для сохранения изображений
                string imgFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "pepeShop",
                    "img"
                );

                if (!Directory.Exists(imgFolder)) // если папка не существует
                {
                    Directory.CreateDirectory(imgFolder); // создание папки
                }

                string destPath = Path.Combine(imgFolder, uniqueName); // полный путь для сохранения файла

                File.Copy(filePath, destPath, true); // копирование файла с перезаписью если существует

                picPath = $"img/{uniqueName}"; // сохранение относительного пути к изображению

                // чтобы файл не блокировался системой, используем поток для чтения
                using (var stream = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                {
                    productPictureBox.Image = Image.FromStream(stream); // загрузка изображения из потока
                }

                MessageBox.Show("Изображение добавлено", // сообщение об успешном добавлении
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void addProd_Click(object sender, EventArgs e) // обработчик нажатия кнопки добавления товара
        {
            try // блок обработки исключений
            {
                if (dataGridView1.Rows.Count == 0) // если в таблице нет строк
                    return; // выход из метода

                using (MySqlConnection conn = new MySqlConnection(connStr)) // создание подключения к бд
                {
                    conn.Open(); // открытие подключения

                    List<string> columns = new List<string>(); // список для имен колонок
                    List<string> values = new List<string>(); // список для значений

                    foreach (DataGridViewRow row in dataGridView1.Rows) // перебор всех строк таблицы
                    {
                        if (row.IsNewRow) continue; // пропуск строки для ввода новой

                        string displayName = row.Cells[0].Value?.ToString(); // получение названия характеристики
                        string value = row.Cells[1].Value?.ToString()?.Trim(); // получение значения и удаление пробелов

                        // пропускаем пустые значения
                        if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(value))
                            continue; // переход к следующей строке

                        // проверяем наличие соответствия в reversemap
                        if (!ColumnsNameMap.ReverseMap.ContainsKey(displayName))
                            continue; // если нет соответствия, пропускаем

                        string columnName = ColumnsNameMap.ReverseMap[displayName]; // получение системного имени колонки

                        // экранируем строку для mysql (защита от sql инъекций)
                        string escapedValue = MySqlHelper.EscapeString(value);

                        columns.Add(columnName); // добавление имени колонки в список
                        values.Add($"'{escapedValue}'"); // добавление экранированного значения в список
                    }

                    if (columns.Count == 0) // если не добавлено ни одной колонки
                    {
                        MessageBox.Show("Нет данных для добавления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // выход из метода
                    }

                    string insertQuery = ""; // переменная для sql запроса
                    if (picPath == "") // если изображение не выбрано
                    {
                        // формирование запроса без изображения
                        insertQuery = $"INSERT INTO {globalTheme} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", values)});";
                    }
                    else // если изображение выбрано
                    {
                        // формирование запроса с изображением
                        insertQuery = $"INSERT INTO {globalTheme} ({string.Join(", ", columns)}, image) VALUES ({string.Join(", ", values)}, '{picPath}');";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn)) // создание команды
                    {
                        int rowsAffected = cmd.ExecuteNonQuery(); // выполнение запроса и получение количества затронутых строк
                        if (rowsAffected > 0) // если добавлена хотя бы одна строка
                            MessageBox.Show("Новая запись успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else // если ни одной строки не добавлено
                            MessageBox.Show("Не удалось добавить запись.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        clear(); // очистка формы после добавления
                    }
                }
            }
            catch (Exception ex) // обработка исключений
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message); // вывод сообщения об ошибке
            }
        }

        private void clear() // метод очистки формы
        {
            SetDefaultPicture(); // установка изображения по умолчанию
            dataGridView1.Rows.Clear(); // очистка всех строк таблицы
            dataGridView1.Columns.Clear(); // очистка всех колонок таблицы
        }
    }
}
