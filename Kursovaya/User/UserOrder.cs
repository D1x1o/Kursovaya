using Kursovaya.Administrator;
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
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            LoadOrders();
        }
        public void LoadOrders() // функция отображения заказов 
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr)) // инициируем подключение к БД 
                {
                    conn.Open(); // открываем подключение 
                    // формируем запрос на получение данных о заказах 
                    string query = $@"SELECT  
    o.idorder as idorder,
    o.extra_items,

    CONCAT(pr.produser, ' ', pr.model, ' (x', o.count_processors, ')') AS 'Процессор',
    o.count_processors,
    pr.cost,

    CONCAT(mb.produser, ' ', mb.model, ' (x', o.count_motherboards, ')') AS 'Материнская плата',
    mb.cost,
    o.count_motherboards,

    CONCAT(vc.vender, ' ', vc.model, ' (x', o.count_videocards, ')') AS 'Видеокарта',
    vc.cost,
    o.count_videocards,

    CONCAT(r.produser, ' ', r.model, ' ', r.capacity_gb, ' ГБ (x', o.count_ram, ')') AS 'ОЗУ',
    r.cost,
    o.count_ram,

    CONCAT(cc.produser, ' ', cc.model, ' (x', o.count_cpu_coolers, ')') AS 'Кулер CPU',
    cc.cost,
    o.count_cpu_coolers,

    CONCAT(ca.produser, ' ', ca.model, ' (x', o.count_cases, ')') AS 'Корпус',
    ca.cost,
    o.count_cases,

    CONCAT(cf.produser, ' ', cf.model, ' (x', o.count_case_fan, ')') AS 'Вентиляторы корпуса',
    cf.cost,
    o.count_case_fan,

    CONCAT(st.produser, ' ', st.model, ' ', st.capacity_gb, ' ГБ (x', o.count_storage, ')') AS 'Накопитель',
    st.cost,
    o.count_storage,

    CONCAT(ps.produser, ' ', ps.model, ' ', ps.power, ' ВАТТ (x', o.count_power_supplier, ')') AS 'Блок питания',
    ps.cost,
    o.count_power_supplier,

    CONCAT(ti.produser, ' ', ti.model, ' (x', o.count_thermo_interface, ')') AS 'Термопаста',
    ti.cost,
    o.count_thermo_interface,
    
    CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END AS 'Доставка',
    CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END AS 'Сборка',

    CONCAT('Сборка: ', CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END, '\n', 'Доставка: ', CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END,'\n\n', o.deliveryaddress) as 'Информация',

    o.deliveryaddress AS 'Адрес',
    o.ordertime AS 'Дата заказа',
    o.ordercomplitetime AS 'Дата выполнения',
    s.status AS 'Статус',
    result_cost AS 'Стоимость заказа' 


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
LEFT JOIN thermo_interface ti ON ti.id = o.id_thermo_interface
ORDER BY o.idorder; ";


                    // отображаем данные в DGV
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Добавляем колонку для отображения товаров дополнительных категорий
                    if (!dt.Columns.Contains("FormattedExtra"))
                        dt.Columns.Add("FormattedExtra");

                    // Форматируем 
                    foreach (DataRow row in dt.Rows)
                    {
                        string raw = row["extra_items"]?.ToString();

                        if (string.IsNullOrWhiteSpace(raw))
                        {
                            row["FormattedExtra"] = "";
                            continue;
                        }

                        string[] parts = raw.Split(' ');

                        if (parts.Length < 2)
                        {
                            row["FormattedExtra"] = raw;
                            continue;
                        }

                        string quantity = parts[parts.Length - 2]; // добавляем количество этого товара в заказе
                        string itemName = string.Join(" ", parts.Take(parts.Length - 3));

                        row["FormattedExtra"] = $"{itemName} (x{quantity})"; // отображаем готовое значение строки




                    }
                    if (!dt.Columns.Contains("orderSetUp"))
                        dt.Columns.Add("orderSetUp");
                    bool det = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        det = false;
                        string orderSetupStr = "";
                        void AddIfNotEmpty(string colName)
                        {
                            var val = GetSafe(row, colName);
                            if (!string.IsNullOrWhiteSpace(val))
                            {
                                if (det) orderSetupStr += "\n";
                                orderSetupStr += val;
                                det = true;
                            }
                        }

                        AddIfNotEmpty("Процессор");
                        AddIfNotEmpty("Материнская плата");
                        AddIfNotEmpty("Видеокарта");
                        AddIfNotEmpty("ОЗУ");
                        AddIfNotEmpty("Кулер CPU");
                        AddIfNotEmpty("Корпус");
                        AddIfNotEmpty("Вентиляторы корпуса");
                        AddIfNotEmpty("Накопитель");
                        AddIfNotEmpty("Блок питания");
                        AddIfNotEmpty("Термопаста");
                        AddIfNotEmpty("FormattedExtra");
                        row["orderSetUp"] = orderSetupStr;

                    }
                    //Привязка данных к DGV
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    // Скрываем лишнее, но нужное  :)
                    dataGridView1.Columns["extra_items"].Visible = false;
                    dataGridView1.Columns["Дата выполнения"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dataGridView1.Columns["Статус"].Visible = false;
                    dataGridView1.Columns["Адрес"].Visible = false;
                    //dataGridView1.Columns["Информация"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    //dataGridView1.Columns["Информация"].Width = 200;
                    dataGridView1.Columns["Стоимость заказа"].Visible = false;
                    dataGridView1.Columns["FormattedExtra"].DisplayIndex = dataGridView1.ColumnCount - 7;
                    dataGridView1.Columns["orderSetUp"].DisplayIndex = 1;
                    dataGridView1.Columns["orderSetUp"].Visible = false;
                    dataGridView1.Columns["orderSetUp"].HeaderText = "Состав заказа";
                    dataGridView1.Columns["idorder"].Visible = false;
                    dataGridView1.Columns["count_processors"].Visible = false;
                    dataGridView1.Columns["count_motherboards"].Visible = false;
                    dataGridView1.Columns["count_videocards"].Visible = false;
                    dataGridView1.Columns["count_ram"].Visible = false;
                    dataGridView1.Columns["count_cpu_coolers"].Visible = false;
                    dataGridView1.Columns["count_cases"].Visible = false;
                    dataGridView1.Columns["count_case_fan"].Visible = false;
                    dataGridView1.Columns["count_storage"].Visible = false;
                    dataGridView1.Columns["count_power_supplier"].Visible = false;
                    dataGridView1.Columns["count_thermo_interface"].Visible = false;

                    dataGridView1.Columns["Процессор"].Visible = false;
                    dataGridView1.Columns["Материнская плата"].Visible = false;
                    dataGridView1.Columns["ОЗУ"].Visible = false;
                    dataGridView1.Columns["Кулер CPU"].Visible = false;
                    dataGridView1.Columns["Корпус"].Visible = false;
                    dataGridView1.Columns["Вентиляторы корпуса"].Visible = false;
                    dataGridView1.Columns["Накопитель"].Visible = false;
                    dataGridView1.Columns["Блок питания"].Visible = false;
                    dataGridView1.Columns["Термопаста"].Visible = false;
                    dataGridView1.Columns["FormattedExtra"].Visible = false;
                    dataGridView1.Columns["Видеокарта"].Visible = false;

                    dataGridView1.Columns["cost"].Visible = false;
                    dataGridView1.Columns["cost1"].Visible = false;
                    dataGridView1.Columns["cost2"].Visible = false;
                    dataGridView1.Columns["cost3"].Visible = false;
                    dataGridView1.Columns["cost4"].Visible = false;
                    dataGridView1.Columns["cost5"].Visible = false;
                    dataGridView1.Columns["cost6"].Visible = false;
                    dataGridView1.Columns["cost7"].Visible = false;
                    dataGridView1.Columns["cost8"].Visible = false;
                    dataGridView1.Columns["cost9"].Visible = false;

                    dataGridView1.Columns["FormattedExtra"].HeaderText = "Товары доп. категорий"; // переименновываем заголовок столбца доп. категорий


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // обратботка ошибок
            }
        }
        string GetSafe(DataRow r, string col)
        {
            return r[col] == DBNull.Value ? "" : r[col].ToString();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string compound = dataGridView1.Rows[e.RowIndex].Cells["orderSetUp"].Value.ToString();
            var od = new OrderDetail(compound);
            od.ShowDialog();
        }
    }
}
