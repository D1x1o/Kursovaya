using MySql.Data.MySqlClient;
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

namespace Kursovaya.Administrator
{
    public partial class Prod : Form
    {
        string theme = ""; // объявление переменной для хранения темы/категории
        string connStr = ConnectionString.GetConnectionString(); // получение строки подключения к бд
        int dgvPage = 0; // переменная для хранения текущей страницы dataGridView
        int pageOffset = 0; // смещение для пагинации (сколько записей пропустить)
        int allPage = 0; // общее количество страниц
        
        public Prod() // конструктор формы
        {
            InitializeComponent(); // инициализация компонентов формы
            SetComboBox(); // заполнение выпадающего списка категорий
            CheckButtons(); // проверка состояния кнопок навигации
            dataGridView1.RowHeadersVisible = false; // скрыть заголовки строк
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104); // установка цвета фона таблицы
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104); // цвет фона ячеек
            dataGridView1.DefaultCellStyle.ForeColor = Color.White; // цвет текста в ячейках
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104); // цвет фона заголовков колонок
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // цвет текста заголовков
            dataGridView1.EnableHeadersVisualStyles = false; // отключение визуальных стилей для заголовков
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // выделение всей строки при клике
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125); // цвет выделенной строки
            dataGridView1.ReadOnly = true; // таблица только для чтения
            actualPageLabel.Text = dgvPage.ToString(); // отображение текущей страницы
            allPageLabel.Text = "0"; // начальное значение общего количества страниц
        }
        
        public void SetComboBox() // метод заполнения выпадающего списка
        {
            categoryComboBox.Items.Clear(); // очистка списка
            categoryComboBox.Items.Add("Процессоры"); // добавление категории процессоров
            categoryComboBox.Items.Add("Видеокарты"); // добавление категории видеокарт
            categoryComboBox.Items.Add("Материнские платы"); // добавление категории материнских плат
            categoryComboBox.Items.Add("Оперативная память"); // добавление категории оперативной памяти
            categoryComboBox.Items.Add("Кулеры"); // добавление категории кулеров
            categoryComboBox.Items.Add("Корпусы"); // добавление категории корпусов
            categoryComboBox.Items.Add("Блоки питания"); // добавление категории блоков питания
            categoryComboBox.Items.Add("Корпусные кулеры"); // добавление категории корпусных кулеров
            categoryComboBox.Items.Add("Накопители"); // добавление категории накопителей
            categoryComboBox.Items.Add("Термопаста"); // добавление категории термопасты
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json"); // формирование пути к json файлу
            if (File.Exists(path)) // проверка существования файла
            {
                string json = File.ReadAllText(path); // чтение содержимого json файла
                if (string.IsNullOrWhiteSpace(json)) // проверка на пустоту содержимого
                {
                    // пустой блок для случая пустого json
                }
                else // если json не пустой
                {
                    JObject root = JObject.Parse(json); // парсинг json в объект
                    JArray tables = (JArray)root["tables"]; // получение массива таблиц из json
                    foreach (JObject table in tables) // перебор всех таблиц в json
                    {
                        categoryComboBox.Items.Add(table["displayName"].ToString()); // добавление отображаемого имени в список
                    }
                }
            }
        }
        
        private void fillDGV() // метод заполнения dataGridView данными
        {
            dataGridView1.Columns.Clear(); // очистка колонок таблицы
            theme = categoryComboBox.SelectedItem as string; // получение выбранной категории
            
            switch (theme) // преобразование отображаемого имени в системное
            {
                case "Процессоры": // если выбраны процессоры
                    theme = "processors"; // системное имя для процессоров
                    break;
                case "Видеокарты": // если выбраны видеокарты
                    theme = "videocards"; // системное имя для видеокарт
                    break;
                case "Материнские платы": // если выбраны материнские платы
                    theme = "motherboards"; // системное имя для материнских плат
                    break;
                case "Оперативная память": // если выбрана оперативная память
                    theme = "ram"; // системное имя для оперативной памяти
                    break;
                case "Кулеры": // если выбраны кулеры
                    theme = "cpu_cooler"; // системное имя для кулеров процессора
                    break;
                case "Корпусы": // если выбраны корпусы
                    theme = "cases"; // системное имя для корпусов
                    break;
                case "Блоки питания": // если выбраны блоки питания
                    theme = "power_supplier"; // системное имя для блоков питания
                    break;
                case "Корпусные кулеры": // если выбраны корпусные кулеры
                    theme = "case_coolers"; // системное имя для корпусных кулеров
                    break;
                case "Накопители": // если выбраны накопители
                    theme = "storage"; // системное имя для накопителей
                    break;
                case "Термопаста": // если выбрана термопаста
                    theme = "thermo_interface"; // системное имя для термопасты
                    break;
                default: // для других категорий из json
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json"); // путь к json файлу
                    if (File.Exists(path)) // проверка существования файла
                    {
                        string json = File.ReadAllText(path); // чтение json
                        if (string.IsNullOrWhiteSpace(json)) // проверка на пустоту
                        {
                            // пустой блок
                        }
                        else // если json не пустой
                        {
                            JObject root = JObject.Parse(json); // парсинг json
                            JArray tables = (JArray)root["tables"]; // получение массива таблиц
                            foreach (JObject table in tables) // перебор таблиц
                            {
                                if (table["displayName"].ToString() == theme) // поиск совпадения по отображаемому имени
                                {
                                    theme = table["systemName"].ToString(); // получение системного имени
                                }
                            }
                        }
                    }
                    break;
            }
            
            string query = "SELECT id, "; // начало sql запроса - выбор id
            // формирование части запроса с объединением полей для отображения
            if (theme == "processors") { query += "concat(processors.produser, space(1), processors.model) as Процессоры "; } // для процессоров
            else if (theme == "motherboards") { query += "concat(motherboards.produser, space(1), motherboards.model) as 'Материнские платы' "; } // для мат.плат
            else if (theme == "videocards") { query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as Видеокарты "; } // для видеокарт
            else if (theme == "cpu_cooler") { query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as Кулеры "; } // для кулеров
            else if (theme == "cases") { query += "concat(cases.produser, space(1), cases.model) as Копрусы "; } // для корпусов
            else if (theme == "case_coolers") { query += "concat(case_coolers.produser, space(1), case_coolers.model) as 'Корпусные кулеры' "; } // для корпусных кулеров
            else if (theme == "power_supplier") { query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as 'Блоки питания' "; } // для блоков питания
            else if (theme == "thermo_interface") { query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as Термопаста "; } // для термопасты
            else if (theme == "ram") { query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as 'Оперативная память' "; } // для оперативной памяти
            else if (theme == "storage") { query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as Накопители "; } // для накопителей
            else { query += "concat(produser, space(1), model) as 'Другие категории'"; } // для прочих категорий
            
            if (theme == "case") { query += "FROM cases "; } // особый случай для корпусов (опечатка? должно быть cases)
            else { query += $"FROM {theme} "; } // формирование части from с именем таблицы
            
            if (SearchTextBox.Text != "") // если есть текст в поле поиска
            {
                query += $"WHERE concat(produser, space(1), model) LIKE '%{SearchTextBox.Text}%' "; // добавление условия поиска
            }
            query += $"LIMIT 10 OFFSET {pageOffset};"; // добавление пагинации (10 записей со смещением)

            try // блок обработки исключений
            {
                using (MySqlConnection conn = new MySqlConnection(connStr)) // создание подключения к бд
                {
                    conn.Open(); // открытие подключения
                    MySqlCommand cmd = new MySqlCommand(query, conn); // создание команды с запросом
                    MySqlDataReader reader = cmd.ExecuteReader(); // выполнение запроса и получение reader
                    DataTable dt = new DataTable(); // создание таблицы для данных
                    dt.Load(reader); // загрузка данных из reader в таблицу
                    dataGridView1.DataSource = dt; // установка таблицы как источник данных для dataGridView
                    conn.Close(); // закрытие подключения
                    dataGridView1.Columns["id"].Visible = false; // скрытие колонки с id
                }
                
                using (MySqlConnection conn = new MySqlConnection(connStr)) // второе подключение для подсчета записей
                {
                    string query2 = ""; // объявление переменной для второго запроса
                    conn.Open(); // открытие подключения
                    if (SearchTextBox.Text == "") // если нет поискового запроса
                    {
                        query2 = $"SELECT count(*) FROM {theme}"; // подсчет всех записей в таблице
                    }
                    else // если есть поисковый запрос
                    {
                        query2 = $"SELECT count(*) FROM {theme} WHERE concat(produser, space(1), model) LIKE '%{SearchTextBox.Text}%'"; // подсчет записей по условию поиска
                    }
                    MySqlCommand cmd = new MySqlCommand(query2, conn); // создание команды
                    allPage = Convert.ToInt32(Math.Ceiling((double)Convert.ToInt32(cmd.ExecuteScalar()) / 10)); // расчет количества страниц (общее кол-во / 10, округление вверх)
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); } // обработка ошибок с выводом сообщения
            
            if (dgvPage == 0) // если текущая страница 0
            {
                dgvPage = 1; // установка первой страницы
            }
            actualPageLabel.Text = dgvPage.ToString(); // отображение текущей страницы
            allPageLabel.Text = allPage.ToString(); // отображение общего количества страниц
            CheckButtons(); // проверка состояния кнопок навигации
        }
        
        private void ForwardPageButton_Click(object sender, EventArgs e) // обработчик кнопки "вперед"
        {
            dataGridView1.Columns.Clear(); // очистка колонок таблицы
            pageOffset += 10; // увеличение смещения на 10
            dgvPage += 1; // увеличение номера текущей страницы
            actualPageLabel.Text = dgvPage.ToString(); // обновление отображения номера страницы
            fillDGV(); // повторное заполнение таблицы
        }
        
        private void BackPageButton_Click(object sender, EventArgs e) // обработчик кнопки "назад"
        {
            dataGridView1.Columns.Clear(); // очистка колонок таблицы
            pageOffset -= 10; // уменьшение смещения на 10
            dgvPage -= 1; // уменьшение номера текущей страницы
            actualPageLabel.Text = dgvPage.ToString(); // обновление отображения номера страницы
            fillDGV(); // повторное заполнение таблицы
        }
        
        private void CheckButtons() // метод проверки состояния кнопок навигации
        {
            if (dgvPage == 0) // если текущая страница 0
            {
                BackPageButton.Enabled = false; // отключение кнопки назад
                ForwardPageButton.Enabled = false; // отключение кнопки вперед
            }
            else if (dgvPage == 1 && allPage == 1) // если первая страница и всего одна страница
            {
                BackPageButton.Enabled = false; // отключение кнопки назад
                ForwardPageButton.Enabled = false; // отключение кнопки вперед
            }
            else if (dgvPage == 1 && allPage != 1) // если первая страница, но страниц больше одной
            {
                BackPageButton.Enabled = false; // отключение кнопки назад
                ForwardPageButton.Enabled = true; // включение кнопки вперед
            }
            else if (dgvPage > 1 && dgvPage < allPage) // если страница не первая и не последняя
            {
                BackPageButton.Enabled = true; // включение кнопки назад
                ForwardPageButton.Enabled = true; // включение кнопки вперед
            }
            else if (dgvPage == allPage) // если текущая страница последняя
            {
                ForwardPageButton.Enabled = false; // отключение кнопки вперед
                BackPageButton.Enabled = true; // включение кнопки назад
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e) // обработчик изменения выбранной категории
        {
            SearchTextBox.Enabled = true; // включение поля поиска
            dataGridView1.Columns.Clear(); // очистка колонок таблицы
            SearchTextBox.Text = ""; // очистка поля поиска
            pageOffset = 0; // сброс смещения
            dgvPage = 1; // установка первой страницы
            actualPageLabel.Text = dgvPage.ToString(); // отображение номера страницы
            fillDGV(); // заполнение таблицы данными новой категории
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e) // обработчик изменения текста поиска
        {
            if (dataGridView1 != null) // проверка существования таблицы
            {
                dataGridView1.Columns.Clear(); // очистка колонок таблицы
                pageOffset = 0; // сброс смещения
                dgvPage = 1; // установка первой страницы
                actualPageLabel.Text = dgvPage.ToString(); // отображение номера страницы
                fillDGV(); // заполнение таблицы с учетом поиска
            }
        }
    }
}