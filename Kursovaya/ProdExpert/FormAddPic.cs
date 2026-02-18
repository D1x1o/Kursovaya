using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


// ФОРМА добавления изображений к товарам 
// в комментариях в коду исползуется сокращение 'DGV' что означает DataGridView

namespace Kursovaya.ProdExpert
{    
    public partial class FormAddPic : Form
    {
        string theme = ""; // переменная темы для понимания с какой категорией товаров работаем
        string connStr = ConnectionString.GetConnectionString(); // получаем из класса строку подключения
        int dgvPage = 0; // страница
        int pageOffset = 0; //сколько товаров помещается на странице, 0 - стандартное значение 
        int allPage = 0; // всего страниц, 0 - стандартное значение 
        public FormAddPic()
        {
            InitializeComponent();
            actualPageLabel.Text = dgvPage.ToString();
            allPageLabel.Text = "0"; 
            SetComboBox(); // отображаем в выпадающем списке все категории
            CheckButtons(); // проверяем состояние кнопок
            // настройки дизайна DGV
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
        }

        // отображаем в выпадающем списке все категори
        public void SetComboBox()
        {
            categoryComboBox.Items.Clear();
            categoryComboBox.Items.Add("Процессоры");
            categoryComboBox.Items.Add("Видеокарты");
            categoryComboBox.Items.Add("Материские платы");
            categoryComboBox.Items.Add("Оперативная память");
            categoryComboBox.Items.Add("Кулеры");
            categoryComboBox.Items.Add("Корпусы");
            categoryComboBox.Items.Add("Блоки питания");
            categoryComboBox.Items.Add("Корпусные кулеры");
            categoryComboBox.Items.Add("Накопители");
            categoryComboBox.Items.Add("Термопаста");
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
                        categoryComboBox.Items.Add(table["displayName"].ToString());                        
                    }
                }

            }
        }

        // обработчик ввода в строку поиска
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            pageOffset = 0;
            dgvPage = 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }
        // обработчик выбора элемента в выпадающем списке
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTextBox.Enabled = true;
            dataGridView1.Columns.Clear();
            searchTextBox.Text = "";
            pageOffset = 0;
            dgvPage = 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
            

        }
        // функция отображения данных
        private void fillDGV()
        {
            dataGridView1.Columns.Clear();
            theme = categoryComboBox.SelectedItem as string;
            switch (theme)
            { // формируем запрос к БД
                case "Процессоры":
                    theme = "processors";
                    break;
                case "Видеокарты":
                    theme = "videocards";
                    break;
                case "Материские платы":
                    theme = "motherboards";
                    break;
                case "Оперативная память":
                    theme = "ram";
                    break;
                case "Кулеры":
                    theme = "cpu_cooler";
                    break;
                case "Корпусы":
                    theme = "cases";
                    break;
                case "Блоки питания":
                    theme = "power_supplier";
                    break;
                case "Корпусные кулеры":
                    theme = "case_coolers";
                    break;
                case "Накопители":
                    theme = "storage";
                    break;
                case "Термопаста":
                    theme = "thermo_interface";
                    break;
                default:
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
                               if (table["displayName"].ToString() == theme)
                               {
                                    theme = table["systemName"].ToString();
                                    
                               }
                            }
                        }
                    }
                    break;
            }
            string query = "SELECT id, ";
            if (theme == "processors") { query += "concat(processors.produser, space(1), processors.model) as Процессоры "; }
            else if (theme == "motherboards") { query += "concat(motherboards.produser, space(1), motherboards.model) as 'Материнские платы' "; }
            else if (theme == "videocards") { query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as Видеокарты "; }
            else if (theme == "cpu_cooler") { query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as Кулеры "; }
            else if (theme == "cases") { query += "concat(cases.produser, space(1), cases.model) as Копрусы "; }
            else if (theme == "case_coolers") { query += "concat(case_coolers.produser, space(1), case_coolers.model) as 'Корпусные кулеры' "; }
            else if (theme == "power_supplier") { query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as 'Блоки питания' "; }
            else if (theme == "thermo_interface") { query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as Термопаста "; }
            else if (theme == "ram") { query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as 'Оперативная память' "; }
            else if (theme == "storage") { query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as Накопители "; }
            else { query += "concat(produser, space(1), model) as 'Другие категории'"; }
            query += ", image ";
            if (theme == "case") { query += "FROM cases "; }
            else { query += $"FROM {theme} "; }
            if(searchTextBox.Text != "") // если есть условие поиска по наименованию применяем его к запросу
            {
                query += $"WHERE concat(produser, space(1), model) LIKE '%{searchTextBox.Text}%' ";
            }
            query += $"LIMIT 10 OFFSET {pageOffset};"; // ограничиваем количество записей на одной странице 

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr)) // выполняем запрос
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt; // отображаем полученные данные на DGV 
                    conn.Close();
                }
                using (MySqlConnection conn = new MySqlConnection(connStr)) // запрос на получение количеста товаров по условиям
                {
                    string query2 = "";
                    conn.Open();
                    if(searchTextBox.Text == "")
                    {
                        query2 = $"SELECT count(*) FROM {theme}";
                    }
                    else
                    {
                        query2 = $"SELECT count(*) FROM {theme} WHERE concat(produser, space(1), model) LIKE '%{searchTextBox.Text}%'"; // если есть условие поиска по наименованию применяем его к запросу
                    }
                        MySqlCommand cmd = new MySqlCommand(query2, conn);
                    allPage = Convert.ToInt32(Math.Ceiling((double)Convert.ToInt32(cmd.ExecuteScalar()) / 10)); // считаем количестов страниц исходя из количества полученных товаров
                }
                if (!dataGridView1.Columns.Contains("ActionColumn")) // добавляем в DGV кнопку добавления изображения
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "ActionColumn";
                    buttonColumn.HeaderText = "Добавить изображение";
                    buttonColumn.Text = "Добавить изображение";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Columns.Add(buttonColumn);                    
                }
                dataGridView1.Columns["id"].Visible = false; // скрываем столбец айди
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // устанавиваем для столбца ширину
                dataGridView1.Columns[1].DisplayIndex = 0; // указываем каким по счету будет столбец
                dataGridView1.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //устанавиваем для столбца ширину
                dataGridView1.Columns["image"].DisplayIndex = dataGridView1.Columns.Count - 2;// указываем каким по счету будет столбец
                dataGridView1.Columns["image"].HeaderText = "Изображение"; // имя столбца
                dataGridView1.Columns["ActionColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; //устанавиваем для столбца ширину
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;// указываем каким по счету будет столбец

            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            if(dgvPage == 0)
            {
                dgvPage = 1;
            }
            actualPageLabel.Text = dgvPage.ToString();
            allPageLabel.Text = allPage.ToString();
            CheckButtons();
        }




        // обработчик перелистывания страницы вперёд
        private void ForwardPageButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            pageOffset += 10;
            dgvPage += 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }
        // обработчик перелистывания страницы назад
        private void BackPageButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            pageOffset -= 10;
            dgvPage -= 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }
        // функция проверки состояния кнопок перелистывания страниц
        private void CheckButtons() 
        {
            if (dgvPage == 0) // если одна страница запрещаем листать в принципе
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = false;
            }
            else if (dgvPage == 1 && allPage == 1) // если одна страница запрещаем листать в принципе
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = false;
            }
            else if (dgvPage == 1 && allPage != 1) // если на первой странице запрещаем листать назад
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = true;
            }
            else if (dgvPage > 1 && dgvPage < allPage) // если на n-ой странице и страниц больше чем та на которой мы находимся разрешаем листать и вперёд и назад
            {
                BackPageButton.Enabled = true;
                ForwardPageButton.Enabled = true;
            }
            else if (dgvPage == allPage) { // если на последней странице запрещаем листать вперёд, но разрешаем назад
                ForwardPageButton.Enabled = false;
                BackPageButton.Enabled = true;
            }
            
        }

        // обработчик нажатия на ячейку
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // если нажата кнопка в datagridview 
                if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog(); // открываем диалог выбора файла
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;"; // задаем фильтр для выбора только изображений
                    openFileDialog.Title = "Выберите изображение"; // имя окна

                    if (openFileDialog.ShowDialog() == DialogResult.OK) // если изображение было выбрано
                    {
                        // путь+имя выбранноко файл
                        string filePath = openFileDialog.FileName;

                        // Получаем расширение файла
                        string extension = Path.GetExtension(filePath);

                        // Генерируем уникальное имя
                        string uniqueName = Guid.NewGuid().ToString() + extension;

                        // здесь проверяем что изображение имеет вес менее 5Мб
                        long fileSize = new FileInfo(filePath).Length;
                        if (fileSize > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Файл слишком большой! Выберите изображение меньше 5 МБ.",
                                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // если файл больше 5МБ отображаем ошибку и выходим из функции
                        }

                        string imgFolder = Path.Combine( //получаем путь до нашей папки в AppData
                            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            "pepeShop",
                            "img"
                        );

                        if (!Directory.Exists(imgFolder))
                            Directory.CreateDirectory(imgFolder); // если папки нет в AppData создаём

                        string destPath = Path.Combine(imgFolder, uniqueName); // получаем путь куда нужно поместить новое изображение (в нашу папку в AppData)

                        File.Copy(filePath, destPath, true); // копируем выбранное пользователем изображение в нашу папку в AppData

                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();

                            string query = $"UPDATE {theme} SET image = 'img/{uniqueName}' WHERE id = @id;";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                            cmd.ExecuteNonQuery(); // запрос на добавление к товару относительного пути к его изобажению
                        }

                        MessageBox.Show("Изображение успешно сохранено",
                                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                        fillDGV(); //перезагружаем DGV
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // обработчик ошибок
            }
        }

        // обработчик изменения кнопок если картинка для товара уже установлена
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
            {
                string imagePath = dataGridView1.Rows[e.RowIndex]
                    .Cells["image"].Value?.ToString();

                e.Value = string.IsNullOrWhiteSpace(imagePath)
                    ? "Добавить изображение" // если нет у товара изображения кнопка будет с текстом "Добавить изображение"
                    : "Заменить изображение"; // если есть изображение текст кнопки "Заменить изображение"
            }
        }
        int rowIndexforDeleting = -1;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["image"].Value.ToString() == "" && String.IsNullOrWhiteSpace(dataGridView1.Rows[e.RowIndex].Cells["image"].Value.ToString()))
            {
                deletePicButton.Enabled = false;
            }
            else { deletePicButton.Enabled = true; rowIndexforDeleting = e.RowIndex; }
        }

        private void deletePicButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (rowIndexforDeleting < 0) { return; }
                DialogResult DR = MessageBox.Show($"Вы действительно хотите удалить изображение у {dataGridView1.Rows[rowIndexforDeleting].Cells[1].Value.ToString()}", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = $"UPDATE {theme} SET image = '' WHERE id = {Convert.ToInt32(dataGridView1.Rows[rowIndexforDeleting].Cells["id"].Value)};";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        int editRows = cmd.ExecuteNonQuery();
                        if (editRows > 0)
                        {
                            MessageBox.Show("Изображение удалено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fillDGV();
                        }
                        else { MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); fillDGV(); }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}