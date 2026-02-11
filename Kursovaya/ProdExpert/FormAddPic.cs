using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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


// ФОРМА добавления изображений к товарам 


namespace Kursovaya.ProdExpert
{    
    public partial class FormAddPic : Form
    {
        string theme = ""; // переменная темы для понимания с какой категорией товаров работаем
        string connStr = ConnectionString.GetConnectionString();
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
            // настройки дизайна 
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
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
            switch (theme) {
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
            query += ", image ";
            if (theme == "case") { query += "FROM cases "; }
            else { query += $"FROM {theme} "; }
            if(searchTextBox.Text != "")
            {
                query += $"WHERE MODEL LIKE '%{searchTextBox.Text}%' ";
            }
            query += $"LIMIT 10 OFFSET {pageOffset};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query2 = "";
                    conn.Open();
                    if(searchTextBox.Text == "")
                    {
                        query2 = $"SELECT count(*) FROM {theme}";
                    }
                    else
                    {
                        query2 = $"SELECT count(*) FROM {theme} WHERE MODEL LIKE '%{searchTextBox.Text}%'";
                    }
                        MySqlCommand cmd = new MySqlCommand(query2, conn);
                    allPage = Convert.ToInt32(Math.Ceiling((double)Convert.ToInt32(cmd.ExecuteScalar()) / 10));
                }
                if (!dataGridView1.Columns.Contains("ActionColumn"))
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "ActionColumn";
                    buttonColumn.HeaderText = "Добавить изображение";
                    buttonColumn.Text = "Добавить изображение";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Columns.Add(buttonColumn);                    
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].DisplayIndex = 0;
                dataGridView1.Columns["image"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["image"].DisplayIndex = dataGridView1.Columns.Count - 2;
                dataGridView1.Columns["image"].HeaderText = "Изображение";
                dataGridView1.Columns["ActionColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
                
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
            if (dgvPage == 0)
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = false;
            }
            else if (dgvPage == 1 && allPage == 1)
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = false;
            }
            else if (dgvPage == 1 && allPage != 1)
            {
                BackPageButton.Enabled = false;
                ForwardPageButton.Enabled = true;
            }
            else if (dgvPage > 1 && dgvPage < allPage)
            {
                BackPageButton.Enabled = true;
                ForwardPageButton.Enabled = true;
            }
            else if (dgvPage == allPage) {
                ForwardPageButton.Enabled = false;
                BackPageButton.Enabled = true;
            }
            
        }

        // обработчик нажатия на ячейку
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                    openFileDialog.Title = "Выберите изображение";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string picName = System.IO.Path.GetFileNameWithoutExtension(filePath) + System.IO.Path.GetExtension(filePath);                        
                        long fileSize = new System.IO.FileInfo(filePath).Length;
                        if (fileSize > 5 * 1024 * 1024)
                        {
                            MessageBox.Show("Файл слишком большой! Выберите изображение меньше 5 МБ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"pepeShop","img");
                        if (!System.IO.Directory.Exists(imgFolder))
                        {
                            System.IO.Directory.CreateDirectory(imgFolder);
                        }
                        string destPath = System.IO.Path.Combine(imgFolder, System.IO.Path.GetFileName(filePath));
                        System.IO.File.Copy(filePath, destPath, true);


                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();
                            string query = $"UPDATE {theme} SET image = 'img/{picName}' WHERE id = {dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString()};";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Изображение успешно сохранено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillDGV();
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        // обработчик изменения кнопок если картинка для товара уже установлена
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
            {
                string imagePath = dataGridView1.Rows[e.RowIndex]
                    .Cells["image"].Value?.ToString();

                e.Value = string.IsNullOrWhiteSpace(imagePath)
                    ? "Добавить изображение"
                    : "Заменить изображение";
            }
        }
    }
}