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
        }
        public void fillDGV(int iduser)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
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
                            {
                                dataGridView1.Rows.Add(value);
                            }
                        }
                    }
                    
                }
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
                    MySqlDataReader readerCost = cmdCost.ExecuteReader();
                    dataGridView1.Columns.Add("Cost", "Стоимость");
                    if (readerCost.Read())
                    {
                        for (int i = 0; i < readerCost.FieldCount; i++)
                        {
                            string columnNameCost = readerCost.GetValue(i).ToString();
                            if (columnNameCost == "iduser")
                                continue;
                            string valueCost = readerCost.IsDBNull(i) ? null : readerCost.GetValue(i).ToString();
                            if (!string.IsNullOrWhiteSpace(valueCost))
                            {
                                dataGridView1.Rows.Add(valueCost);
                            }
                        }
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }    
}
