using Kursovaya;
using Kursovaya.Administrator;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.User
{
    public partial class UserCart : Form
    {
        public Dictionary<string, int> ArrPosInDGV = new Dictionary<string, int>
        {

        };
        public Dictionary<int, string> ArrPosInDGVInvert = new Dictionary<int, string>
        {

        };
        string ConnStr = ConnectionString.GetConnectionString();
        public UserCart()
        {
            InitializeComponent();
            fillDGV(user.Default.userID);
            checkBuildOption();
            buildCheckBox.Checked = false;
            if (checkAmount())
            {
                buildCheckBox.Checked = true;
                buildPrice.Visible = true;
            }
            else
            {
                buildCheckBox.Checked = false;
                buildPrice.Visible = false;
            }
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
            makeCalendar();
            mathEndPriceNew();
        }
        private void makeCalendar()
        {

            calendar.MinDate = DateTime.Today.AddDays(7);
            calendar.MaxDate = DateTime.Today.AddMonths(6);
        }
        public void fillDGV(int iduser)
        {
            try
            {
                if (!(
                checkedItems.Default.processors == false &&
                checkedItems.Default.motherboards == false &&
                checkedItems.Default.videocards == false &&
                checkedItems.Default.ram == false &&
                checkedItems.Default.cases == false &&
                checkedItems.Default.case_coolers == false &&
                checkedItems.Default.cpu_cooler == false &&
                checkedItems.Default.thermo_interface == false &&
                checkedItems.Default.storage == false &&
                checkedItems.Default.power_supplier == false))
                {
                    using (MySqlConnection conn = new MySqlConnection(ConnStr))
                    {
                        bool second = false;
                        conn.Open();
                        string query = $@"SELECT ";
                        if (checkedItems.Default.processors)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(processors.produser, space(1), processors.model) as processor ";

                        }
                        if (checkedItems.Default.motherboards)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(motherboards.produser, space(1), motherboards.model) as motherboard ";

                        }
                        if (checkedItems.Default.videocards)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as vidocard ";

                        }
                        if (checkedItems.Default.cpu_cooler)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as cpu_cooler ";

                        }
                        if (checkedItems.Default.cases)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(cases.produser, space(1), cases.model) as cases ";

                        }
                        if (checkedItems.Default.case_coolers)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(case_coolers.produser, space(1), case_coolers.model) as case_coolers ";

                        }
                        if (checkedItems.Default.power_supplier)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as power_supplier ";

                        }
                        if (checkedItems.Default.thermo_interface)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as thermo_interface ";

                        }
                        if (checkedItems.Default.ram)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as ram ";

                        }
                        if (checkedItems.Default.storage)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as storage ";
                        }
                        query += "FROM user_cart ";
                        if (checkedItems.Default.processors) query += "join processors ON id_processors = processors.id ";
                        if (checkedItems.Default.motherboards) query += "join motherboards ON id_motherboards = motherboards.id ";
                        if (checkedItems.Default.videocards) query += "join videocards ON id_videocards = videocards.id ";
                        if (checkedItems.Default.cpu_cooler) query += "join cpu_cooler ON id_cpu_cooler = cpu_cooler.id ";
                        if (checkedItems.Default.cases) query += "join cases ON id_cases = cases.id ";
                        if (checkedItems.Default.case_coolers) query += "join case_coolers ON id_case_coolers = case_coolers.id ";
                        if (checkedItems.Default.power_supplier) query += "join power_supplier ON id_power_supplier = power_supplier.id ";
                        if (checkedItems.Default.thermo_interface) query += "join thermo_interface ON id_thermo_interface = thermo_interface.id ";
                        if (checkedItems.Default.ram) query += "join ram ON id_ram = ram.id ";
                        if (checkedItems.Default.storage) query += "join storage ON id_storage = storage.id ";
                        query += $"WHERE iduser = {iduser};";

                        //if(query == $"SELECT FROM user_cart WHERE iduser = {user.Default.userID};")
                        //{
                        //    query = "SELECT 'Ничего не найдено!' from user_cart where 1=1;";
                        //    MySqlCommand cmd2 = new MySqlCommand(query, conn);
                        //    string qwe = cmd2.ExecuteScalar().ToString();
                        //    dataGridView1.Rows.Add(qwe);                        
                        //}
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        dataGridView1.Columns.Add("value", "Комплектующие");
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string columnName = reader.GetValue(i).ToString();
                                if (columnName == "iduser")
                                    continue;
                                string columnType = reader.GetName(i).ToString();
                                ArrPosInDGVInvert[i] = columnType;
                                ArrPosInDGV[columnType] = i;
                                string value = reader.IsDBNull(i) ? null : reader.GetValue(i).ToString();
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    dataGridView1.Rows.Add(value);
                                }
                            }
                        }

                    }

                    using (MySqlConnection conn = new MySqlConnection(ConnStr))
                    {
                        bool second = false;
                        conn.Open();
                        string query = $@"SELECT ";
                        if (checkedItems.Default.processors)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(processors.produser, space(1), processors.model) as processor ";

                        }
                        if (checkedItems.Default.motherboards)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(motherboards.produser, space(1), motherboards.model) as motherboard ";

                        }
                        if (checkedItems.Default.videocards)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as vidocard ";

                        }
                        if (checkedItems.Default.cpu_cooler)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as cpu_cooler ";

                        }
                        if (checkedItems.Default.cases)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(cases.produser, space(1), cases.model) as cases ";

                        }
                        if (checkedItems.Default.case_coolers)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(case_coolers.produser, space(1), case_coolers.model) as case_coolers ";

                        }
                        if (checkedItems.Default.power_supplier)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as power_supplier ";

                        }
                        if (checkedItems.Default.thermo_interface)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as thermo_interface ";

                        }
                        if (checkedItems.Default.ram)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as ram ";

                        }
                        if (checkedItems.Default.storage)
                        {
                            if (second) query += ", "; second = true;
                            query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as storage ";
                        }
                        query += "FROM user_cart ";
                        if (checkedItems.Default.processors) query += "join processors ON id_processors = processors.id ";
                        if (checkedItems.Default.motherboards) query += "join motherboards ON id_motherboards = motherboards.id ";
                        if (checkedItems.Default.videocards) query += "join videocards ON id_videocards = videocards.id ";
                        if (checkedItems.Default.cpu_cooler) query += "join cpu_cooler ON id_cpu_cooler = cpu_cooler.id ";
                        if (checkedItems.Default.cases) query += "join cases ON id_cases = cases.id ";
                        if (checkedItems.Default.case_coolers) query += "join case_coolers ON id_case_coolers = case_coolers.id ";
                        if (checkedItems.Default.power_supplier) query += "join power_supplier ON id_power_supplier = power_supplier.id ";
                        if (checkedItems.Default.thermo_interface) query += "join thermo_interface ON id_thermo_interface = thermo_interface.id ";
                        if (checkedItems.Default.ram) query += "join ram ON id_ram = ram.id ";
                        if (checkedItems.Default.storage) query += "join storage ON id_storage = storage.id ";
                        query += $"WHERE iduser = {iduser};";
                        dataGridView1.Columns.Add("type", "Наименование");
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string value = "";
                                string columnType = reader.GetName(i).ToString();
                                if (columnType == "processor") { value = "Процессор"; }
                                else if (columnType == "vidocard") { value = "Видеокарта"; }
                                else if (columnType == "ram") { value = "Оперативная память"; }
                                else if (columnType == "power_supplier") { value = "Блок питания"; }
                                else if (columnType == "motherboard") { value = "Материнская плата"; }
                                else if (columnType == "cases") { value = "Корпус"; }
                                else if (columnType == "storage") { value = "Накопитель"; }
                                else if (columnType == "thermo_interface") { value = "Термопаста"; }
                                else if (columnType == "case_coolers") { value = "Корпусные кулеры"; }
                                else if (columnType == "cpu_cooler") { value = "Кулер"; }
                                if (!string.IsNullOrWhiteSpace(value))
                                {
                                    dataGridView1.Rows[i].Cells["type"].Value = value;
                                }
                            }
                        }
                    }
                    using (MySqlConnection conn = new MySqlConnection(ConnStr))
                    {
                        bool second = false;
                        conn.Open();
                        string query = $@"SELECT ";
                        if (checkedItems.Default.processors)
                        {
                            if (second) query += ", "; second = true;
                            query += "processors.cost as processorCost ";
                        }
                        if (checkedItems.Default.motherboards)
                        {
                            if (second) query += ", "; second = true;
                            query += "motherboards.cost as motherboardCost ";
                        }
                        if (checkedItems.Default.videocards)
                        {
                            if (second) query += ", "; second = true;
                            query += "videocards.cost as vidocardCost ";
                        }
                        if (checkedItems.Default.cpu_cooler)
                        {
                            if (second) query += ", "; second = true;
                            query += "cpu_cooler.cost as cpu_coolerCost ";
                        }
                        if (checkedItems.Default.cases)
                        {
                            if (second) query += ", "; second = true;
                            query += "cases.cost as casesCost ";
                        }
                        if (checkedItems.Default.case_coolers)
                        {
                            if (second) query += ", "; second = true;
                            query += "case_coolers.cost as case_coolersCost ";
                        }
                        if (checkedItems.Default.power_supplier)
                        {
                            if (second) query += ", "; second = true;
                            query += "power_supplier.cost as power_supplierCost ";
                        }
                        if (checkedItems.Default.thermo_interface)
                        {
                            if (second) query += ", "; second = true;
                            query += "thermo_interface.cost as thermo_interfaceCost ";
                        }
                        if (checkedItems.Default.ram)
                        {
                            if (second) query += ", "; second = true;
                            query += "ram.cost as ramCost ";
                        }
                        if (checkedItems.Default.storage)
                        {
                            if (second) query += ", "; second = true;
                            query += "storage.cost as storageCost ";
                        }
                        query += "FROM user_cart ";
                        if (checkedItems.Default.processors) query += "join processors ON id_processors = processors.id ";
                        if (checkedItems.Default.motherboards) query += "join motherboards ON id_motherboards = motherboards.id ";
                        if (checkedItems.Default.videocards) query += "join videocards ON id_videocards = videocards.id ";
                        if (checkedItems.Default.cpu_cooler) query += "join cpu_cooler ON id_cpu_cooler = cpu_cooler.id ";
                        if (checkedItems.Default.cases) query += "join cases ON id_cases = cases.id ";
                        if (checkedItems.Default.case_coolers) query += "join case_coolers ON id_case_coolers = case_coolers.id ";
                        if (checkedItems.Default.power_supplier) query += "join power_supplier ON id_power_supplier = power_supplier.id ";
                        if (checkedItems.Default.thermo_interface) query += "join thermo_interface ON id_thermo_interface = thermo_interface.id ";
                        if (checkedItems.Default.ram) query += "join ram ON id_ram = ram.id ";
                        if (checkedItems.Default.storage) query += "join storage ON id_storage = storage.id ";
                        query += $"WHERE iduser = {iduser};";

                        MySqlCommand cmdCost = new MySqlCommand(query, conn);
                        MySqlDataReader readerCost = cmdCost.ExecuteReader();
                        dataGridView1.Columns.Add("Cost", "Стоимость");
                        dataGridView1.Columns.Add("Amount", "Количество");
                        if (readerCost.Read())
                        {
                            for (int i = 0; i < readerCost.FieldCount; i++)
                            {
                                string columnNameCost = readerCost.GetValue(i).ToString();
                                string valueCostOrig = readerCost.IsDBNull(i) ? null : readerCost.GetValue(i).ToString();
                                string valueCost = new String(valueCostOrig.Reverse().ToArray());
                                string cost = "";
                                for (int j = 0; j < valueCost.Length; j++)
                                {
                                    cost += valueCost[j];
                                    if ((j + 1) % 3 == 0 && j != valueCost.Length - 1)
                                    {
                                        cost += " ";
                                    }
                                }
                                valueCostOrig = new String(cost.Reverse().ToArray());
                                dataGridView1.Rows[i].Cells["Cost"].Value = valueCostOrig + " ₽";
                                if (!string.IsNullOrWhiteSpace(valueCost))
                                {
                                }
                            }
                        }
                    }
                    mathEndPriceNew();
                    if (!dataGridView1.Columns.Contains("AmountInc"))
                    {
                        DataGridViewButtonColumn AmountInc = new DataGridViewButtonColumn();
                        AmountInc.Name = "AmountInc";
                        AmountInc.HeaderText = "Добавить";
                        AmountInc.Text = "+";
                        AmountInc.UseColumnTextForButtonValue = true;
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.Columns.Add(AmountInc);
                    }
                    if (!dataGridView1.Columns.Contains("AmountDec"))
                    {
                        DataGridViewButtonColumn AmountDec = new DataGridViewButtonColumn();
                        AmountDec.Name = "AmountDec";
                        AmountDec.HeaderText = "Убавить";
                        AmountDec.Text = "-";
                        AmountDec.UseColumnTextForButtonValue = true;
                        dataGridView1.AutoGenerateColumns = true;
                        dataGridView1.Columns.Add(AmountDec);
                    }
                    dataGridView1.Columns["Value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dataGridView1.Columns["type"].DisplayIndex = 0;
                    dataGridView1.Columns["Value"].DisplayIndex = 1;
                    dataGridView1.Columns["AmountInc"].DisplayIndex = 4;
                    dataGridView1.Columns["Amount"].DisplayIndex = 3;
                    dataGridView1.Columns["AmountDec"].DisplayIndex = 2;
                    dataGridView1.Columns["Cost"].DisplayIndex = 5;
                    dataGridView1.Columns["AmountInc"].Width = 100;
                    dataGridView1.Columns["AmountDec"].Width = 100;
                    dataGridView1.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells["Amount"].Value = 1;
                    }

                    dataGridView1.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Корзина", "В корзине нет товаров!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    MessageBox.Show("Корзина пуста!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    makeBuyButton.Enabled = false;
                    addresTextBox.Enabled = false;
                    deliveryCB.Enabled = false;
                    this.Hide();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public int mathCartPrice(bool discount)
        {
            int cartSumm = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Cost"].Value == null)
                {

                }
                else
                {
                    cartSumm += Convert.ToInt32(dataGridView1.Rows[i].Cells["Cost"].Value.ToString().Replace(" ₽", "").Replace(" ", "").Trim()) * Convert.ToInt32(dataGridView1.Rows[i].Cells["Amount"].Value);
                }
            }
            return cartSumm;
        }
        private string getMakedString(string cartSumStr)
        {
            string cost = "";
            string cartSumReversed = new String(cartSumStr.Reverse().ToArray());
            for (int j = 0; j < cartSumReversed.Length; j++)
            {
                cost += cartSumReversed[j];
                if ((j + 1) % 3 == 0 && j != cartSumReversed.Length - 1)
                {
                    cost += " ";
                }
            }
            return new String(cost.Reverse().ToArray());
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "AmountInc")
            {
                int amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                amount++;
                dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value = amount;
            }
            else if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "AmountDec")
            {
                int amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                if (amount <= 1)
                {
                    DialogResult delFromCart = MessageBox.Show($"Вы действительно хотите удалить {dataGridView1.Rows[e.RowIndex].Cells["Value"].Value.ToString()} из корзины?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (delFromCart == DialogResult.Yes)
                    {
                        amount--;
                        dataGridView1.Rows[e.RowIndex].Cells["amount"].Value = amount;
                        //вычесть из бд
                        try
                        {
                            using (MySqlConnection conn = new MySqlConnection(ConnStr))
                            {
                                string query = "";
                                conn.Open();
                                string tableColumnName = ArrPosInDGVInvert[e.RowIndex];
                                if (tableColumnName == "cases")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_cases) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_cases = 0;";
                                    checkedItems.Default.cases = false;
                                }
                                else if (tableColumnName == "motherboard")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_motherboards) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_motherboards = 0;";
                                    checkedItems.Default.motherboards = false;
                                }
                                else if (tableColumnName == "vidocard")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_videocards) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_videocards = 0;";
                                    checkedItems.Default.videocards = false;
                                }
                                else if (tableColumnName == "cpu_cooler")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_cpu_cooler) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_cpu_cooler = 0;";
                                    checkedItems.Default.cpu_cooler = false;
                                }
                                else if (tableColumnName == "processor")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_processors) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_processors = 0;";
                                    checkedItems.Default.processors = false;
                                }
                                else if (tableColumnName == "case_coolers")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_case_coolers) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_case_coolers = 0;";
                                    checkedItems.Default.case_coolers = false;
                                }
                                else if (tableColumnName == "power_supplier")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_power_supplier) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_power_supplier = 0;";
                                    checkedItems.Default.power_supplier = false;
                                }
                                else if (tableColumnName == "thermo_interface")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_thermo_interface) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_thermo_interface = 0;";
                                    checkedItems.Default.thermo_interface = false;
                                }
                                else if (tableColumnName == "ram")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_ram) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_ram = 0;";
                                    checkedItems.Default.ram = false;
                                }
                                else if (tableColumnName == "storage")
                                {
                                    query = $"INSERT INTO user_cart (iduser, id_storage) VALUES ({user.Default.userID}, 0) ON DUPLICATE KEY UPDATE id_storage = 0;";
                                    checkedItems.Default.storage = false;
                                }
                                query += "";
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                dataGridView1.Rows.Clear();
                                dataGridView1.Columns.Clear();
                                fillDGV(user.Default.userID);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
                else
                {
                    amount--;
                    dataGridView1.Rows[e.RowIndex].Cells["amount"].Value = amount;
                }
            }
            checkBuildOption();
            if (checkAmount())
            {
                buildCheckBox.Enabled = true;
            }
            else
            {
                buildCheckBox.Enabled = false;
                buildCheckBox.Checked = false;
            }
            mathEndPriceNew();
        }
        private bool checkAmount()
        {
            Dictionary<string, int> components = new Dictionary<string, int>()
    {
        { "Процессор", 0 },
        { "Материнская плата", 0 },
        { "Видеокарта", 0 },
        { "Кулер", 0 },
        { "Корпус", 0 },
        { "Корпусные кулеры", 0 },
        { "Блок питания", 0 },
        { "Термопаста", 0 },
        { "Накопитель", 0 }
        // ❗ Оперативную память намеренно НЕ добавляем
    };

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["Amount"].Value == null) continue;

                int amount = Convert.ToInt32(row.Cells["Amount"].Value);
                if (amount <= 0) continue;

                string type = row.Cells["type"].Value?.ToString();
                if (type == null) continue;

                if (components.ContainsKey(type))
                {
                    components[type] += amount;
                }
            }

            foreach (var item in components)
            {
                switch (item.Key)
                {
                    case "Накопитель":
                        if (item.Value < 1 || item.Value > 2)
                            return false;
                        break;

                    case "Корпусные кулеры":
                        if (item.Value < 1 || item.Value > 4)
                            return false;
                        break;

                    default:
                        if (item.Value != 1)
                            return false;
                        break;
                }
            }

            return true;
        }
        private void checkBuildOption()
        {
            if (checkedItems.Default.processors == true
                &&
                checkedItems.Default.motherboards == true &&

                checkedItems.Default.videocards == true &&
                checkedItems.Default.ram == true &&
                checkedItems.Default.cases == true &&
                checkedItems.Default.case_coolers == true &&
                checkedItems.Default.cpu_cooler == true &&
                checkedItems.Default.thermo_interface == true &&
                checkedItems.Default.storage == true &&
                checkedItems.Default.power_supplier == true
                )
            {
                int ramSlotAmountFromDB = Convert.ToInt32(getCharacteristic("ram_slots", "motherboards", user.Default.userID.ToString()));
                int ramCountSelect = Convert.ToInt32(dataGridView1.Rows[ArrPosInDGV["ram"]].Cells["Amount"].Value);
                if (ramSlotAmountFromDB >= ramCountSelect)
                {
                    buildCheckBox.Checked = true;
                    buildCheckBox.Enabled = true;
                }
                else
                {
                    buildCheckBox.Checked = false;
                    buildCheckBox.Enabled = false;
                }
            }
            else
            {
                buildCheckBox.Checked = false;
                buildCheckBox.Enabled = false;
            }
        }
        private string getCharacteristic(string characteristic, string selectedItemTable, string iduser)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    string res = "";
                    conn.Open();
                    string query = $"Select {characteristic} From {selectedItemTable} where id =  (Select id_{selectedItemTable} from user_cart where iduser = {iduser})";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmd.ExecuteScalar() == null)
                    {

                    }
                    else
                    {
                        res = cmd.ExecuteScalar().ToString();
                    }
                    return res;
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); return ""; }
        }

        private void deliveryCB_CheckedChanged(object sender, EventArgs e)
        {
            mathEndPriceNew();
            if (deliveryCB.Checked)
            {
                deliveryPrice.Visible = true;
                addresTextBox.Visible = true;
                label2.Visible = true;
                calendar.Visible = true;
            }
            else
            {
                deliveryPrice.Visible = false;
                addresTextBox.Visible = false;
                label2.Visible = false;
                calendar.Visible = false;
            }

        }

        private void ShowPrice()
        {
            //cartEndPrice.Text = getMakedString((mathCartPrice(true) - ((Convert.ToInt32(mathCartPrice(true)) / 100 * 5))).ToString()) + " ₽"; ;
        }


        private void mathEndPriceNew()
        {
            int totalWithDiscount = 0;
            int total = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //if (row.IsNewRow) continue;

                if (row.Cells["Amount"].Value == null ||
                    row.Cells["Cost"].Value == null)
                    continue;

                int amount = Convert.ToInt32(row.Cells["Amount"].Value);
                if (amount <= 0) continue;

                int cost = Convert.ToInt32(row.Cells["Cost"].Value.ToString().Replace(" ₽", "").Replace(" ", "").Trim());


                total += cost * amount;


            }
            if (deliveryCB.Checked && buildCheckBox.Checked)
            {
                total += 6000;
                discountLabel.Text = "2 000 ₽";
                totalWithDiscount = total - 2000;
            }
            else if (deliveryCB.Checked && buildCheckBox.Checked == false || deliveryCB.Checked == false && buildCheckBox.Checked)
            {
                total += 3000;
                discountLabel.Text = "0 ₽";
                totalWithDiscount = total;
            }
            else if (deliveryCB.Checked == false && buildCheckBox.Checked == false)
            {
                discountLabel.Text = "0 ₽";
                totalWithDiscount = total;
            }
            cartSumLabel.Text = getMakedString(total.ToString()) + " ₽";
            cartEndPrice.Text = getMakedString(totalWithDiscount.ToString()) + " ₽";
        }

        private void buildCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mathEndPriceNew();
            if (buildCheckBox.Checked)
            {
                buildPrice.Visible = true;
            }
            else
            {

                buildPrice.Visible = false;
            }
        }
        string checkDate = "-";
        public string Safe(string s) => string.IsNullOrEmpty(s) ? "0" : s;
        private void makeBuyButton_Click(object sender, EventArgs e)
        {
            string formatted;
            string processorValue = "", videoValue = "", motherValue = "", ramValue = "", powerValue = "", driverValue = "", thermoValue = "", caseValue = "", casefanValue = "", procfanValue = "";
            int countProc = 0, countVideo = 0, countMother = 0, countRam = 0, countPower = 0, countDriver = 0, countThermo = 0, countCases = 0, countCasefan = 0, countProcfan = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["type"].Value?.ToString() == "Процессор") { processorValue = row.Cells["value"].Value?.ToString(); countProc = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Видеокарта") { videoValue = row.Cells["value"].Value?.ToString(); countVideo = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Материнская плата") { motherValue = row.Cells["value"].Value?.ToString(); countMother = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Оперативная память") { ramValue = row.Cells["value"].Value?.ToString(); countRam = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Блок питания") { powerValue = row.Cells["value"].Value?.ToString(); countPower = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Кулер") { procfanValue = row.Cells["value"].Value?.ToString(); countProcfan = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Корпус") { caseValue = row.Cells["value"].Value?.ToString(); countCases = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Накопитель") { driverValue = row.Cells["value"].Value?.ToString(); countDriver = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Термопаста") { thermoValue = row.Cells["value"].Value?.ToString(); countThermo = Convert.ToInt32(row.Cells["Amount"].Value); }
                else if (row.Cells["type"].Value?.ToString() == "Корпусные кулеры") { casefanValue = row.Cells["value"].Value?.ToString(); countCasefan = Convert.ToInt32(row.Cells["Amount"].Value); }
            }

            string query1 = $"SELECT id FROM processors WHERE concat(processors.produser, space(1), processors.model) = '{processorValue}'";
            string query2 = $"SELECT id FROM videocards WHERE     concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) = '{videoValue}'";
            string query3 = $"SELECT id FROM motherboards WHERE    concat(motherboards.produser, space(1), motherboards.model) = '{motherValue}'";
            string query4 = $"SELECT id FROM ram WHERE       concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') = '{ramValue}'";
            string query5 = $"SELECT id FROM power_supplier WHERE     concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') = '{powerValue}'";
            string query6 = $"SELECT id FROM storage WHERE    concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') = '{driverValue}'";
            string query7 = $"SELECT id FROM thermo_interface WHERE    concat(thermo_interface.produser, space(1), thermo_interface.model) = '{thermoValue}'";
            string query8 = $"SELECT id FROM cases WHERE      concat(cases.produser, space(1), cases.model) = '{caseValue}'";
            string query9 = $"SELECT id FROM case_coolers WHERE   concat(case_coolers.produser, space(1), case_coolers.model) = '{casefanValue}'";
            string query0 = $"SELECT id FROM cpu_cooler WHERE   concat(cpu_cooler.produser, space(1), cpu_cooler.model) = '{procfanValue}'";
            DateTime Date = DateTime.Now;
            string formattedDate = Date.ToString("yyyy-MM-dd HH:mm:ss");
            string deliveryDate = "";
            checkDate = formattedDate;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    MySqlCommand cmd1 = new MySqlCommand(query1, conn);
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                    MySqlCommand cmd4 = new MySqlCommand(query4, conn);
                    MySqlCommand cmd5 = new MySqlCommand(query5, conn);
                    MySqlCommand cmd6 = new MySqlCommand(query6, conn);
                    MySqlCommand cmd7 = new MySqlCommand(query7, conn);
                    MySqlCommand cmd8 = new MySqlCommand(query8, conn);
                    MySqlCommand cmd9 = new MySqlCommand(query9, conn);
                    MySqlCommand cmd0 = new MySqlCommand(query0, conn);
                    string resultQuery;
                    if (deliveryCB.Checked)
                    {
                        DateTime date = calendar.SelectionStart;
                        DateTime result = date.Date + DateTime.Now.TimeOfDay;
                        formatted = result.ToString("yyyy-MM-dd HH:mm:ss");
                        deliveryDate = formatted;
                        resultQuery = $@"INSERT INTO `order` (iduser, id_processors, count_processors, id_motherboards, count_motherboards, id_videocards, count_videocards, id_ram, count_ram, id_cpu_cooler, count_cpu_coolers, id_cases, count_cases, id_case_coolers, count_case_fan, id_storage, count_storage, id_power_supplier, count_power_supplier, id_thermo_interface, count_thermo_interface, build, delivery, deliveryaddress, ordertime, ordercomplitetime, status) VALUES ({user.Default.userID}, {Convert.ToInt32(cmd1.ExecuteScalar())}, {countProc}, {Convert.ToInt32(cmd3.ExecuteScalar())}, {countMother}, {Convert.ToInt32(cmd2.ExecuteScalar())}, {countVideo}, {Convert.ToInt32(cmd4.ExecuteScalar())}, {countRam}, {Convert.ToInt32(cmd0.ExecuteScalar())}, {countProcfan}, {Convert.ToInt32(cmd8.ExecuteScalar())}, {countCases}, {Convert.ToInt32(cmd9.ExecuteScalar())}, {countCasefan}, {Convert.ToInt32(cmd6.ExecuteScalar())}, {countDriver}, {Convert.ToInt32(cmd5.ExecuteScalar())}, {countPower}, {Convert.ToInt32(cmd7.ExecuteScalar())}, {countThermo}, '{buildCheckBox.Enabled.ToString()}', 'True', '{addresTextBox.Text} ', '{formattedDate}', '{formatted}', (SELECT id FROM statuses WHERE status = 'Новый' LIMIT 1))";
                    }
                    else
                    {
                        resultQuery = $@"INSERT INTO `order` (iduser, id_processors, count_processors, id_motherboards, count_motherboards, id_videocards, count_videocards, id_ram, count_ram, id_cpu_cooler, count_cpu_coolers, id_cases, count_cases, id_case_coolers, count_case_fan, id_storage, count_storage, id_power_supplier, count_power_supplier, id_thermo_interface, count_thermo_interface, build, delivery, deliveryaddress, ordertime, status) VALUES ({user.Default.userID}, {Convert.ToInt32(cmd1.ExecuteScalar())}, {countProc}, {Convert.ToInt32(cmd3.ExecuteScalar())}, {countMother}, {Convert.ToInt32(cmd2.ExecuteScalar())}, {countVideo}, {Convert.ToInt32(cmd4.ExecuteScalar())}, {countRam}, {Convert.ToInt32(cmd0.ExecuteScalar())}, {countProcfan}, {Convert.ToInt32(cmd8.ExecuteScalar())}, {countCases}, {Convert.ToInt32(cmd9.ExecuteScalar())}, {countCasefan}, {Convert.ToInt32(cmd6.ExecuteScalar())}, {countDriver}, {Convert.ToInt32(cmd5.ExecuteScalar())}, {countPower}, {Convert.ToInt32(cmd7.ExecuteScalar())}, {countThermo}, '{buildCheckBox.Enabled.ToString()}', 'False', '{addresTextBox.Text} ', '{formattedDate}', (SELECT id FROM statuses WHERE status = 'Новый' LIMIT 1))";
                    }
                    MySqlCommand cmdEnd = new MySqlCommand(resultQuery, conn);
                    cmdEnd.ExecuteNonQuery();
                    DialogResult chech = MessageBox.Show("Заказ успешно оформлен! \n\nХотите получить чек?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (chech == DialogResult.Yes)
                    {
                        List<string> names = new List<string>();
                        List<int> costs = new List<int>();
                        List<int> counts = new List<int>();
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue; // пропускаем пустую строку
                            string costt = row.Cells["cost"].Value.ToString().Replace(" ", "").Replace("₽", "");
                            names.Add(row.Cells["type"].Value.ToString() + ": " + row.Cells["value"].Value.ToString());
                            costs.Add(Convert.ToInt32(costt));
                            counts.Add(Convert.ToInt32(row.Cells["Amount"].Value));
                        }
                        SaveCheck saveCheck = new SaveCheck();
                        if(deliveryCB.Checked == false)
                        {
                            saveCheck.SaveMakeCheck(names.ToArray(), costs.ToArray(), counts.ToArray(), $"{checkDate}", $"{DateTime.Now.Date.AddDays(3).ToString("dd.MM.yyyy")}");
                        }
                        else
                        {
                            saveCheck.SaveMakeCheck(names.ToArray(), costs.ToArray(), counts.ToArray(), $"{checkDate}", $"{deliveryDate}");
                        }
                    }
                }
            }
            catch (Exception ex) { string err = ex.Message; }
        }



        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AmountInc"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Цвет кнопки
                using (SolidBrush buttonColor = new SolidBrush(Color.FromArgb(77, 150, 125)))
                {
                    e.Graphics.FillRectangle(buttonColor, e.CellBounds);
                }

                // Текст кнопки
                TextRenderer.DrawText(e.Graphics,
                                      (e.FormattedValue ?? "").ToString(),
                                      e.CellStyle.Font,
                                      e.CellBounds,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; // Система больше не рисует кнопку
            }
            if (e.ColumnIndex == dataGridView1.Columns["AmountDec"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Цвет кнопки
                using (SolidBrush buttonColor = new SolidBrush(Color.FromArgb(77, 150, 125)))
                {
                    e.Graphics.FillRectangle(buttonColor, e.CellBounds);
                }

                // Текст кнопки
                TextRenderer.DrawText(e.Graphics,
                                      (e.FormattedValue ?? "").ToString(),
                                      e.CellStyle.Font,
                                      e.CellBounds,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; // Система больше не рисует кнопку
            }
        }
        bool detector = false;
        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;

            // Если дата больше MaxDate — ставим MaxDate
            if (selectedDate > calendar.MaxDate)
            {
                MessageBox.Show(
                    "Дата не может быть больше, чем через полгода от сегодня",
                    "Ошибка выбора даты",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                calendar.SetDate(calendar.MaxDate);
                return;
            }

            // Проверка на выходные
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                if (!detector)
                {
                    MessageBox.Show(
                        "Суббота и воскресенье недоступны",
                        "Ошибка выбора даты",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    detector = true;
                }

                DateTime d = selectedDate;
                do
                {
                    d = d.AddDays(-1);
                } while ((d.DayOfWeek != DayOfWeek.Monday) && d >= calendar.MinDate);

                if (d < calendar.MinDate)
                    d = calendar.MinDate;

                calendar.SetDate(d);
            }
        }
    }
}
