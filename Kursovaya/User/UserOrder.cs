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
namespace Kursovaya.User
{
    public partial class UserOrder : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public UserOrder()
        {
            InitializeComponent();
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
            LoadOrders();
        }
        public void LoadOrders()
        {
            try
            {
                

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"SELECT 
            o.idorder as idorder,

            CONCAT(pr.produser, space(1), pr.model, ' (x', o.count_processors, ')') AS 'Процессор',
            CONCAT(mb.produser, space(1),mb.model, ' (x', o.count_motherboards, ')') AS 'Материнская плата',
            CONCAT(vc.vender, space(1),vc.model, ' (x', o.count_videocards, ')') AS 'Видеокарта',
            CONCAT(r.produser, space(1), r.model, ' (x', o.count_ram, ')') AS 'ОЗУ',
            CONCAT(cc.produser, space(1), cc.model, ' (x', o.count_cpu_coolers, ')') AS 'Кулер CPU',
            CONCAT(ca.produser, space(1),ca.model, ' (x', o.count_cases, ')') AS 'Корпус',
            CONCAT(cf.produser, space(1),cf.model, ' (x', o.count_case_fan, ')') AS 'Вентиляторы корпуса',
            CONCAT(st.produser, space(1),st.model, ' (x', o.count_storage, ')') AS 'Накопитель',
            CONCAT(ps.produser, space(1),ps.model, ' (x', o.count_power_supplier, ')') AS 'Блок питания',
            CONCAT(ti.produser, space(1),ti.model, ' (x', o.count_thermo_interface, ')') AS 'Термопаста',

            CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END AS 'Доставка',
            CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END AS 'Сборка',
            o.deliveryaddress AS 'Адрес',
            o.ordertime AS 'Дата заказа',
            o.ordercomplitetime AS 'Дата выполнения',
            s.status AS 'Статус'

        FROM `order` o
        LEFT JOIN processors pr ON pr.id = o.id_processors
        LEFT JOIN motherboards mb ON mb.id = o.id_motherboards
        LEFT JOIN videocards vc ON vc.id = o.id_videocards
        LEFT JOIN ram r ON r.id = o.id_ram
        LEFT JOIN cpu_cooler cc ON cc.id = o.id_cpu_cooler
        LEFT JOIN cases ca ON ca.id = o.id_cases
        LEFT JOIN case_coolers cf ON cf.id = o.id_case_coolers
        LEFT JOIN storage st ON st.id = o.id_storage
        LEFT JOIN power_supplier ps ON ps.id = o.id_power_supplier
        LEFT JOIN statuses s ON s.id = o.status
        LEFT JOIN thermo_interface ti ON ti.id = o.id_thermo_interface;";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }            
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Адрес" && e.Value != null)
            {
                string text = e.Value.ToString();
                int hide = text.Length / 2;
                e.Value = text.Substring(0, text.Length - hide) + new string('*', hide);
                e.FormattingApplied = true;
            }
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Статус"].Value.ToString() == "Выполен")
            {
                MessageBox.Show("Нельзя отменить выполненный заказ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Вы действительно хотите отменить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int orderId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["idorder"].Value);
                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();
                            string query = $"UPDATE `order` SET status = 7 where idorder = {orderId};";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            int affRows = cmd.ExecuteNonQuery();
                            if(affRows == 1)
                            {
                                MessageBox.Show("Заказ отменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadOrders();
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
