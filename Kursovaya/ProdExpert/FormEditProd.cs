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

namespace Kursovaya.ProdExpert
{
    public partial class FormEditProd : Form
    {
        string theme = "";
        string connStr = ConnectionString.GetConnectionString();
        int dgvPage = 0;
        int pageOffset = 0;
        int allPage = 0;
        public FormEditProd()
        {
            InitializeComponent();
            actualPageLabel.Text = dgvPage.ToString();
            allPageLabel.Text = "0";
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

        private void searchTextBox_TextChanged(object sender, EventArgs e)
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
            if (searchTextBox.Text != "")
            {
                query += $"WHERE concat(produser, space(1), model) LIKE '%{searchTextBox.Text}%' ";
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
                }
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query2 = "";
                    conn.Open();
                    if (searchTextBox.Text == "")
                    {
                        query2 = $"SELECT count(*) FROM {theme}";
                    }
                    else
                    {
                        query2 = $"SELECT count(*) FROM {theme} WHERE concat(produser, space(1), model) LIKE '%{searchTextBox.Text}%'";
                    }
                    MySqlCommand cmd = new MySqlCommand(query2, conn);
                    allPage = Convert.ToInt32(Math.Ceiling((double)Convert.ToInt32(cmd.ExecuteScalar()) / 10));
                }
                if (!dataGridView1.Columns.Contains("ActionColumn"))
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "ActionColumn";
                    buttonColumn.HeaderText = "Редактировать";
                    buttonColumn.Text = "Редактировать товар";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.Columns.Add(buttonColumn);
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].DisplayIndex = 0;
                dataGridView1.Columns["ActionColumn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FormEditingProd edit = new FormEditingProd(categoryComboBox.SelectedItem as string, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value));
                edit.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
