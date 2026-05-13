using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Administrator
{
    public partial class ReturnOrder : Form
    {
        string OrderStatus;
        bool returnAccept = true; 
        DateTime today = DateTime.Today;
        DateTime orderDate;
        int orderId;
        bool build = false;
        string connStr = ConnectionString.GetConnectionString();
        public ReturnOrder(int order_id, string status)
        {
            orderId = order_id;
            OrderStatus = status;
            InitializeComponent();
            this.MinimumSize = new Size(872, 348);
            this.MaximumSize = new Size(1141, 820);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            ShowOrderDetail(order_id);
            if ((today - orderDate).TotalDays >= 14) MessageBox.Show("С дня заказа прошло 14 дней!\nВозврат нельзя выполнить!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information); returnAccept = false;
            if (build) MessageBox.Show("Так как была выполнена сборка возврат возможен только в случае неисправности какого либо компонента!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public void ShowOrderDetail(int order_id)
        {
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = $@"SELECT  
    o.idorder as idorder,
    o.extra_items,

    pr.model AS 'Процессор',
    pr.produser as 'cpu_produser',
    count_processors,
    pr.cost as 'cpu_cost',

    mb.model AS 'Материнская плата',
    mb.produser as 'mb_produser',
    mb.cost as 'mb_cost',
    o.count_motherboards,

    vc.model AS 'Видеокарта',
    vc.vender  as 'vc_produser',
    vc.memory as 'vc_memory', 
    vc.cost as 'vc_cost',
    o.count_videocards,

    r.model AS 'ОЗУ',
    r.capacity_gb as 'r_capacity_gb',
    r.produser as 'r_produser',
    r.cost as 'r_cost',
    o.count_ram,

    cc.model AS 'Кулер CPU',
    cc.produser as 'cc_produser',
    cc.cost as 'cc_cost',
    o.count_cpu_coolers,

    ca.model AS 'Корпус',
    ca.produser as 'ca_produser',
    ca.cost as 'ca_cost',
    o.count_cases,

    cf.model AS 'Вентиляторы корпуса',
    cf.produser as 'cf_produser',
    cf.scale as 'cf_scale',
    cf.cost as 'cf_cost',
    o.count_case_fan,

    st.model AS 'Накопитель',
    st.produser as 'st_produser',
    st.capacity_gb as 'st_capacity_gb',
    st.cost  as 'st_cost',
    o.count_storage,

    ps.model AS 'Блок питания',
    ps.power as 'ps_power',
    ps.produser as 'ps_produser',
    ps.cost  as 'ps_cost',
    o.count_power_supplier,

    ti.model AS 'Термопаста',
    ti.produser as 'ti_produser',
    ti.cost as 'ti_cost',
    o.count_thermo_interface,
    
    CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END AS 'Доставка',
    CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END AS 'Сборка',

    CONCAT('Сборка: ', CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END, '\n', 'Доставка: ', CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END,'\n\n', o.deliveryaddress) as 'Информация',

    o.deliveryaddress AS 'Адрес',
    o.ordertime AS 'Дата заказа',
    o.ordercomplitetime AS 'Дата выполнения',
    s.status AS 'Статус',
    phone_number AS 'Номер телефона',
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
WHERE idorder = {order_id}
ORDER BY o.idorder ;";
                    MySqlDataAdapter ad = new MySqlDataAdapter(query,conn);
                    ad.Fill(dt);
                }
                foreach (DataRow row in dt.Rows)
                {
                    orderDate = Convert.ToDateTime(row["Дата заказа"].ToString());
                    if(row["Сборка"].ToString() == "Да") build = true;
                    dataGridView1.Columns.Add("prodType","Тип товара");
                    dataGridView1.Columns.Add("model", "Модель");
                    dataGridView1.Columns.Add("produser", "Производитель");
                    dataGridView1.Columns.Add("character", "Характеристика");
                    dataGridView1.Columns.Add("count", "Кол-во");
                    dataGridView1.Columns.Add("cost", "Стоимость");
                    if (!string.IsNullOrEmpty(row["Процессор"].ToString()))
                    {
                        dataGridView1.Rows.Add("Процессор", row["Процессор"].ToString(), row["cpu_produser"].ToString(), "", row["count_processors"].ToString(), row["cpu_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Материнская плата"].ToString()))
                    {
                        dataGridView1.Rows.Add("Материнская плата", row["Материнская плата"].ToString(), row["mb_produser"].ToString(), "", row["count_motherboards"].ToString(), row["mb_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Видеокарта"].ToString()))
                    {
                        dataGridView1.Rows.Add("Видеокарта", row["Видеокарта"].ToString(), row["vc_produser"].ToString(), row["vc_memory"].ToString()+ " ГБ", row["count_videocards"].ToString(), row["vc_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["ОЗУ"].ToString()))
                    {
                        dataGridView1.Rows.Add("ОЗУ", row["ОЗУ"].ToString(), row["r_produser"].ToString(), row["r_capacity_gb"].ToString() + " ГБ", row["count_videocards"].ToString(), row["r_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Кулер CPU"].ToString()))
                    {
                        dataGridView1.Rows.Add("Кулер ЦПУ", row["Кулер CPU"].ToString(), row["cc_produser"].ToString(), " ", row["count_cpu_coolers"].ToString(), row["cc_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Корпус"].ToString()))
                    {
                        dataGridView1.Rows.Add("Корпус", row["Корпус"].ToString(), row["ca_produser"].ToString(), " ", row["count_cases"].ToString(), row["ca_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Вентиляторы корпуса"].ToString()))
                    {
                        dataGridView1.Rows.Add("Вентиляторы корпуса", row["Вентиляторы корпуса"].ToString(), row["cf_produser"].ToString(), row["cf_scale"].ToString() + " мм", row["count_case_fan"].ToString(), row["cf_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Накопитель"].ToString()))
                    {
                        dataGridView1.Rows.Add("Накопитель", row["Накопитель"].ToString(), row["st_produser"].ToString(), row["st_capacity_gb"].ToString() + " ГБ", row["count_storage"].ToString(), row["st_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Блок питания"].ToString()))
                    {
                        dataGridView1.Rows.Add("Блок питания", row["Блок питания"].ToString(), row["ps_produser"].ToString(), row["ps_power"].ToString() + " ВТ", row["count_power_supplier"].ToString(), row["ps_cost"].ToString());
                    }
                    if (!string.IsNullOrEmpty(row["Термопаста"].ToString()))
                    {
                        dataGridView1.Rows.Add("Термопаста", row["Термопаста"].ToString(), row["ti_produser"].ToString(), "", row["count_thermo_interface"].ToString(), row["ti_cost"].ToString());
                    }
                }
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        string produser, character, category, model;

        private void returnProducts_Click(object sender, EventArgs e)
        {
            if (OrderStatus == "Удалён" || OrderStatus == "Отменён" || OrderStatus == "Возвращен") { MessageBox.Show("Заказ ранее был возвращён или отменён!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information); } 
            if (string.IsNullOrEmpty(textBoxReturn.Text)) return;
            if (returnAccept) MessageBox.Show("С дня заказа прошло 14 дней!\nВозврат нельзя выполнить!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult dr =  MessageBox.Show("Вы уверены что хотите вернуть товар(ы)?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                try
                {
                    using (var conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "UPDATE ";
                        switch (category)
                        {
                            case "Процессор":               query += "processors ";         break;
                            case "Материнская плата":       query += "motherboards ";       break;
                            case "Видеокарта":              query += "videocards ";         break;
                            case "ОЗУ":                     query += "ram ";                break;
                            case "Кулер ЦПУ":               query += "cpu_cooler ";         break;
                            case "Корпус":                  query += "cases ";              break;
                            case "Вентиляторы корпуса":     query += "case_coolers ";       break;
                            case "Накопитель":              query += "storage ";            break;
                            case "Блок питания":            query += "power_supplier ";     break;
                            case "Термопаста":              query += "thermo_interface ";   break;
                        }
                        query += $"SET inStock = inStock + {Convert.ToInt32(numericReturn.Value)} WHERE model = '{model}' and ";
                        if (category == "Материнская плата") query += $" vender = '{produser}'";
                        else query += $" produser = '{produser}'";
                        MySqlCommand cmd = new MySqlCommand(query, conn);   
                        int returnFromDB = cmd.ExecuteNonQuery();
                        if (returnFromDB > 0)
                        {
                            string query2 = $"UPDATE `db95`.`order` SET `status` = '8' WHERE (`idorder` = {orderId}); ";
                            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                            int res = cmd2.ExecuteNonQuery();
                            if (res > 0)
                            {
                                MessageBox.Show("Возврат успешно выполнен! Статус заказа изменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                            
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            model = dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();
            category = dataGridView1.Rows[e.RowIndex].Cells["prodType"].Value.ToString();
            character = dataGridView1.Rows[e.RowIndex].Cells["character"].Value.ToString();
            produser = dataGridView1.Rows[e.RowIndex].Cells["produser"].Value.ToString();
            textBoxReturn.Text = dataGridView1.Rows[e.RowIndex].Cells["produser"].Value.ToString() + " " + dataGridView1.Rows[e.RowIndex].Cells["model"].Value.ToString();
            numericReturn.Value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["count"].Value);
            numericReturn.Maximum = numericReturn.Value;
        }
    }
}
