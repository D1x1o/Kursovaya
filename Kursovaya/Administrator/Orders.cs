using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Administrator
{
    public partial class Orders : Form
    {
        int rowIndex=1;
        string connStr = ConnectionString.GetConnectionString();
        ContextMenuStrip rowMenu = new ContextMenuStrip();
        public Orders()
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
            rowMenu.Items.Add("Редактировать", null, Edit_Click);
            rowMenu.Items.Add("Получить чек", null, Check_Click);

            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
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
LEFT JOIN thermo_interface ti ON ti.id = o.id_thermo_interface
ORDER BY o.idorder;";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    // ===== Добавляем колонку для форматированных extra товаров =====
                    if (!dt.Columns.Contains("FormattedExtra"))
                        dt.Columns.Add("FormattedExtra");

                    // ===== Форматируем extra_items =====
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

                        string quantity = parts[parts.Length - 2];
                        string itemName = string.Join(" ", parts.Take(parts.Length - 3));

                        row["FormattedExtra"] = $"{itemName} (x{quantity})";
                    }

                    // ===== Привязка к DataGridView =====
                    dataGridView1.DataSource = dt;

                    // ===== Скрываем лишнее =====
                    dataGridView1.Columns["extra_items"].Visible = false;
                    dataGridView1.Columns["FormattedExtra"].DisplayIndex = dataGridView1.ColumnCount - 7;
                    dataGridView1.Columns["idorder"].Visible = false;
                    dataGridView1.Columns["idorder"].Visible = false;
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

                    dataGridView1.Columns["FormattedExtra"].HeaderText = "Товары Extra";

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public class TableColumn
        {
            public string systemName { get; set; }
            public string displayName { get; set; }
        }

        public class TableInfo
        {
            public string systemName { get; set; }
            public string displayName { get; set; }
            public List<TableColumn> columns { get; set; }
        }

        public class OrderHelper
        {
            private string connStr;

            public OrderHelper()
            {
                connStr = ConnectionString.GetConnectionString();
            }

            // Метод для добавления extra_items
            public void AddExtraItems(
    DataGridViewRow row,
    List<string> names,
    List<int> prices,
    List<int> counts,
    List<TableInfo> tables)
            {
                string extra = row.Cells["extra_items"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(extra)) return;

                string[] lines = extra.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    string[] parts = line.Split(' ');

                    if (parts.Length < 3) continue;

                    string itemName = string.Join(" ", parts.Take(parts.Length - 3)); // Название без ID и количества
                    int itemId = int.Parse(parts[parts.Length - 3]);
                    int quantity = int.Parse(parts[parts.Length - 2]);

                    // 🔹 Проверяем, есть ли уже такой товар
                    if (names.Contains(itemName))
                        continue; // если есть — пропускаем

                    string tableName = tables[0].systemName; // Берём таблицу из JSON

                    int price = 0;
                    using (var conn = new MySql.Data.MySqlClient.MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = $"SELECT cost FROM {tableName} WHERE id=@id";
                        using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", itemId);
                            object result = cmd.ExecuteScalar();
                            if (result != null) price = Convert.ToInt32(result);
                        }
                    }

                    names.Add(itemName);
                    prices.Add(price);
                    counts.Add(quantity);
                }
            }
        }
        public class TablesWrapper
        {
            public List<TableInfo> tables { get; set; }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idorder"].Value);
            MessageBox.Show($"Редактировать строку с id = {id}");
        }
        string CleanValue(string value)
        {
            return System.Text.RegularExpressions.Regex
                .Replace(value, @"\s*\(x\d+\)", "")
                .Trim();
        }
        private void Check_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            List<int> prices = new List<int>();
            List<int> counts = new List<int>();
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // ===== ОСНОВНЫЕ ТОВАРЫ =====
            names.Add(CleanValue(row.Cells["Процессор"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_processors"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Материнская плата"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost1"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_motherboards"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Видеокарта"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost2"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_videocards"].Value ?? 0));

            names.Add(CleanValue(row.Cells["ОЗУ"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost3"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_ram"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Кулер CPU"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost4"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_cpu_coolers"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Корпус"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost5"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_cases"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Вентиляторы корпуса"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost6"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_case_fan"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Накопитель"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost7"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_storage"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Блок питания"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost8"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_power_supplier"].Value ?? 0));

            names.Add(CleanValue(row.Cells["Термопаста"].Value?.ToString()));
            prices.Add(Convert.ToInt32(row.Cells["cost9"].Value ?? 0));
            counts.Add(Convert.ToInt32(row.Cells["count_thermo_interface"].Value ?? 0));

            // 1️⃣ Читаем JSON
            string json = File.ReadAllText("tables.json");

            // 2️⃣ Десериализуем через обёртку
            TablesWrapper wrapper = JsonConvert.DeserializeObject<TablesWrapper>(json);

            // 3️⃣ Получаем список таблиц
            List<TableInfo> tables = wrapper.tables;

            // 4️⃣ Вызываем AddExtraItems
            OrderHelper helper = new OrderHelper();
            helper.AddExtraItems(row, names, prices, counts, tables);

            // ===== EXTRA ТОВАРЫ =====
            string extra = row.Cells["FormattedExtra"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(extra))
            {
                string[] extraItems = extra.Split('\n');

                foreach (var item in extraItems)
                {
                    if (string.IsNullOrWhiteSpace(item))
                        continue;

                    int xIndex = item.LastIndexOf("(x");

                    if (xIndex == -1)
                        continue;

                    string name = item.Substring(0, xIndex).Trim();
                    string countStr = item.Substring(xIndex + 2).Replace(")", "");

                    int count = Convert.ToInt32(countStr);

                    // Если у extra нет цены — ставим 0
                    prices.Add(0);

                    counts.Add(count);
                }
            }
            bool del, bui;
            if(row.Cells["Доставка"].Value.ToString() == "Да") { del = true; } else { del = false; }
            if (row.Cells["Сборка"].Value.ToString() == "Нет") {  bui = true; } else { bui = false; }
            //SaveMakeCheck(string[] itemsNames, int[] itemsCosts, int[] itemsCounts, string orderDateTime, string orderCompDateTime)
            SaveCheck SC = new SaveCheck();
            SC.SaveMakeCheck(names.ToArray(), prices.ToArray(), counts.ToArray(), row.Cells["Дата заказа"].Value.ToString(), row.Cells["Дата выполнения"].Value.ToString(), del, bui);
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
                            if (affRows == 1)
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

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;

                rowMenu.Show(Cursor.Position);
            }
        }
    }
}
