using Kursovaya;
using MySql.Data.MySqlClient;
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
        string ConnStr = ConnectionString.GetConnectionString();
        public UserCart()
        {
            InitializeComponent();
            fillDGV(user.Default.userID);
<<<<<<< HEAD
            buildCheckBox.Checked = true;
=======
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
        }
        public void fillDGV(int iduser)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
<<<<<<< HEAD
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
                        
=======
                    conn.Open();
                    string query = $@"
                        SELECT concat(processors.produser, space(1), processors.model) as processor,
                         concat(motherboards.produser, space(1), motherboards.model) as motherboard,
                         concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as vidocard,
                         concat(cpu_cooler.produser, space(1), cpu_cooler.model) as cpu_cooler,
                         concat(cases.produser, space(1), cases.model) as cases,
                         concat(case_coolers.produser, space(1), case_coolers.model) as case_coolers, 
                         concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as power_supplier,
                         concat(thermo_interface.produser, space(1), thermo_interface.model) as thermo_interface,
                         concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as ram,
                         concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as storage
                         FROM user_cart
                         join processors ON id_processors = processors.id
                         join motherboards ON id_motherboards = motherboards.id
                         join videocards ON id_videocards = videocards.id
                         join cpu_cooler ON id_cpu_cooler = cpu_cooler.id
                         join cases ON id_cases = cases.id
                         join case_coolers ON id_case_coolers = case_coolers.id
                         join power_supplier ON id_power_supplier = power_supplier.id
                         join thermo_interface ON id_thermo_interface = thermo_interface.id
                         join ram ON id_ram = ram.id
                         join storage ON id_storage = storage.id
                         WHERE iduser = {iduser};";
                        
                    DataTable table = new DataTable();
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
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
                            string value = reader.IsDBNull(i) ? null : reader.GetValue(i).ToString();
                            if (!string.IsNullOrWhiteSpace(value))
<<<<<<< HEAD
                            {                                
=======
                            {
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
                                dataGridView1.Rows.Add(value);
                            }
                        }
                    }
                    
                }
<<<<<<< HEAD
                //ТУТ ПИЗДЕЦ ВООБЩЕ БЛЯТЬ
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    bool second = false;
                    conn.Open();
                    string query = $@"SELECT ";
                    if (checkedItems.Default.processors)
                    {
                        query += "processors.cost as processorCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.motherboards)
                    {
                        query += "motherboards.cost as motherboardCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.videocards)
                    {
                        query += "videocards.cost as vidocardCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.cpu_cooler)
                    {
                        query += "cpu_cooler.cost as cpu_coolerCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.cases)
                    {
                        query += "cases.cost as casesCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.case_coolers)
                    {
                        query += "case_coolers.cost as case_coolersCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.power_supplier)
                    {
                        query += "power_supplier.cost as power_supplierCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.thermo_interface)
                    {
                        query += "thermo_interface.cost as thermo_interfaceCost";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.ram)
                    {
                        query += "ram.cost as ramCost ";
                        if (second) query += ", "; second = true;
                    }
                    if (checkedItems.Default.storage)
                    {
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
=======
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string queryPrice = $@"SELECT processors.cost as processorCost,
                         motherboards.cost as motherboardCost,
                         videocards.cost as vidocardCost,
                         cpu_cooler.cost as cpu_coolerCost,
                         cases.cost as casesCost,
                         case_coolers.cost as case_coolersCost, 
                         power_supplier.cost as power_supplierCost,
                         thermo_interface.cost as thermo_interfaceCost,
                         ram.cost as ramCost,
                         storage.cost as storageCost
                         FROM user_cart
                         join processors ON id_processors = processors.id
                         join motherboards ON id_motherboards = motherboards.id
                         join videocards ON id_videocards = videocards.id
                         join cpu_cooler ON id_cpu_cooler = cpu_cooler.id
                         join cases ON id_cases = cases.id
                         join case_coolers ON id_case_coolers = case_coolers.id
                         join power_supplier ON id_power_supplier = power_supplier.id
                         join thermo_interface ON id_thermo_interface = thermo_interface.id
                         join ram ON id_ram = ram.id
                         join storage ON id_storage = storage.id
                         WHERE iduser = {iduser};";
                    MySqlCommand cmdCost = new MySqlCommand(queryPrice, conn);
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
                    MySqlDataReader readerCost = cmdCost.ExecuteReader();
                    dataGridView1.Columns.Add("Cost", "Стоимость");
                    if (readerCost.Read())
                    {
                        for (int i = 0; i < readerCost.FieldCount; i++)
                        {
                            string columnNameCost = readerCost.GetValue(i).ToString();
<<<<<<< HEAD
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
=======
                            if (columnNameCost == "iduser")
                                continue;
                            string valueCost = readerCost.IsDBNull(i) ? null : readerCost.GetValue(i).ToString();
                            if (!string.IsNullOrWhiteSpace(valueCost))
                            {
                                dataGridView1.Rows.Add(valueCost);
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
<<<<<<< HEAD
            dataGridView1.Columns["value"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["cost"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public int mathCartPrice(bool discount)
        {
            int cartSumm = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cartSumm += Convert.ToInt32(dataGridView1.Rows[i].Cells["Cost"].Value.ToString().Replace(" ₽", "").Replace(" ", "").Trim());
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
=======
>>>>>>> ca407f182d134c01ba77b83e088c341463ec0cce
        }
    }    
}
