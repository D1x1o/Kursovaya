using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.User
{
    public partial class UserProduct : Form
    {
        Dictionary<string, bool> ArrChecked = new Dictionary<string, bool> {
           {"processors", false},
           {"videocards", false},
           {"motherboards", false},
           {"ram", false},
           {"storage", false},
           {"power_supplier", false},
           {"cases", false},
           {"case_coolers", false},
           {"cpu_cooler", false},
           {"thermo_interface", false},
           {"case", false}

        };
        int userid = user.Default.userID;
        string ConnStr = ConnectionString.GetConnectionString();
        string theme = "processors";
        public UserProduct()
        {
            InitializeComponent();
            FillSortCombobox();
            FillFilterCombobox("processors");
            //FillThemeDataGridView("", $"{theme}", "Не выбрано", "По убыванию");            
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
            if (theme == "processors")
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
                filterLabel.Text = "Отводимость тепла";
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
            // Получаем готовый запрос из fillDgv
            string query = fillDgv(theme);
            //MessageBox.Show(query);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Добавляем кнопку "Добавить", если ещё нет
            if (!dataGridView1.Columns.Contains("ActionColumn"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "ActionColumn";
                buttonColumn.HeaderText = "Добавить";
                buttonColumn.Text = "Добавить";
                buttonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Add(buttonColumn);
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.Columns.Count - 1;
            }

            // Настройка столбцов
            Columns();
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
        private void ShowProc_Click(object sender, EventArgs e) { changeTheme("processors"); }
        private void ShowVideoCards_Click(object sender, EventArgs e) { changeTheme("videocards"); }
        private void ShowMotherBoard_Click(object sender, EventArgs e) { changeTheme("motherboards"); }
        private void ShowRam_Click(object sender, EventArgs e)
        {
            changeTheme("ram");
        }
        private void ShowDrivers_Click(object sender, EventArgs e) { changeTheme("storage"); }
        private void ShowPowerSuplier_Click(object sender, EventArgs e) { changeTheme("power_supplier"); }
        private void ShowCases_Click(object sender, EventArgs e) { changeTheme("case"); }
        private void ShowCaseFan_Click(object sender, EventArgs e) { changeTheme("case_coolers"); }
        private void ShowCpuFan_Click(object sender, EventArgs e) { changeTheme("cpu_cooler"); }
        private void ShowTermo_Click(object sender, EventArgs e) { changeTheme("thermo_interface"); }
        private void changeTheme(string buttonTheme)
        {
            theme = buttonTheme;
            SearchTextBox.Text = "";
            string sortValue = "По убыванию";
            string filterValue = "Не выбрано";
            dataGridView1.Columns.Remove("ActionColumn");
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

        private void Columns()
        {
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["cost"].HeaderText = "Стоимость";
            if (theme == "processors")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["socket"].HeaderText = "Сокет";
                dataGridView1.Columns["frequency"].HeaderText = "Частота";
                dataGridView1.Columns["architecture"].Visible = false;
                dataGridView1.Columns["core_int"].HeaderText = "Кол-во ядер";
                dataGridView1.Columns["L3_caсhe"].Visible = false;
                dataGridView1.Columns["thermal_power"].Visible = false;
            }
            else if (theme == "videocards")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Произв.";
                dataGridView1.Columns["memory"].HeaderText = "Память";
                dataGridView1.Columns["memory_type"].HeaderText = "Тип памяти";
                dataGridView1.Columns["bus_width"].Visible = false;
                dataGridView1.Columns["interface"].Visible = false;
                dataGridView1.Columns["vender"].HeaderText = "Вендер";
                dataGridView1.Columns["vender"].DisplayIndex = 1;
                dataGridView1.Columns["gpu_lenght"].HeaderText = "Длинна корпуса";
                dataGridView1.Columns["gpu_lenght"].DisplayIndex = 8;
                dataGridView1.Columns["power_consumption"].HeaderText = "Потребление";
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
            else if (theme == "motherboards")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Произв.";
                dataGridView1.Columns["form_factor"].HeaderText = "Размер";
                dataGridView1.Columns["ram_support_type"].HeaderText = "Тип памяти";
                dataGridView1.Columns["ram_slots"].HeaderText = "Кол-во слотов опер. памяти";
                dataGridView1.Columns["cpu_socket"].HeaderText = "Сокет";
                dataGridView1.Columns["m2_ssd_slots"].Visible = false;
                dataGridView1.Columns["ram_max_capacity"].Visible = false;
                dataGridView1.Columns["chipset"].Visible = false;
                dataGridView1.Columns["expansion_type"].Visible = false;
                dataGridView1.Columns["expansion_slots"].Visible = false;
            }
            else if (theme == "ram")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["capacity_gb"].HeaderText = "Объём";
                dataGridView1.Columns["ram_type"].HeaderText = "Тип памяти";
                dataGridView1.Columns["speed_mhz"].HeaderText = "Скорость";
            }
            else if (theme == "storage")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["type_of_device"].HeaderText = "Тип устройства";
                dataGridView1.Columns["capacity_gb"].HeaderText = "Объём";
                dataGridView1.Columns["interface"].HeaderText = "Интерфейс";
                dataGridView1.Columns["write_speed"].Visible = false;
                dataGridView1.Columns["read_speed"].Visible = false;
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
            else if (theme == "power_supplier")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["power"].HeaderText = "Мощность";
                dataGridView1.Columns["certificate"].HeaderText = "Сертификат";
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;

            }
            else if (theme == "case_coolers")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["scale"].HeaderText = "Размер";
                dataGridView1.Columns["light"].HeaderText = "Подсветка";
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
            else if (theme == "case")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["form_factor"].HeaderText = "Форм фактор";
                dataGridView1.Columns["color"].HeaderText = "Цвет";
                dataGridView1.Columns["max_lenght_videocard"].HeaderText = "Макс. длинна видеокарты";
                dataGridView1.Columns["max_height_cpu_cooler"].HeaderText = "Макс. высота кулера";
                dataGridView1.Columns["storage_slots"].Visible = false;
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
            else if (theme == "cpu_cooler")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["socket"].HeaderText = "Сокет";
                dataGridView1.Columns["light_type"].HeaderText = "Подсветка";
                dataGridView1.Columns["cooler_height"].HeaderText = "Высота";
                dataGridView1.Columns["max_heat_sink"].HeaderText = "Макс. рассеивание тепла";
                dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
                dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
            }
            else if (theme == "thermo_interface")
            {
                dataGridView1.Columns["model"].HeaderText = "Модель";
                dataGridView1.Columns["produser"].HeaderText = "Производитель";
                dataGridView1.Columns["thermal_conductivity"].HeaderText = "Коэффициент теплопроводности";
                dataGridView1.Columns["packege_volume"].HeaderText = "Объём упаковки";
                dataGridView1.Columns["shel_life"].HeaderText = "Срок годности  ";
                dataGridView1.Columns["composition"].HeaderText = "Состав";
            }

            dataGridView1.Columns["cost"].DisplayIndex = dataGridView1.ColumnCount - 2;
            dataGridView1.Columns["ActionColumn"].DisplayIndex = dataGridView1.ColumnCount - 1;
        }

        private void addIntoCart(string itemTheme, string itemID, int userID)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    string query = "";
                    if (itemTheme == "case")
                    {
                        query = $"INSERT INTO user_cart (iduser, id_cases) VALUES ({userID}, {itemID}) ON DUPLICATE KEY UPDATE id_cases = {itemID};";
                    }
                    else
                    {
                        query = $"INSERT INTO user_cart (iduser, id_{itemTheme}) VALUES ({userID}, {itemID}) ON DUPLICATE KEY UPDATE id_{itemTheme} = {itemID};";
                    }
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void buttonsColor(string theme)
        {
            if (theme == "processors") { ShowProc.ForeColor = Color.Green; ShowProc.Text = "Процессоры✔"; }
            else if (theme == "videocards") { ShowVideoCards.ForeColor = Color.Green; ShowVideoCards.Text = "Видеокарты✔"; }
            else if (theme == "motherboards") { ShowMotherBoard.ForeColor = Color.Green; ShowMotherBoard.Text = "Материнские платы✔"; }
            else if (theme == "ram") { ShowRam.ForeColor = Color.Green; ShowRam.Text = "Оперативная память✔"; }
            else if (theme == "storage") { ShowDrivers.ForeColor = Color.Green; ShowDrivers.Text = "Накопители✔"; }
            else if (theme == "power_supplier") { ShowPowerSuplier.ForeColor = Color.Green; ShowPowerSuplier.Text = "Блоки питания✔"; }
            else if (theme == "case_coolers") { ShowCaseFan.ForeColor = Color.Green; ShowCaseFan.Text = "Корпусные кулеры✔"; }
            else if (theme == "case") { ShowCases.ForeColor = Color.Green; ShowCases.Text = "Корпусы✔"; }
            else if (theme == "cpu_cooler") { ShowCpuFan.ForeColor = Color.Green; ShowCpuFan.Text = "Кулеры✔"; }
            else if (theme == "thermo_interface") { ShowTermo.ForeColor = Color.Green; ShowTermo.Text = "Термопаста✔"; }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
            {
                buttonsColor(theme);
                addIntoCart(theme, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), user.Default.userID);
                if (theme == "case")
                {
                    ArrChecked["cases"] = true;
                }
                else
                {
                    ArrChecked[theme] = true;
                }
                //string msg = "";
                //foreach (var dic in ArrChecked)
                //{
                //    msg += $"Ключ: {dic.Key} - Значение: {dic.Value};\n";
                //}
                //MessageBox.Show(msg);







            }
        }

        ////Кнопка добавления товара в сборку
        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if(e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "ActionColumn")
        //    {
        //        //MessageBox.Show($"{dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()}");
        //        if(theme == "processors")
        //        {
        //            string query = "insert into config";
        //        }
        //    }
        //}

        private string fillDgv(string theme)
        {
            string Filter = FilterComboBox.SelectedItem?.ToString() ?? "Не выбрано";
            string search = SearchTextBox.Text;
            string query = "";
            if (ArrChecked[theme])
            {
                query = $"SELECT * FROM {theme}";
                if (!string.IsNullOrEmpty(search))
                {
                    query += $" WHERE model LIKE '%{search}%'";
                }
                if (Filter != "Не выбрано")
                {
                    query += " ";
                    if (theme == "processors") { query += "  core_int"; }
                    else if (theme == "case") { query += "  form_factor"; }
                    else if (theme == "case_coolers") { query += "  scale"; }
                    else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                    else if (theme == "motherboards") { query += "  cpu_socket"; }
                    else if (theme == "power_supplier") { query += "  power"; }
                    else if (theme == "ram") { query += "  capacity_gb"; }
                    else if (theme == "storage") { query += "  capacity_gb"; }
                    else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                    else if (theme == "videocards") { query += "  memory"; }
                    if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                    else { query += $" = '{Filter}'"; }
                }
                if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                else { query += " ORDER BY cost ASC;"; }
            }
            else
            {
                //Запрос фулл готов✅
                if (theme == "processors")
                {
                    bool second = false;
                    query += "SELECT * FROM processors WHERE ";
                    if (ArrChecked["motherboards"])
                    {
                        query += $"socket = '{getCharacteristic("cpu_socket", "motherboards", $"{userid}")}' ";
                        second = true;
                    }
                    if (ArrChecked["cpu_cooler"])
                    {
                        if (second)
                        {
                            query += " AND ";
                        }
                        query += $"thermal_power < {getCharacteristic("max_heat_sink", "cpu_cooler", $"{userid}")} ";
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "videocards")
                {
                    query += "SELECT * FROM videocards WHERE ";
                    bool second = false;
                    if (ArrChecked["cases"])
                    {
                        query += $"gpu_lenght < {getCharacteristic("max_lenght_videocard", "cases", $"{userid}")} ";
                        second = true;
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "ram")
                {
                    query += "SELECT * FROM ram WHERE ";
                    bool second = false;
                    if (ArrChecked["motherboards"])
                    {
                        query += $"ram_type = '{getCharacteristic("ram_support_type", "motherboards", $"{userid}")}' ";
                        second = true;
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "storage")
                {
                    query += "SELECT * FROM storage WHERE ";
                    bool second = false;
                    if (ArrChecked["motherboards"] && Convert.ToInt32(getCharacteristic("m2_ssd_slots", "motherboards", $"{userid}")) > 1)
                    {
                        query += $"(type_of_device = 'SSD' or type_of_device = 'HDD' or type_of_device = 'M.2 SSD') ";
                        second = true;
                    }
                    else
                    {
                        query += $"(type_of_device = 'SSD' or type_of_device = 'HDD') ";
                        second = true;
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "cpu_cooler")
                {
                    bool second = false;
                    query += "SELECT * FROM cpu_cooler WHERE ";
                    if (ArrChecked["motherboards"])
                    {
                        query += $"socket LIKE '%{getCharacteristic("cpu_socket", "motherboards", $"{userid}")}%' ";
                        second = true;
                    }
                    if (ArrChecked["cases"])
                    {
                        if (second)
                        {
                            query += " AND ";
                        }
                        query += $"cooler_height < {getCharacteristic("max_height_cpu_cooler", "cases", $"{userid}")} ";
                        second = true;
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "case")
                {
                    bool second = false;
                    query += "SELECT * FROM cases WHERE ";
                    if (ArrChecked["motherboards"])
                    {
                        if (getCharacteristic("form_factor", "motherboards", $"{userid}") == "ATX")
                        {
                            query += $"(form_factor = 'ATX') ";
                        }
                        else if (getCharacteristic("form_factor", "motherboards", $"{userid}") == "mATX")
                        {
                            query += $"(form_factor = 'mATX' or form_factor = 'ATX') ";
                        }
                        else
                        {
                            query += $"form_factor = 'Mini-ITX' or form_factor = 'mATX' or form_factor = 'Mini-ITX' ";
                        }
                        second = true;
                    }
                    if (ArrChecked["cpu_cooler"])
                    {
                        if (second)
                        {
                            query += " AND ";
                        }
                        query += $"max_height_cpu_cooler > {getCharacteristic("cooler_height", "cpu_cooler", $"{userid}")} ";
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                //Запрос фулл готов✅
                else if (theme == "motherboards")
                {
                    bool second = false;
                    query += "SELECT * FROM motherboards WHERE ";
                    if (ArrChecked["cases"])
                    {
                        if (getCharacteristic("form_factor", "cases", $"{userid}") == "ATX")
                        {
                            query += $"(form_factor = 'ATX' or form_factor = 'mATX' or form_factor = 'Mini-ITX') ";
                        }
                        else if (getCharacteristic("form_factor", "cases", $"{userid}") == "mATX")
                        {
                            query += $"(form_factor = 'mATX' or form_factor = 'Mini-ITX') ";
                        }
                        else
                        {
                            query += $"form_factor = 'Mini-ITX' ";
                        }
                        second = true;
                    }
                    if (ArrChecked["processors"])
                    {
                        if (second)
                        {
                            query += " AND ";
                        }
                        query += $"cpu_socket = '{getCharacteristic("socket", "processors", $"{userid}")}' ";
                        second = true;
                    }
                    if (ArrChecked["ram"])
                    {
                        if (second)
                        {
                            query += " AND ";
                        }
                        query += $"ram_support_type = '{getCharacteristic("ram_type", "ram", $"{userid}")}' ";
                        second = true;
                    }
                    if (second) { query += " AND "; }
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                else if (theme == "power_supplier")
                {
                    query += "SELECT * FROM power_supplier WHERE ";
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " AND ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                else if (theme == "case_coolers")
                {
                    query += "SELECT * FROM case_coolers WHERE ";
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " AND ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
                else if (theme == "thermo_interface")
                {
                    query += "SELECT * FROM thermo_interface WHERE ";
                    if (search == "") { query += $"model LIKE '%%' "; }
                    else { query += $"model LIKE '%{search}%' "; }
                    if (Filter != "Не выбрано")
                    {
                        query += " ";
                        if (theme == "processors") { query += "  core_int"; }
                        else if (theme == "case") { query += "  form_factor"; }
                        else if (theme == "case_coolers") { query += "  scale"; }
                        else if (theme == "cpu_cooler") { query += "  max_heat_sink"; }
                        else if (theme == "motherboards") { query += "  cpu_socket"; }
                        else if (theme == "power_supplier") { query += "  power"; }
                        else if (theme == "ram") { query += "  capacity_gb"; }
                        else if (theme == "storage") { query += "  capacity_gb"; }
                        else if (theme == "thermo_interface") { query += "  thermal_conductivity"; }
                        else if (theme == "videocards") { query += "  memory"; }
                        if (Filter.Contains("<") || Filter.Contains(">")) { query += $" {Filter}"; }
                        else { query += $" = '{Filter}'"; }
                    }
                    if (SortComboBox.SelectedIndex == 0) { query += " ORDER BY cost DESC;"; }
                    else { query += " ORDER BY cost ASC;"; }
                }
            }
            return query;
        }

        private string getCharacteristic(string characteristic, string selectedItemTable, string iduser)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string query = $"Select {characteristic} From {selectedItemTable} where id =  (Select id_{selectedItemTable} from user_cart where iduser = {iduser})";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    string res = cmd.ExecuteScalar().ToString();
                    return res;
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return ""; }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            SortComboBox.SelectedIndex = 0;
            FilterComboBox.SelectedIndex = 0;  
        }
    }
}
