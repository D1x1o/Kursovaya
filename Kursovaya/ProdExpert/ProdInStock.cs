using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.ProdExpert
{
    public partial class ProdInStock : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public ProdInStock()
        {
            InitializeComponent();
            fillCombobox();
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
        class Category
        {
            public string SystemName { get; set; }
            public string DisplayName { get; set; }
        }
        public void fillCombobox()
        {
            try
            {
                var categories = new List<Category>
                {
                    new Category { SystemName = "=", DisplayName = "Равно" },
                    new Category { SystemName = ">", DisplayName = "Более" },
                    new Category { SystemName = "<", DisplayName = "Менее" }
                };
                SignComboBox.Items.Clear();
                SignComboBox.DataSource = null;
                SignComboBox.DisplayMember = "DisplayName";
                SignComboBox.ValueMember = "SystemName";
                SignComboBox.DataSource = categories;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void fillDgv() 
        {
            string query = $@"SELECT * FROM (SELECT id, model, inStock, 'processors'   AS SourceTable FROM processors
UNION ALL SELECT id, model, inStock, 'videocards'       FROM videocards
UNION ALL SELECT id, model, inStock, 'thermo_interface' FROM thermo_interface
UNION ALL SELECT id, model, inStock, 'ram'              FROM ram
UNION ALL SELECT id, model, inStock, 'power_supplier'   FROM power_supplier
UNION ALL SELECT id, model, inStock, 'motherboards'     FROM motherboards
UNION ALL SELECT id, model, inStock, 'cpu_cooler'        FROM cpu_cooler
UNION ALL SELECT id, model, inStock, 'cases'             FROM cases
UNION ALL SELECT id, model, inStock, 'case_coolers'       FROM case_coolers
UNION ALL SELECT id, model, inStock, 'storage'            FROM storage";

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
                        string SystemName = table["systemName"].ToString();
                        query += $"UNION ALL SELECT model, inStock FROM {SystemName} ";
                    }
                }

            }
            query += ") as products ";
            if (SearchTextBox.Text == "" && AmountTextBox.Text != "")
            {
                query += $"Where inStock {SignComboBox.SelectedValue.ToString()} {Convert.ToInt32(AmountTextBox.Text.Trim())} ";
            }
            else if (SearchTextBox.Text != "" && AmountTextBox.Text == "")
            {
                query += $"Where model like '%{SearchTextBox.Text.Trim()}%' ";
            }
            else if (SearchTextBox.Text != "" && AmountTextBox.Text != "")
            {
                query += $"Where model like '%{SearchTextBox.Text.Trim()}%' and inStock {SignComboBox.SelectedValue.ToString()} {Convert.ToInt32(AmountTextBox.Text.Trim())}  ";
            }
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }

            dataGridView1.Columns["model"].HeaderText = "Наименование";
            dataGridView1.Columns["inStock"].HeaderText = "Количество";
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["SourceTable"].Visible = false;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void AmountTextBox_TextChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int prodId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
            string parentTable = dataGridView1.Rows[e.RowIndex].Cells["SourceTable"].Value.ToString();
            string model = dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();
            int prodInStock = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["inStock"].Value);
            FormWriteOff FWO = new FormWriteOff(prodId, parentTable, model, prodInStock);
            this.Hide();
            FWO.ShowDialog();
            this.Show();
            fillDgv();
        }

        private void SignComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDgv();
        }
    }    
}
