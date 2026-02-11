using Kursovaya.Administrator;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.ProdExpert
{
    public partial class FormWriteOff : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        int ProdInStockLocal = 0;
        int idLocal = 0;
        string table = "";
        public FormWriteOff(int prodId, string parentTable, string model, int prodInStock)
        {            
            idLocal = prodId;
            table = parentTable;
            InitializeComponent();
            ProdInStockLocal = prodInStock;
            CheckButtons();
            itemNameLabel.Text = model;
        }
        private void IncButton_Click(object sender, EventArgs e)
        {
            int Amount = Convert.ToInt32(AmountTextBox.Text.Trim());
            AmountTextBox.Text = (Amount+1).ToString();
            CheckButtons();
        }
        private void CheckButtons()
        {
            int Amount = Convert.ToInt32(AmountTextBox.Text.Trim());
            if (Amount <= 1)
            {
                DecButton.Enabled = false;
            }
            if (Amount > 1)
            {
                DecButton.Enabled = true;
            }
            if (Amount >= 998)
            {
                IncButton.Enabled = false;
            }
            if (Amount <= 998)
            {
                IncButton.Enabled = true;
            }
        }
        private void DecButton_Click(object sender, EventArgs e)
        {
            int Amount = Convert.ToInt32(AmountTextBox.Text.Trim());            
            AmountTextBox.Text = (Amount-1).ToString();
            CheckButtons();
        }

        private void AmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                return;
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Amount = Convert.ToInt32(AmountTextBox.Text.Trim());
            if (Amount > 999)
            {
                MessageBox.Show("Нельзя списать более 999 товаров за раз!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AmountTextBox.Text = "1";
                return;
            }
            if (Amount == 0)
            {
                MessageBox.Show("Нельзя списать 0 товаров!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AmountTextBox.Text = "1";
                return;
            }
            if(Amount > ProdInStockLocal)
            {
                MessageBox.Show("Нельзя списать товаров больше чем есть на складе!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AmountTextBox.Text = "1";
                return;
            }
            DialogResult DR = MessageBox.Show($"Вы действительно хотите списать {Amount} товара(ов)?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = $"UPDATE {table} SET inStock = {ProdInStockLocal - Amount} WHERE id = {idLocal};";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int res = cmd.ExecuteNonQuery();
                    if(res == 1)
                    {
                        MessageBox.Show("Товар списан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Товары списаны!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }            
        }
    }
}
