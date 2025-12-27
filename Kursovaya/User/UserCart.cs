using Kursovaya;
using Kursovaya.Administrator;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.X.XDevAPI.Common;
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
        public Dictionary<string, int> ArrPosInDGV = new Dictionary<string, int> {
           
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
                if(dataGridView1.Rows[i].Cells["Cost"].Value == null)
                {

                }
                else
                {
                    cartSumm += Convert.ToInt32(dataGridView1.Rows[i].Cells["Cost"].Value.ToString().Replace(" ₽", "").Replace(" ", "").Trim());
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

        private void buildCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (buildCheckBox.Checked)
            {
                cartSumLabel.Text = getMakedString(mathCartPrice(true).ToString()) + " ₽";
                discountLabel.Text = getMakedString(Convert.ToInt32(mathCartPrice(true)/100*5).ToString()) + " ₽";
                cartEndPrice.Text = getMakedString((mathCartPrice(true) - ((Convert.ToInt32(mathCartPrice(true)) / 100 * 5))).ToString()) + " ₽";
            }
            else if(buildCheckBox.Checked == false)
            {
                cartSumLabel.Text = getMakedString(mathCartPrice(false).ToString()) + " ₽";
                discountLabel.Text = "0 ₽";
                cartEndPrice.Text = cartSumLabel.Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "AmountInc")
            {
                int amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                amount++;
                dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value = amount;
            }
            else if(e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "AmountDec")
            {
                int amount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                if(amount <= 1)
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
    }    
}
