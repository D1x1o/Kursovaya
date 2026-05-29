using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

// ФОРМА работы с заказами

namespace Kursovaya.Administrator
{
    public partial class Orders : Form
    {
        
        int rowIndex=1; // переменая хранящая номер строки в DGV с которой работаем 
        string connStr = ConnectionString.GetConnectionString(); // переменная хранящая строку подключения из класса
        ContextMenuStrip rowMenu = new ContextMenuStrip(); // экземпляр класса выпадающего меню
        
        public Orders()
        {

            this.MinimumSize = new Size(1329, 735);
            this.MaximumSize = new Size(2000, 1000);
            InitializeComponent();
            // настройки дизайна DGV 
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // добавляем в выпадающее меню элементы
            rowMenu.Items.Add("Редактировать", null, Edit_Click);
            //rowMenu.Items.Add("Получить чек", null, Check_Click);
            rowMenu.Items.Add("Возврат", null, Return_Click);

            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown; // подписываемся на событие нажатия на нажатие на ячейку
            LoadOrders(); // отображаем заказы
            FillQuarterComboBox();
            dataGridView1.Refresh();

        }
        private void Return_Click(object sender, EventArgs e) // обработка нажатия на кнопку "Возврат" в выпадающем меню
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idorder"].Value); // получаем айди заказа с которым работаем
            string status = dataGridView1.SelectedRows[0].Cells["Статус"].Value.ToString(); // получаем айди заказа с которым работаем
            ReturnOrder EO = new ReturnOrder(id, status); // эзмепляр класса возврата заказа
            EO.ShowDialog(); // отображаем форму
            LoadOrders();
        }

        private void FillQuarterComboBox() // функция запоняет выпадающий список кварталами года для получения отчёта
        {
            try
            {
                quarterForReport.Items.Clear(); // очищаем 
                int startYear = 2025; // год начала
                DateTime now = DateTime.Now; // текущая дата и время            
                int currentQuarter = (now.Month - 1) / 3 + 1; // текущий квартал            
                int endYear = now.Year; // текущий год

                for (int year = startYear; year <= endYear; year++)
                {
                    int maxQuarter = 4;
                    if (year == endYear)
                        maxQuarter = currentQuarter; // включаем текущий квартал
                    for (int quarter = 1; quarter <= maxQuarter; quarter++)
                    {
                        quarterForReport.Items.Add($"Квартал: {quarter}, год: {year}"); // добавляем кварталы
                    }
                }
                // Опционально: выбрать последний квартал в списке по умолчанию
                if (quarterForReport.Items.Count > 0)
                    quarterForReport.SelectedIndex = quarterForReport.Items.Count - 1;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void MAthAllOrders()
        {
            label2.Text = "Всего заказов: " + dataGridView1.RowCount;
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
                    dataGridView1.Columns["Номер телефона"].DisplayIndex = dataGridView1.ColumnCount - 1;
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


                    MAthAllOrders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // обратботка ошибок
            }
        }
        public class TableColumn // класс столбцов DGV
        {
            public string systemName { get; set; } // системное имя на алглийском
            public string displayName { get; set; } // отображаемое имя на русском
        }

        public class TableInfo // класс данных р таблице
        {
            public string systemName { get; set; } // системное имя на алглийском
            public string displayName { get; set; } // отображаемое имя на русском
            public List<TableColumn> columns { get; set; } // список колонок DGV
        }

        public class OrderHelper // класс строки подключения
        {
            
            private string connStr; // строка подключения

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

                    // проверяем, есть ли уже такой товар
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

                    names.Add(itemName); // добавляем имена товаров в список
                    prices.Add(price); // добавляем цены в соответствующий список 
                    counts.Add(quantity); // добавляем количество товаров в свой список
                }
            }
        }
        public class TablesWrapper // класс таблиц
        {
            public List<TableInfo> tables { get; set; }
        }
        private void Edit_Click(object sender, EventArgs e) // обраболтчик нажатия на кнопки "Редактировать в выпадающем списке"
        {
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idorder"].Value); // получаем айди товара с которым работаем
            EditOrder EO = new EditOrder(id); // эзмепляр класса редактирования заказа
            EO.ShowDialog(); // отображаем форму
            LoadOrders();
        }
        string CleanValue(string value) // очищаем значение имени товара от лишнего
        {
            return System.Text.RegularExpressions.Regex
                .Replace(value, @"\s*\(x\d+\)", "")
                .Trim();
        }
        private void Check_Click(object sender, EventArgs e) // обработка нажатия на кнопку "Получить чек" в выпадающем меню
        {
            List<string> names = new List<string>(); // список имен товаров
            List<int> prices = new List<int>(); // список цен товаров
            List<int> counts = new List<int>(); // список количества товаров
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            // ОСНОВНЫЕ ТОВАРЫ  (добавляем их информацию в списки)
            names.Add(CleanValue(row.Cells["Процессор"].Value?.ToString()));
            prices.Add(row.Cells["cost"].Value != null && int.TryParse(row.Cells["cost"].Value.ToString(), out int p0) ? p0 : 0);
            counts.Add(row.Cells["count_processors"].Value != null && int.TryParse(row.Cells["count_processors"].Value.ToString(), out int c0) ? c0 : 0);

            names.Add(CleanValue(row.Cells["Материнская плата"].Value?.ToString()));
            prices.Add(row.Cells["cost1"].Value != null && int.TryParse(row.Cells["cost1"].Value.ToString(), out int p1) ? p1 : 0);
            counts.Add(row.Cells["count_motherboards"].Value != null && int.TryParse(row.Cells["count_motherboards"].Value.ToString(), out int c1) ? c1 : 0);

            names.Add(CleanValue(row.Cells["Видеокарта"].Value?.ToString()));
            prices.Add(row.Cells["cost2"].Value != null && int.TryParse(row.Cells["cost2"].Value.ToString(), out int p2) ? p2 : 0);
            counts.Add(row.Cells["count_videocards"].Value != null && int.TryParse(row.Cells["count_videocards"].Value.ToString(), out int c2) ? c2 : 0);

            names.Add(CleanValue(row.Cells["ОЗУ"].Value?.ToString()));
            prices.Add(row.Cells["cost3"].Value != null && int.TryParse(row.Cells["cost3"].Value.ToString(), out int p3) ? p3 : 0);
            counts.Add(row.Cells["count_ram"].Value != null && int.TryParse(row.Cells["count_ram"].Value.ToString(), out int c3) ? c3 : 0);

            names.Add(CleanValue(row.Cells["Кулер CPU"].Value?.ToString()));
            prices.Add(row.Cells["cost4"].Value != null && int.TryParse(row.Cells["cost4"].Value.ToString(), out int p4) ? p4 : 0);
            counts.Add(row.Cells["count_cpu_coolers"].Value != null && int.TryParse(row.Cells["count_cpu_coolers"].Value.ToString(), out int c4) ? c4 : 0);

            names.Add(CleanValue(row.Cells["Корпус"].Value?.ToString()));
            prices.Add(row.Cells["cost5"].Value != null && int.TryParse(row.Cells["cost5"].Value.ToString(), out int p5) ? p5 : 0);
            counts.Add(row.Cells["count_cases"].Value != null && int.TryParse(row.Cells["count_cases"].Value.ToString(), out int c5) ? c5 : 0);

            names.Add(CleanValue(row.Cells["Вентиляторы корпуса"].Value?.ToString()));
            prices.Add(row.Cells["cost6"].Value != null && int.TryParse(row.Cells["cost6"].Value.ToString(), out int p6) ? p6 : 0);
            counts.Add(row.Cells["count_case_fan"].Value != null && int.TryParse(row.Cells["count_case_fan"].Value.ToString(), out int c6) ? c6 : 0);

            names.Add(CleanValue(row.Cells["Накопитель"].Value?.ToString()));
            prices.Add(row.Cells["cost7"].Value != null && int.TryParse(row.Cells["cost7"].Value.ToString(), out int p7) ? p7 : 0);
            counts.Add(row.Cells["count_storage"].Value != null && int.TryParse(row.Cells["count_storage"].Value.ToString(), out int c7) ? c7 : 0);

            names.Add(CleanValue(row.Cells["Блок питания"].Value?.ToString()));
            prices.Add(row.Cells["cost8"].Value != null && int.TryParse(row.Cells["cost8"].Value.ToString(), out int p8) ? p8 : 0);
            counts.Add(row.Cells["count_power_supplier"].Value != null && int.TryParse(row.Cells["count_power_supplier"].Value.ToString(), out int c8) ? c8 : 0);

            names.Add(CleanValue(row.Cells["Термопаста"].Value?.ToString()));
            prices.Add(row.Cells["cost9"].Value != null && int.TryParse(row.Cells["cost9"].Value.ToString(), out int p9) ? p9 : 0);
            counts.Add(row.Cells["count_power_supplier"].Value != null && int.TryParse(row.Cells["count_power_supplier"].Value.ToString(), out int c9) ? c9 : 0);

            // читаем JSON
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pepeShopFolder = Path.Combine(appDataPath, "pepeShop");
            string path = Path.Combine(pepeShopFolder, "tables.json");

            string json = File.ReadAllText(path);

            // десериализуем через обёртку
            TablesWrapper wrapper = JsonConvert.DeserializeObject<TablesWrapper>(json);

            // получаем список таблиц
            List<TableInfo> tables = wrapper.tables;

            // вызываем AddExtraItems
            OrderHelper helper = new OrderHelper();
            helper.AddExtraItems(row, names, prices, counts, tables);

            // товары дополнительных категорий
            string extra = row.Cells["FormattedExtra"].Value?.ToString();

            if (!string.IsNullOrWhiteSpace(extra)) // если товар если а не пустая строка
            {
                string[] extraItems = extra.Split('\n'); 

                foreach (var item in extraItems) // перебираем все товары в ячейке дополнительных категорий
                {
                    if (string.IsNullOrWhiteSpace(item)) // если товара нет, то есть ячейка пуста - пропускаем её
                        continue;

                    int xIndex = item.LastIndexOf("(x"); // получем каличество

                    if (xIndex == -1) // если количество -1 то тоже пропускаем товар
                        continue;

                    string name = item.Substring(0, xIndex).Trim(); // получаем из ячейки имя товара
                    string countStr = item.Substring(xIndex + 2).Replace(")", ""); // также получаем количестов товара но типа строка

                    int count = Convert.ToInt32(countStr); // переобразуем строку в число

                    // если у товара доп категории нет цены — ставим 0
                    prices.Add(0);

                    counts.Add(count); // добавляем в список количества
                }
            }
            bool del, bui; // пустые булевы выбрал ли пользователь доставку и сборку соответственно
            if(row.Cells["Доставка"].Value.ToString() == "Да") { del = true; } else { del = false; } // заполняем булеву доставки
            if (row.Cells["Сборка"].Value.ToString() == "Да") {  bui = true; } else { bui = false; } // заполняем булеву сборки
            SaveCheck SC = new SaveCheck(); // создаём экземпляр класса сохранения чека
            SC.SaveMakeCheck(names.ToArray(), prices.ToArray(), counts.ToArray(), row.Cells["Дата заказа"].Value.ToString(), row.Cells["Дата выполнения"].Value.ToString(), del, bui, row.Cells["Номер телефона"].Value.ToString(), row.Cells["Адрес"].Value.ToString()); // и вызываем отображение чека 
        }

        

        private void CancelOrder_Click(object sender, EventArgs e) // обработчик нажатия кнопки "Отменить заказ" в выпадающем меню
        {
            if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Статус"].Value.ToString() != "Новый") // если заказ уже имеет статус - выполнен то его нельзя отменить 
            {
                MessageBox.Show($"Нельзя отменить заказ в статусе {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Статус"].Value.ToString()}!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // сообщаем пользователю
                return; // выходим из функции
            }
            else
            {
                try
                {
                    // спрашиваем действительно ли пользователь хочет удалить заказ
                    DialogResult dr = MessageBox.Show("Вы действительно хотите отменить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes) // если ответ да
                    {
                        int orderId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["idorder"].Value); // получаем айди заказа
                        using (MySqlConnection conn = new MySqlConnection(connStr)) // инициируем подключение
                        { 
                            conn.Open(); // открываем подключение
                            string query = $"UPDATE `order` SET status = 7 where idorder = {orderId};"; // запрос на смену статуса заказа
                            MySqlCommand cmd = new MySqlCommand(query, conn); // выполняем запрос
                            int affRows = cmd.ExecuteNonQuery(); // получаем ответ(число) сколько строк в БД было именено
                            if (affRows == 1) // если строк изменено 1, то это успешно выполенный запрос
                            {
                                MessageBox.Show("Заказ отменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information); // сообщаем об успехе
                                LoadOrders(); // снова отображаем все заказы
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); } // обработчик ошибок
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) // обработчик нажатия на ячейку
        {
            rowIndex = e.RowIndex; // сохраняем индекс на какую строку нажали
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0) // если это строка с заказом и было нажатие правой кнопки мыши (ПКМ)
            {
                dataGridView1.ClearSelection(); 
                dataGridView1.Rows[e.RowIndex].Selected = true; // выбираем всю строку

                rowMenu.Show(Cursor.Position); // отображаем выпадающее меню
            }
        }

        private void getReport_Click(object sender, EventArgs e)
        {
            if (quarterForReport.SelectedItem == null)
            {
                MessageBox.Show("Выберите квартал!");
                return;
            }

            // Парсим выбранный квартал
            string selected = quarterForReport.SelectedItem.ToString();

            string[] parts = selected.Split(',');
            int quarter = int.Parse(parts[0].Split(':')[1].Trim());
            int year = int.Parse(parts[1].Split(':')[1].Trim());

            // Определяем даты начала и конца квартала
            int startMonth = (quarter - 1) * 3 + 1;
            DateTime startDate = new DateTime(year, startMonth, 1);
            DateTime endDate = startDate.AddMonths(3).AddSeconds(-1);

            // Загружаем данные из БД
            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                // SQL 
                string query = $@"SELECT o.idorder as 'Номер заказа',

CONCAT(pr.produser, ' ', pr.model, ' (x', o.count_processors, ')') AS 'Процессор',
CONCAT(mb.produser, ' ', mb.model, ' (x', o.count_motherboards, ')') AS 'Материнская плата',
CONCAT(vc.vender, ' ', vc.model, ' (x', o.count_videocards, ')') AS 'Видеокарта',
CONCAT(r.produser, ' ', r.model, ' ', r.capacity_gb, ' ГБ (x', o.count_ram, ')') AS 'ОЗУ',
CONCAT(cc.produser, ' ', cc.model, ' (x', o.count_cpu_coolers, ')') AS 'Кулер CPU',
CONCAT(ca.produser, ' ', ca.model, ' (x', o.count_cases, ')') AS 'Корпус',
CONCAT(cf.produser, ' ', cf.model, ' (x', o.count_case_fan, ')') AS 'Вентиляторы корпуса',
CONCAT(st.produser, ' ', st.model, ' ', st.capacity_gb, ' ГБ (x', o.count_storage, ')') AS 'Накопитель',
CONCAT(ps.produser, ' ', ps.model, ' ', ps.power, ' ВАТТ (x', o.count_power_supplier, ')') AS 'Блок питания',
CONCAT(ti.produser, ' ', ti.model, ' (x', o.count_thermo_interface, ')') AS 'Термопаста',
CASE WHEN o.delivery = 'True' THEN 'Да' ELSE 'Нет' END AS 'Доставка',
CASE WHEN o.build = 'True' THEN 'Да' ELSE 'Нет' END AS 'Сборка',

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

WHERE ordertime BETWEEN '{startDate.ToString("yyyy-MM-dd")}'
AND '{endDate.ToString("yyyy-MM-dd")}'
ORDER BY o.idorder";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Заказы за выбранный квартал отсутствуют!","Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet sheet = workbook.Sheets[1];

            try
            {
                int orderColumn = dt.Columns["Номер заказа"].Ordinal;
                int dateColumn = dt.Columns["Дата заказа"].Ordinal;
                int priceColumn = dt.Columns["Стоимость заказа"].Ordinal;

                // Заголовки таблицы
                string[] headers =
                {
            "Номер заказа",
            "Дата оформления",
            "Стоимость заказа"
        };

                // ===== ПЕРВАЯ СТРОКА =====
                Excel.Range firstRow = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 3]];
                firstRow.Merge();

                firstRow.Value = "pepeShop - отчёт о заказах";
                firstRow.Font.Bold = true;
                firstRow.Font.Size = 18;
                firstRow.Interior.Color = Color.FromArgb(226, 239, 218);
                firstRow.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                firstRow.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ===== ВТОРАЯ СТРОКА =====
                Excel.Range secondRow = sheet.Range[sheet.Cells[2, 1], sheet.Cells[2, 3]];
                secondRow.Merge();

                secondRow.Value = "Период: " + selected;
                secondRow.Font.Bold = true;
                secondRow.Font.Size = 15;
                secondRow.Interior.Color = Color.FromArgb(226, 239, 218);
                secondRow.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                secondRow.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ===== ЗАГОЛОВКИ =====
                for (int i = 0; i < headers.Length; i++)
                {
                    Excel.Range headerCell = sheet.Cells[6, i + 1];

                    headerCell.Value = headers[i];
                    headerCell.Font.Bold = true;
                    headerCell.Font.Size = 12;
                    headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerCell.Interior.Color = Color.FromArgb(180, 198, 231);
                    headerCell.Font.Color = Color.White;
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                double totalRevenue = 0;

                // Доход по месяцам
                Dictionary<string, double> monthlyRevenue =
                    new Dictionary<string, double>();

                // ===== ДАННЫЕ =====
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    int excelRow = r + 7;

                    // Номер заказа
                    sheet.Cells[excelRow, 1] = dt.Rows[r][orderColumn];

                    // Дата
                    DateTime orderDate =
                        Convert.ToDateTime(dt.Rows[r][dateColumn]);

                    sheet.Cells[excelRow, 2] =
                        orderDate.ToString("dd.MM.yyyy");

                    // Стоимость
                    double price =
                        Convert.ToDouble(dt.Rows[r][priceColumn]);

                    sheet.Cells[excelRow, 3] = price;

                    totalRevenue += price;

                    // Прибыль по месяцам
                    string monthName = orderDate.ToString("MMMM");

                    if (!monthlyRevenue.ContainsKey(monthName))
                        monthlyRevenue[monthName] = 0;

                    monthlyRevenue[monthName] += price;

                    // Оформление строк
                    for (int c = 1; c <= 3; c++)
                    {
                        Excel.Range dataCell = sheet.Cells[excelRow, c];

                        dataCell.Borders.LineStyle =
                            Excel.XlLineStyle.xlContinuous;

                        dataCell.HorizontalAlignment =
                            Excel.XlHAlign.xlHAlignCenter;

                        dataCell.WrapText = true;

                        // Чередование цветов
                        if (r % 2 == 0)
                            dataCell.Interior.Color =
                                Color.FromArgb(242, 242, 242);
                        else
                            dataCell.Interior.Color =
                                Color.FromArgb(255, 255, 255);
                    }

                    // Формат валюты
                    Excel.Range priceCell = sheet.Cells[excelRow, 3];
                    priceCell.NumberFormat = "#,##0 ₽";
                }

                // ===== ИТОГ =====
                int totalRow = dt.Rows.Count + 7;

                Excel.Range totalLabel = sheet.Cells[totalRow, 2];
                totalLabel.Value = "Выручка за квартал:";
                totalLabel.Font.Bold = true;
                totalLabel.Font.Size = 12;
                totalLabel.Interior.Color = Color.FromArgb(198, 224, 180);
                totalLabel.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                totalLabel.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Excel.Range totalValue = sheet.Cells[totalRow, 3];
                totalValue.Value = totalRevenue;
                totalValue.Font.Bold = true;
                totalValue.Font.Size = 12;
                totalValue.NumberFormat = "#,##0 ₽";
                totalValue.Interior.Color = Color.FromArgb(198, 224, 180);
                totalValue.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                totalValue.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // ===== ТАБЛИЦА ПРИБЫЛИ ПО МЕСЯЦАМ =====
                int chartStartRow = totalRow + 5;

                // Заголовок блока
                Excel.Range profitTitle =
                    sheet.Range[sheet.Cells[chartStartRow, 1],
                    sheet.Cells[chartStartRow, 2]];

                profitTitle.Merge();

                profitTitle.Value = "Прибыль по месяцам";
                profitTitle.Font.Bold = true;
                profitTitle.Font.Size = 14;
                profitTitle.HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;

                profitTitle.Interior.Color =
                    Color.FromArgb(180, 198, 231);

                profitTitle.Font.Color = Color.White;

                profitTitle.Borders.LineStyle =
                    Excel.XlLineStyle.xlContinuous;

                // Заголовки таблицы
                chartStartRow++;

                Excel.Range monthHeader =
                    sheet.Cells[chartStartRow, 1];

                monthHeader.Value = "Месяц";
                monthHeader.Font.Bold = true;
                monthHeader.HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;

                monthHeader.Interior.Color =
                    Color.FromArgb(221, 235, 247);

                monthHeader.Borders.LineStyle =
                    Excel.XlLineStyle.xlContinuous;

                Excel.Range profitHeader =
                    sheet.Cells[chartStartRow, 2];

                profitHeader.Value = "Прибыль";
                profitHeader.Font.Bold = true;
                profitHeader.HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;

                profitHeader.Interior.Color =
                    Color.FromArgb(221, 235, 247);

                profitHeader.Borders.LineStyle =
                    Excel.XlLineStyle.xlContinuous;

                // Данные таблицы
                int currentRow = chartStartRow + 1;

                foreach (var item in monthlyRevenue)
                {
                    Excel.Range monthCell =
                        sheet.Cells[currentRow, 1];

                    monthCell.Value = item.Key;
                    monthCell.Borders.LineStyle =
                        Excel.XlLineStyle.xlContinuous;

                    monthCell.HorizontalAlignment =
                        Excel.XlHAlign.xlHAlignCenter;

                    Excel.Range valueCell =
                        sheet.Cells[currentRow, 2];

                    valueCell.Value = item.Value;
                    valueCell.NumberFormat = "#,##0 ₽";

                    valueCell.Borders.LineStyle =
                        Excel.XlLineStyle.xlContinuous;

                    valueCell.HorizontalAlignment =
                        Excel.XlHAlign.xlHAlignCenter;

                    // Красивое чередование цветов
                    Excel.Range rowRange =
                        sheet.Range[sheet.Cells[currentRow, 1],
                        sheet.Cells[currentRow, 2]];

                    if ((currentRow % 2) == 0)
                        rowRange.Interior.Color =
                            Color.FromArgb(242, 242, 242);
                    else
                        rowRange.Interior.Color =
                            Color.FromArgb(255, 255, 255);

                    currentRow++;
                }

                // Итог таблицы
                Excel.Range totalMonthLabel =
                    sheet.Cells[currentRow, 1];

                totalMonthLabel.Value = "ИТОГО";
                totalMonthLabel.Font.Bold = true;

                totalMonthLabel.Interior.Color =
                    Color.FromArgb(198, 224, 180);

                totalMonthLabel.Borders.LineStyle =
                    Excel.XlLineStyle.xlContinuous;

                totalMonthLabel.HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;

                Excel.Range totalMonthValue =
                    sheet.Cells[currentRow, 2];

                totalMonthValue.Value = totalRevenue;
                totalMonthValue.Font.Bold = true;
                totalMonthValue.NumberFormat = "#,##0 ₽";

                totalMonthValue.Interior.Color =
                    Color.FromArgb(198, 224, 180);

                totalMonthValue.Borders.LineStyle =
                    Excel.XlLineStyle.xlContinuous;

                totalMonthValue.HorizontalAlignment =
                    Excel.XlHAlign.xlHAlignCenter;

                // ===== КРУГОВАЯ ДИАГРАММА =====
                Excel.ChartObjects charts =
                    (Excel.ChartObjects)sheet.ChartObjects();

                Excel.ChartObject chartObject =
                    charts.Add(380, 120, 500, 320);

                Excel.Chart chart = chartObject.Chart;

                Excel.Range chartRange =
                    sheet.Range[
                        sheet.Cells[chartStartRow, 1],
                        sheet.Cells[currentRow - 1, 2]
                    ];

                chart.SetSourceData(chartRange);

                chart.ChartType = Excel.XlChartType.xlPie;

                // Заголовок диаграммы
                chart.HasTitle = true;

                chart.ChartTitle.Text =
                    "Процентное соотношение прибыли по месяцам";

                // Легенда
                chart.HasLegend = true;

                chart.Legend.Position =
                    Excel.XlLegendPosition.xlLegendPositionRight;

                // Подписи процентов
                Excel.Series series =
                    (Excel.Series)chart.SeriesCollection(1);

                series.HasDataLabels = true;

                series.DataLabels().ShowPercentage = true;
                series.DataLabels().ShowCategoryName = true;

                // ===== ШИРИНА СТОЛБЦОВ =====
                sheet.Columns[1].ColumnWidth = 22;
                sheet.Columns[2].ColumnWidth = 24;
                sheet.Columns[3].ColumnWidth = 24;

                // ===== ВИДИМОСТЬ EXCEL =====
                excelApp.Visible = true;
            }
            finally
            {
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);
            }
        }


        string GetSafe(DataRow r, string col)
        {
            return r[col] == DBNull.Value ? "" : r[col].ToString();
        }

        private void ShowAllInfo_CheckedChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!ShowAllInfo.Checked &&
        dataGridView1.Columns[e.ColumnIndex].HeaderText == "Номер телефона" &&
        e.Value != null)
            {
                string phone = e.Value.ToString();

                if (!string.IsNullOrEmpty(phone))
                {
                    int hide = phone.Length / 2;
                    e.Value = phone.Substring(0, phone.Length - hide) + new string('*', hide);
                    e.FormattingApplied = true;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Дата выполнения")
            {
                if (e.Value != null && DateTime.TryParse(e.Value.ToString(), out DateTime completeDate))
                {
                    DateTime today = DateTime.Today;
                    TimeSpan diff = completeDate.Date - today;

                    // Дата уже прошла — мягко красный
                    if (completeDate.Date < today)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor =
                            Color.FromArgb(255, 220, 220);
                    }
                    // Меньше 7 дней — мягко жёлтый
                    else if (diff.TotalDays <= 7)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor =
                            Color.FromArgb(255, 245, 200);
                    }
                }
            }            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string compound = dataGridView1.Rows[e.RowIndex].Cells["orderSetUp"].Value.ToString();
            var od = new OrderDetail(compound);
            od.ShowDialog();
        }
    }
}
