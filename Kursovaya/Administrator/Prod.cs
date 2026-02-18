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
        string theme = "";
        string connStr = ConnectionString.GetConnectionString();
        int dgvPage = 0;
        int pageOffset = 0;
        int allPage = 0;
        public Prod()
        {
            InitializeComponent();
            SetComboBox();
            CheckButtons();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.ReadOnly = true;
            actualPageLabel.Text = dgvPage.ToString();
            allPageLabel.Text = "0";
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
        private void fillDGV()
        {
            dataGridView1.Columns.Clear();
            theme = categoryComboBox.SelectedItem as string;
            switch (theme)
            {
                case "Процессоры":
                    theme = "processors";
                    break;
                case "Видеокарты":
                    theme = "videocards";
                    break;
                case "Материнские платы":
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
            if (theme == "case") { query += "FROM cases "; }
            else { query += $"FROM {theme} "; }
            if (SearchTextBox.Text != "")
            {
                query += $"WHERE concat(produser, space(1), model) LIKE '%{SearchTextBox.Text}%' ";
            }
            query += $"LIMIT 10 OFFSET {pageOffset};";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                    dataGridView1.Columns["id"].Visible = false;
                }
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query2 = "";
                    conn.Open();
                    if (SearchTextBox.Text == "")
                    {
                        query2 = $"SELECT count(*) FROM {theme}";
                    }
                    else
                    {
                        query2 = $"SELECT count(*) FROM {theme} WHERE concat(produser, space(1), model) LIKE '%{SearchTextBox.Text}%'";
                    }
                    MySqlCommand cmd = new MySqlCommand(query2, conn);
                    allPage = Convert.ToInt32(Math.Ceiling((double)Convert.ToInt32(cmd.ExecuteScalar()) / 10));
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            if (dgvPage == 0)
            {
                dgvPage = 1;
            }
            actualPageLabel.Text = dgvPage.ToString();
            allPageLabel.Text = allPage.ToString();
            CheckButtons();
        }
        private void ForwardPageButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            pageOffset += 10;
            dgvPage += 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }
        private void BackPageButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            pageOffset -= 10;
            dgvPage -= 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }
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
            else if (dgvPage == allPage)
            {
                ForwardPageButton.Enabled = false;
                BackPageButton.Enabled = true;
            }

        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchTextBox.Enabled = true;
            dataGridView1.Columns.Clear();
            SearchTextBox.Text = "";
            pageOffset = 0;
            dgvPage = 1;
            actualPageLabel.Text = dgvPage.ToString();
            fillDGV();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1 != null)
            {
                dataGridView1.Columns.Clear();
                pageOffset = 0;
                dgvPage = 1;
                actualPageLabel.Text = dgvPage.ToString();
                fillDGV();
            }
        }
    }
}        