using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya.User
{
    public partial class UserProduct : Form
    {
        string ConnStr = ConnectionString.GetConnectionString();
        string theme = "processors";
        public UserProduct()
        {
            InitializeComponent();
            FillSortCombobox();
            FillFilterCombobox("processors");
            FillThemeDataGridView("", $"{theme}", "Не выбрано", "По убыванию");
            
        }

        private void ShowCart_Click(object sender, EventArgs e)
        {
            UserCart prod = new UserCart();
            Hide();
            prod.ShowDialog();
            Show();
        }

       
        private void FillFilterCombobox(string theme)
        {
            if(theme == "processors")
            {
                filterLabel.Text = "Количество ядер";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 4");
                FilterComboBox.Items.Add("4");
                FilterComboBox.Items.Add("6");
                FilterComboBox.Items.Add("8");
                FilterComboBox.Items.Add("> 8");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "case")
            {
                filterLabel.Text = "Размер";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("Mini-ITX");
                FilterComboBox.Items.Add("mATX");
                FilterComboBox.Items.Add("ATX");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "case_coolers")
            {
                filterLabel.Text = "Диаметр кулера";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("140");
                FilterComboBox.Items.Add("120");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "cpu_cooler")
            {
                filterLabel.Text = "Диаметр кулера";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 150");
                FilterComboBox.Items.Add("150");
                FilterComboBox.Items.Add("160");
                FilterComboBox.Items.Add("165");
                FilterComboBox.Items.Add("170");
                FilterComboBox.Items.Add("180");
                FilterComboBox.Items.Add("190");
                FilterComboBox.Items.Add("200");
                FilterComboBox.Items.Add("> 200");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "motherboards")
            {
                filterLabel.Text = "Сокет";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("AM4");
                FilterComboBox.Items.Add("AM5");
                FilterComboBox.Items.Add("LGA1200");
                FilterComboBox.Items.Add("LGA1700");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "power_supplier")
            {
                filterLabel.Text = "Мощность в ваттах";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 750");
                FilterComboBox.Items.Add("750");
                FilterComboBox.Items.Add("850");
                FilterComboBox.Items.Add("1000");
                FilterComboBox.Items.Add("> 1000");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "ram")
            {
                filterLabel.Text = "Объём памяти";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 16");
                FilterComboBox.Items.Add("16");
                FilterComboBox.Items.Add("32");
                FilterComboBox.Items.Add("> 32");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "storage")
            {
                filterLabel.Text = "Объём памяти";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("500");
                FilterComboBox.Items.Add("1000");
                FilterComboBox.Items.Add("2000");
                FilterComboBox.Items.Add("4000");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "thermo_interface")
            {
                filterLabel.Text = "Теплопроводность";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 6.50");
                FilterComboBox.Items.Add("6.50");
                FilterComboBox.Items.Add("7.50");
                FilterComboBox.Items.Add("8.50");
                FilterComboBox.Items.Add("> 8.50");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
            else if (theme == "videocards")
            {
                filterLabel.Text = "Кол-во гб видеопамяти";
                FilterComboBox.Items.Clear();
                FilterComboBox.Items.Add("Не выбрано");
                FilterComboBox.Items.Add("< 4");
                FilterComboBox.Items.Add("4");
                FilterComboBox.Items.Add("8");
                FilterComboBox.Items.Add("12");
                FilterComboBox.Items.Add("16");
                FilterComboBox.Items.Add("> 16");
                FilterComboBox.SelectedItem = "Не выбрано";
            }
        }
        private void FillSortCombobox()
        {
            SortComboBox.Items.Add("По убыванию");
            SortComboBox.Items.Add("По возрастанию");
            SortComboBox.SelectedItem = "По убыванию";
        }

        private void FillThemeDataGridView(string search, string theme, string Filter, string Sorting)
        {
            string query = "SELECT * FROM ";
            //понимаем что ищет клиент
            if(theme == "processors") { query += "processors"; }
            else if(theme == "case") { query += "cursovaya.case"; }
            else if (theme == "case_coolers") { query += "case_coolers"; }
            else if (theme == "cpu_coolers") { query += "cpu_cooler"; }
            else if (theme == "motherboards") { query += "motherboards"; }
            else if (theme == "power_supplier") { query += "power_supplier"; }
            else if (theme == "ram") { query += "ram"; }
            else if (theme == "storage") { query += "storage"; }
            else if (theme == "thermo_interface") { query += "thermo_interface"; }
            else if (theme == "videocards") { query += "videocards"; }
            //поиск по имени
            query += " ";
            if (search == "") { query += $"WHERE model LIKE '% %'"; }
            else { query += $"WHERE model LIKE '%{search}%'"; }
            //фильтрация
            query += " ";
            if (Filter != "Не выбрано") { query += " ";
                if (theme == "processors") { query += "&& core_int"; }
                else if (theme == "case") { query += "&& form_factor"; }
                else if (theme == "case_coolers") { query += "&& scale"; }
                else if (theme == "cpu_cooler") { query += "&& max_heat_sink"; }
                else if (theme == "motherboards") { query += "&& cpu_socket"; }
                else if (theme == "power_supplier") { query += "&& power"; }
                else if (theme == "ram") { query += "&& capacity_gb"; }
                else if (theme == "storage") { query += "&& capacity_gb"; }
                else if (theme == "thermo_interface") { query += "&& thermal_conductivity"; }
                else if (theme == "videocards") { query += "&& memory"; }
                if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                else { query += $" = '{Filter}'"; }                
            }
            
            if(SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost ASC;"; }
            else { query += " ORDER BY cost DESC;"; }


            try
            {
                using(MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void ShowProc_Click(object sender, EventArgs e)
        {
            theme = "processors";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";

            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillThemeDataGridView(SearchTextBox.Text, theme, FilterComboBox.SelectedItem.ToString(), SortComboBox.SelectedItem.ToString());
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";

            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void SortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";

            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }


















        //кнопки
        private void ShowVideoCards_Click(object sender, EventArgs e)
        {
            theme = "videocards";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowMotherBoard_Click(object sender, EventArgs e)
        {
            theme = "motherboards";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowRam_Click(object sender, EventArgs e)
        {
            theme = "ram";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowDrivers_Click(object sender, EventArgs e)
        {
            theme = "storage";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowPowerSuplier_Click(object sender, EventArgs e)
        {
            theme = "power_supplier";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowCases_Click(object sender, EventArgs e)
        {
            theme = "case";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowCaseFan_Click(object sender, EventArgs e)
        {
            theme = "case_coolers";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowCpuFan_Click(object sender, EventArgs e)
        {
            theme = "cpu_coolers";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void ShowTermo_Click(object sender, EventArgs e)
        {
            theme = "thermo_interface";
            string sortValue = SortComboBox.SelectedItem?.ToString() ?? "По убыванию";
            string filterValue = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            HideAndRemaneColunms();
            FillThemeDataGridView(SearchTextBox.Text, theme, filterValue, sortValue);
        }

        private void HideAndRemaneColunms()
        {
            if (theme == "processors") { FillFilterCombobox("processors"); }
            else if (theme == "case") { FillFilterCombobox("case"); }
            else if (theme == "case_coolers") { FillFilterCombobox("case_coolers"); }
            else if (theme == "cpu_cooler") { FillFilterCombobox("cpu_cooler"); }
            else if (theme == "motherboards") { FillFilterCombobox("motherboards"); }
            else if (theme == "power_supplier") { FillFilterCombobox("power_supplier"); }
            else if (theme == "ram") { FillFilterCombobox("ram"); }
            else if (theme == "storage") { FillFilterCombobox("storage"); }
            else if (theme == "thermo_interface") { FillFilterCombobox("thermo_interface"); }
            else if (theme == "videocards") { FillFilterCombobox("videocards"); }

        }
    }
}
