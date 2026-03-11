using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.ProdExpert
{
    public partial class FormAddCategory : Form
    {
        private string connStr = ConnectionString.GetConnectionString(); // получение строки подключения к бд

        public FormAddCategory() // конструктор формы
        {
            InitializeComponent(); // инициализация компонентов формы
            EnsureColumnsForTableDesigner(); // настройка колонок в dataGridView для конструктора таблиц
        }

        private void EnsureColumnsForTableDesigner() // метод настройки колонок dataGridView
        {
            if (dgvColumns.Columns.Count > 0) // проверка, есть ли уже колонки
                return; // выход из метода, если колонки уже есть

            dgvColumns.AutoGenerateColumns = false; // отключение автоматической генерации колонок
            dgvColumns.AllowUserToAddRows = true; // разрешение добавления строк пользователем
            dgvColumns.BackgroundColor = Color.FromArgb(97, 91, 104); // установка цвета фона таблицы
            dgvColumns.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104); // цвет фона ячеек
            dgvColumns.DefaultCellStyle.ForeColor = Color.White; // цвет текста в ячейках
            dgvColumns.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104); // цвет фона заголовков
            dgvColumns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // цвет текста заголовков
            dgvColumns.EnableHeadersVisualStyles = false; // отключение визуальных стилей для заголовков
            dgvColumns.RowHeadersVisible = false; // скрытие заголовков строк
            dgvColumns.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // выделение всей строки
            dgvColumns.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125); // цвет выделенной строки

            // Имя столбца (системное)
            var colName = new DataGridViewTextBoxColumn // создание колонки для системного имени поля
            {
                Name = "ColumnName", // внутреннее имя колонки
                HeaderText = "Имя поля", // отображаемый заголовок
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // автоматическое заполнение ширины
            };

            var colNameRu = new DataGridViewTextBoxColumn // создание колонки для отображаемого имени поля
            {
                Name = "ColumnNameRu", // внутреннее имя колонки
                HeaderText = "Имя поля кириллицей", // отображаемый заголовок
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // автоматическое заполнение ширины
            };

            // Тип данных
            var colType = new DataGridViewComboBoxColumn // создание выпадающего списка для типа данных
            {
                Name = "ColumnType", // внутреннее имя колонки
                HeaderText = "Тип данных", // отображаемый заголовок
                DataSource = new[] { "INT", "VARCHAR" }, // возможные значения: целое число или строка
                Width = 120 // ширина колонки
            };

            // Длина (только для VARCHAR)
            var colLength = new DataGridViewTextBoxColumn // создание колонки для длины поля
            {
                Name = "ColumnLength", // внутреннее имя колонки
                HeaderText = "Длина", // отображаемый заголовок
                Width = 80 // ширина колонки
            };

            dgvColumns.Columns.AddRange(colNameRu, colName, colType, colLength); // добавление всех колонок в dataGridView
        }


        // ================= ВАЛИДАЦИЯ ИМЁН =================
        private bool IsValidName(string name) // метод проверки корректности системного имени
        {
            return name.Length >= 5 && Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$"); // имя должно быть длиной от 5, начинаться с буквы или _, содержать буквы, цифры и _
        }

        // ================= КНОПКА: ДОБАВИТЬ СТОЛБЕЦ =================
        private void btnAddColumn_Click(object sender, EventArgs e) // обработчик кнопки добавления столбца
        {
            dgvColumns.Rows.Add(); // добавление новой строки в таблицу для ввода данных нового столбца
        }

        // ================= КНОПКА: УДАЛИТЬ СТОЛБЕЦ =================
        private void btnRemoveColumn_Click(object sender, EventArgs e) // обработчик кнопки удаления столбца
        {
            if (dgvColumns.SelectedRows.Count == 0) // если нет выделенных строк
                return; // выход из метода

            var row = dgvColumns.SelectedRows[0]; // получение первой выделенной строки

            if (row.IsNewRow) // проверка, является ли строка новой (еще не сохраненной)
            {
                MessageBox.Show("Нельзя удалить строку для ввода новых данных."); // сообщение об ошибке
                return; // выход из метода
            }

            if (dgvColumns.Rows.Count > 1) // если в таблице больше одной строки
            {
                dgvColumns.Rows.RemoveAt(row.Index); // удаление выбранной строки
            }
            else // если осталась только одна строка
            {
                MessageBox.Show("Нельзя создать таблицу без столбцов!"); // сообщение об ошибке
            }
        }

        // ================= БЛОКИРОВКА ДЛИНЫ VARCHAR =================
        private void dgvColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e) // обработчик изменения значения ячейки
        {
            if (e.RowIndex < 0) return; // если индекс строки некорректный, выход

            if (dgvColumns.Columns[e.ColumnIndex].Name == "ColumnType") // если изменилась колонка с типом данных
            {
                var row = dgvColumns.Rows[e.RowIndex]; // получение текущей строки
                string type = row.Cells["ColumnType"].Value?.ToString(); // получение выбранного типа

                row.Cells["ColumnLength"].ReadOnly = type != "VARCHAR"; // поле длины доступно только для типа varchar
                if (type != "VARCHAR") // если тип не varchar
                    row.Cells["ColumnLength"].Value = null; // очистка значения длины
            }
        }

        // ================= СОЗДАНИЕ ТАБЛИЦЫ =================
        private void btnCreateTable_Click(object sender, EventArgs e) // обработчик кнопки создания таблицы
        {
            try
            {
                foreach (DataGridViewRow row in dgvColumns.Rows) // перебор всех строк таблицы
                {
                    // проверка, не пытается ли пользователь создать стандартные поля, которые создаются автоматически
                    if (row.Cells["ColumnName"].Value?.ToString() == "id" || row.Cells["ColumnName"].Value?.ToString() == "model" || row.Cells["ColumnName"].Value?.ToString() == "produser" || row.Cells["ColumnName"].Value?.ToString() == "cost" || row.Cells["ColumnName"].Value?.ToString() == "inStock" || row.Cells["ColumnName"].Value?.ToString() == "image")
                    {
                        MessageBox.Show($"Столбец {row.Cells["ColumnName"].Value?.ToString()} является стандартным и создаётся автоматически, удалите его для создания категории!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // выход из метода при обнаружении стандартного поля
                    }
                }

                if (!IsValidNameRu(txtTableNameRu.Text)) // проверка корректности отображаемого имени таблицы
                {
                    return; // выход при некорректном имени
                }

                string tableName = txtTableName.Text.Trim(); // получение и обрезка пробелов системного имени таблицы

                if (!IsValidName(tableName)) // проверка корректности системного имени
                {
                    MessageBox.Show("Некорректное имя таблицы"); // сообщение об ошибке
                    return; // выход из метода
                }

                List<string> columnsSql = new List<string>(); // создание списка для sql определений колонок

                foreach (DataGridViewRow row in dgvColumns.Rows) // перебор всех строк таблицы
                {
                    if (row.IsNewRow) continue; // пропуск строки для ввода новой

                    string colName = row.Cells["ColumnName"].Value?.ToString(); // получение имени колонки
                    string colType = row.Cells["ColumnType"].Value?.ToString(); // получение типа данных
                    string colLength = row.Cells["ColumnLength"].Value?.ToString(); // получение длины

                    if (string.IsNullOrWhiteSpace(colName) || !IsValidName(colName)) // проверка имени колонки
                    {
                        MessageBox.Show("Некорректное имя поля"); // сообщение об ошибке
                        return; // выход из метода
                    }

                    if (colType == "INT") // если тип целое число
                    {
                        columnsSql.Add($"{colName} INT"); // добавление определения целочисленной колонки
                    }
                    else if (colType == "VARCHAR") // если тип строка
                    {
                        if (!int.TryParse(colLength, out int len) || len <= 0) // проверка корректности длины
                        {
                            MessageBox.Show($"Неверная длина VARCHAR у поля {colName}"); // сообщение об ошибке
                            return; // выход из метода
                        }

                        columnsSql.Add($"{colName} VARCHAR({len})"); // добавление определения строковой колонки с длиной
                    }
                    else // если тип не выбран
                    {
                        MessageBox.Show($"Не выбран тип данных для поля {colName}"); // сообщение об ошибке
                        return; // выход из метода
                    }
                }

                if (columnsSql.Count == 0) // если не добавлено ни одной колонки
                {
                    MessageBox.Show("Добавьте хотя бы один столбец"); // сообщение об ошибке
                    return; // выход из метода
                }

                // формирование sql запроса для создания таблицы
                string sql = $@"
            CREATE TABLE `{tableName}` (
             id INT PRIMARY KEY AUTO_INCREMENT, // автоматический идентификатор
             model varchar(255) NOT NULL, // поле модели
             produser varchar(255) NOT NULL, // поле производителя
                 {string.Join(",\n    ", columnsSql)}, // пользовательские поля
               inStock int NOT NULL DEFAULT 0, // количество на складе
                image varchar(255) NULL, // путь к изображению
              cost int NOT NULL // стоимость
            );";

                SaveToJSON(); // сохранение информации о таблице в json файл
                ExecuteSql(sql); // выполнение sql запроса
            }
            catch (Exception ex) {  MessageBox.Show($"Ошибка:\n {ex.Message}"); return; }
        }

        // ================= ВЫПОЛНЕНИЕ SQL =================
        private void ExecuteSql(string sql) // метод выполнения sql запроса
        {
            using (MySqlConnection conn = new MySqlConnection(connStr)) // создание подключения к бд
            {
                conn.Open(); // открытие подключения
                using (MySqlCommand cmd = new MySqlCommand(sql, conn)) // создание команды
                {
                    cmd.ExecuteNonQuery(); // выполнение запроса без возврата данных
                }
            }

            MessageBox.Show("Таблица успешно создана"); // сообщение об успешном создании
        }



        private void txtTableName_TextChanged_1(object sender, EventArgs e) // обработчик изменения текста в поле системного имени
        {
            string input = txtTableName.Text; // получение введенного текста

            if (IsValidName(input)) // если имя корректно
            {
                txtTableName.BackColor = Color.FromArgb(77, 150, 125); // зеленый фон
                txtTableName.ForeColor = Color.White; // белый текст
            }
            else // если имя некорректно
            {
                txtTableName.BackColor = Color.Red; // красный фон
                txtTableName.ForeColor = Color.White; // белый текст
            }
        }

        private void txtTableName_Leave(object sender, EventArgs e) // обработчик потери фокуса полем системного имени
        {
            string input = txtTableName.Text; // получение текста

            if (!IsValidName(input)) // если имя некорректно
            {
                MessageBox.Show("Неверное имя! Оно должно начинаться с буквы или '_' и содержать только буквы, цифры и '_'.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTableName.Focus(); // возвращаем фокус в textbox
            }
        }

        private void dgvColumns_CellValueChanged_1(object sender, DataGridViewCellEventArgs e) // обработчик изменения значения ячейки
        {
            if (e.RowIndex < 0) return; // если индекс строки некорректный, выход

            if (dgvColumns.Columns[e.ColumnIndex].Name == "ColumnType") // если изменилась колонка с типом данных
            {
                var row = dgvColumns.Rows[e.RowIndex]; // получение текущей строки
                var type = row.Cells["ColumnType"].Value?.ToString(); // получение выбранного типа

                row.Cells["ColumnLength"].ReadOnly = type != "VARCHAR"; // поле длины доступно только для varchar
                if (type != "VARCHAR") // если тип не varchar
                    row.Cells["ColumnLength"].Value = null; // очистка значения длины
            }
        }

        private void dgvColumns_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) // обработчик отображения элемента редактирования
        {
            if (e.Control is System.Windows.Forms.TextBox tb) // если элемент управления - текстовое поле
            {
                // снимаем все обработчики, чтобы не дублировать
                tb.KeyPress -= ColumnLength_KeyPress;
                tb.KeyPress -= ColumnName_KeyPress;
                tb.KeyPress -= ColumnNameRu_KeyPress;

                string columnName = dgvColumns.CurrentCell.OwningColumn.Name; // получение имени текущей колонки

                if (columnName == "ColumnLength") // если колонка длины
                {
                    tb.MaxLength = 3; // максимальная длина - 3 символа (до 999)
                    tb.KeyPress += ColumnLength_KeyPress; // добавление обработчика для ввода только цифр
                }
                else if (columnName == "ColumnName") // если колонка системного имени
                {
                    tb.MaxLength = 50; // максимальная длина - 50 символов
                    tb.KeyPress += ColumnName_KeyPress; // добавление обработчика для ввода только латиницы и _
                }
                else if (columnName == "ColumnNameRu") // если колонка отображаемого имени
                {
                    tb.MaxLength = 50; // максимальная длина - 50 символов
                    tb.KeyPress += ColumnNameRu_KeyPress; // добавление обработчика для ввода только кириллицы
                }
            }
        }

        private void ColumnLength_KeyPress(object sender, KeyPressEventArgs e) // обработчик ввода в поле длины
        {
            // разрешаем цифры и backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) // если символ не цифра и не backspace
            {
                e.Handled = true; // блокируем ввод
            }
        }

        private void ColumnNameRu_KeyPress(object sender, KeyPressEventArgs e) // обработчик ввода в поле русского имени
        {
            // разрешаем backspace
            if (e.KeyChar == (char)Keys.Back) // если backspace
                return; // разрешаем

            // разрешаем пробел
            if (e.KeyChar == ' ') // если пробел
                return; // разрешаем

            // проверяем, что символ — русская буква (А–Я, а–я, Ё, ё)
            if (!((e.KeyChar >= 'А' && e.KeyChar <= 'Я') ||
                  (e.KeyChar >= 'а' && e.KeyChar <= 'я') ||
                  e.KeyChar == 'Ё' || e.KeyChar == 'ё'))
            {
                e.Handled = true; // запрещаем ввод
            }
        }

        private void ColumnName_KeyPress(object sender, KeyPressEventArgs e) // обработчик ввода в поле системного имени
        {
            // разрешаем backspace
            if (e.KeyChar == (char)Keys.Back) // если backspace
                return; // разрешаем

            // A–Z, a–z, _ (только латиница и нижнее подчеркивание)
            if (!(char.IsLetter(e.KeyChar) && e.KeyChar <= 127) && e.KeyChar != '_') // если не латинская буква и не _
            {
                e.Handled = true; // запрещаем ввод
            }
        }

        private void SaveToJSON() // метод сохранения информации о таблице в json файл
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json"); // формирование пути к json файлу

            // создание json объекта для новой таблицы
            JObject table = new JObject
            {
                ["systemName"] = txtTableName.Text, // системное имя таблицы
                ["displayName"] = txtTableNameRu.Text, // отображаемое имя таблицы
                ["columns"] = new JArray( // массив колонок
                    dgvColumns.Rows
                        .Cast<DataGridViewRow>() // преобразование в IEnumerable
                        .Where(r => !r.IsNewRow) // фильтрация новых строк
                        .Select(r => new JObject // создание json для каждой колонки
                        {
                            ["systemName"] = r.Cells["ColumnName"].Value?.ToString(), // системное имя колонки
                            ["displayName"] = r.Cells["ColumnNameRu"].Value?.ToString() // отображаемое имя колонки
                        })
                )
            };

            JObject root; // корневой json объект
            JArray tables; // массив таблиц

            // если файл существует и не пустой
            if (File.Exists(path) && !string.IsNullOrWhiteSpace(File.ReadAllText(path)))
            {
                root = JObject.Parse(File.ReadAllText(path)); // парсинг существующего json
                tables = root["tables"] as JArray ?? new JArray(); // получение массива таблиц или создание нового
            }
            else // если файла нет или он пустой
            {
                root = new JObject(); // создание нового корневого объекта
                tables = new JArray(); // создание нового массива таблиц
            }

            // добавление новой таблицы
            tables.Add(table); // добавление таблицы в массив
            root["tables"] = tables; // обновление массива в корневом объекте

            // сохранение обратно в файл
            File.WriteAllText(path, root.ToString(Formatting.Indented)); // запись json в файл с форматированием
        }


        private void txtTableNameRu_KeyPress(object sender, KeyPressEventArgs e) // обработчик ввода в поле русского имени таблицы
        {
            char c = e.KeyChar; // получение введенного символа

            // проверяем: русские буквы или пробел
            if (!char.IsControl(c) && !((c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё' || c == ' ')) // если не управляющий символ и не русская буква и не пробел
            {
                e.Handled = true; // блокируем ввод
            }
        }

        private void txtTableNameRu_TextChanged(object sender, EventArgs e) // обработчик изменения текста в поле русского имени
        {
            string input = txtTableNameRu.Text; // получение введенного текста

            if (IsValidNameRu(input)) // если имя корректно
            {
                txtTableNameRu.BackColor = Color.FromArgb(77, 150, 125); // зеленый фон
                txtTableNameRu.ForeColor = Color.White; // белый текст
            }
            else // если имя некорректно
            {
                txtTableNameRu.BackColor = Color.Red; // красный фон
                txtTableNameRu.ForeColor = Color.White; // белый текст
            }
        }

        private bool IsValidNameRu(string name) // метод проверки корректности русского имени
        {
            // проверяем длину
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5) // если имя пустое или меньше 5 символов
                return false; // возвращаем false

            // разрешаем только русские буквы и пробелы, без пробела в начале
            return Regex.IsMatch(name, @"^[А-Яа-яЁё]+(?: [А-Яа-яЁё]+)*$"); // проверка регулярным выражением
        }
    }
}