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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Kursovaya.ProdExpert
{
    public partial class FormEditingProd : Form
    {
        string globalTheme;
        int globalIdProduct;
        string connStr = ConnectionString.GetConnectionString();
        public FormEditingProd(string theme, int idProduct)
        {
            globalIdProduct = idProduct;
            if (theme == "Процессоры") { theme = "processors"; }
            else if (theme == "Материские платы") { theme = "motherboards"; }
            else if (theme == "Видеокарты") { theme = "videocards"; }
            else if (theme == "Кулеры") { theme = "cpu_cooler"; }
            else if (theme == "Корпусы") { theme = "cases"; }
            else if (theme == "Корпусные кулеры") { theme = "case_coolers"; }
            else if (theme == "Блоки питания") { theme = "power_supplier"; }
            else if (theme == "Термопаста") { theme = "thermo_interface"; }
            else if (theme == "Оперативная память") { theme = "ram"; }
            else if (theme == "Накопители") { theme = "storage"; }
            globalTheme = theme;
            InitializeComponent();
            FillDGV(theme, idProduct);
            setProductName(theme, idProduct);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
        }
        public void FillDGV(string theme, int idProduct)
        {
            
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {

                    conn.Open();
                    string query = theme == "case"
                        ? $"SELECT * FROM cases WHERE id = {idProduct};"
                        : $"SELECT * FROM {theme} WHERE id = {idProduct};";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        dataGridView1.Columns.Add("character", "Характеристика");
                        dataGridView1.Columns.Add("value", "Значение");
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);


                            string value = reader.GetValue(i).ToString();
                            if (columnName == "id")
                            {
                                idProduct = Convert.ToInt32(value);
                            }
                            if (columnName == "iduser" || columnName == "id" || columnName == "image")
                                continue;

                            if (reader.IsDBNull(i))
                                continue;

                            if (columnName == "model") { columnName = "Модель"; }
                            else if (columnName == "produser") { columnName = "Производитель"; }
                            else if (columnName == "socket") { columnName = "Сокет"; }
                            else if (columnName == "frequency") { columnName = "Частота"; }
                            else if (columnName == "architecture") { columnName = "Архитектура"; }
                            else if (columnName == "core_int") { columnName = "Количество ядер"; }
                            else if (columnName == "L3_caсhe") { columnName = "L3 кэш"; }
                            else if (columnName == "thermal_power") { columnName = "Тепловыделение"; }
                            else if (columnName == "cost") { columnName = "Стоимость"; }


                            else if (columnName == "form_factor") { columnName = "Форм фактор"; }
                            else if (columnName == "cpu_socket") { columnName = "Сокет процессора"; }
                            else if (columnName == "ram_slots") { columnName = "Количетсво слотов опер. памяти"; }
                            else if (columnName == "ram_support_type") { columnName = "Поддерживаемый тип опер. памяти"; }
                            else if (columnName == "ram_max_capacity") { columnName = "Максимальный объём опер. памяти"; }
                            else if (columnName == "chipset") { columnName = "Чипсет"; }
                            else if (columnName == "expansion_slots") { columnName = "Количество слотов расширения"; }
                            else if (columnName == "expansion_type") { columnName = "Тип слотов расширения"; }
                            else if (columnName == "m2_ssd_slots") { columnName = "Количестов слотов для M.2 SSD"; }

                            else if (columnName == "type_of_device") { columnName = "Тип устройства"; }
                            else if (columnName == "capacity_gb") { columnName = "Объём"; ; }
                            else if (columnName == "write_speed") { columnName = "Скорость записи"; }
                            else if (columnName == "read_speed") { columnName = "Скорость чтения";  }
                            else if (columnName == "interface") { columnName = "Разъём подключения"; }

                            else if (columnName == "color") { columnName = "Цвет"; }
                            else if (columnName == "max_lenght_videocard") { columnName = "Максимальная длина видеокарты";; }
                            else if (columnName == "max_height_cpu_cooler") { columnName = "Максимальная высота процессорного кулера";  }
                            else if (columnName == "storage_slots") { columnName = "Количетво отсеков накопителей"; }

                            else if (columnName == "light") { columnName = "Подсветка"; }
                            else if (columnName == "scale") { columnName = "Размер вентилятора"; }

                            else if (columnName == "memory") { columnName = "Объём видеопамяти";  }
                            else if (columnName == "bus_width") { columnName = "Разрядность шины памяти";  }
                            else if (columnName == "memory_type") { columnName = "Тип видеопамяти"; }
                            else if (columnName == "power_consumption") { columnName = "Потребляемая мощность"; }
                            else if (columnName == "vender") { columnName = "Производитель версии видеокарты"; }
                            else if (columnName == "gpu_lenght") { columnName = "Длина видеокарты"; }

                            else if (columnName == "speed_mhz") { columnName = "Частота памяти"; }
                            else if (columnName == "ram_type") { columnName = "Тип памяти"; }

                            else if (columnName == "power") { columnName = "Мощность"; }
                            else if (columnName == "certificate") { columnName = "Сертификат"; }

                            else if (columnName == "max_heat_sink") { columnName = "Рассеиваемая мощность"; }
                            else if (columnName == "cooler_height") { columnName = "Высота кулера"; }
                            else if (columnName == "light_type") { columnName = "Тип подсветки"; }

                            else if (columnName == "thermal_conductivity") { columnName = "Теплопроводность"; }
                            else if (columnName == "packege_volume") { columnName = "Вес"; }
                            else if (columnName == "shel_life") { columnName = "Срок годности"; }
                            else if (columnName == "composition") { columnName = "Состав"; }
                            dataGridView1.Rows.Add(columnName, value);
                        }
                        dataGridView1.RowHeadersVisible = false;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        // Запрет добавления и удаления строк
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.AllowUserToDeleteRows = false;

                        // Разрешаем редактирование
                        dataGridView1.ReadOnly = false;

                        // Первый столбец (название характеристики) — ТОЛЬКО ЧТЕНИЕ
                        dataGridView1.Columns[0].ReadOnly = false; ////////////////////////////////////////////////////////////////

                        // Второй столбец (значение) — МОЖНО РЕДАКТИРОВАТЬ
                        dataGridView1.Columns[1].ReadOnly = false;

                        // Вход в режим редактирования сразу при клике
                        dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void setProductName(string theme, int idProduct)
        {
            try
            {
                string query = $@"SELECT ";
                if (theme == "processors") { query += "concat(processors.produser, space(1), processors.model) as processor "; }
                else if (theme == "motherboards") { query += "concat(motherboards.produser, space(1), motherboards.model) as motherboard "; }
                else if (theme == "videocards") { query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as vidocard "; }
                else if (theme == "cpu_cooler") { query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as cpu_cooler "; }
                else if (theme == "cases") { query += "concat(cases.produser, space(1), cases.model) as cases "; }
                else if (theme == "case_coolers") { query += "concat(case_coolers.produser, space(1), case_coolers.model) as case_coolers "; }
                else if (theme == "power_supplier") { query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as power_supplier "; }
                else if (theme == "thermo_interface") { query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as thermo_interface "; }
                else if (theme == "ram") { query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as ram "; }
                else if (theme == "storage") { query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as storage "; }
                
                query += $"FROM {theme} "; 
                query += $"WHERE id = {idProduct}";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string productName = "";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmd.ExecuteScalar().ToString() == "")
                    {
                        productName = "Название не найдено!";
                    }
                    else
                    {
                        productName = cmd.ExecuteScalar().ToString();
                        this.Text = $"Характеристики - {productName}";
                    }
                    ItemName.Text = productName;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= OnlyDigits_KeyPress;
                tb.KeyPress -= NameWithoutSpecial_KeyPress;

                string propertyName = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                if (IsOnlyDigits(propertyName)) // только цифры
                {
                    tb.KeyPress += OnlyDigits_KeyPress;
                    tb.MaxLength = 10;
                }
                else if (IsTextField(propertyName)) // без спецсимволов без цифр но с пробелом
                {
                    tb.KeyPress += NameWithoutSpecial_KeyPress;
                    tb.MaxLength = 100;
                }
                
            }
        }
        
        private bool IsTextField(string field) // без спецсимволов но с цифрами, пробелом и запятой
        {
            return field == "Модель"
                || field == "Производитель"
                || field == "Сокет"
                || field == "Частота"
                || field == "Архитектура"

                || field == "Тип видеопамяти"
                || field == "Разъём подключения"
                || field == "Производитель версии видеокарты"

                || field == "Форм фактор"
                || field == "Поддерживаемый тип опер. памяти"
                || field == "Максимальный объём опер. памяти"
                || field == "Чипсет"
                || field == "Тип слотов расширения"

                || field == "Тип памяти"
                || field == "Подсветка"

                || field == "Цвет"

                || field == "Сертификат"

                || field == "Тип устройства"
                || field == "Теплопроводность"
                || field == "Вес"
                || field == "Состав";
        }
        

        private bool IsOnlyDigits(string field) // только цифры
        {
            return field == "Стоимость" || field == "L3 кэш" || field == "Тепловыделение"  || field == "Количество ядер"  || field == "Объём видеопамяти" || field == "Разрядность шины памяти"
                || field == "Потребляемая мощность" || field == "Длина видеокарты" || field == "Количетсво слотов опер. памяти" || field == "Количестов слотов для M.2 SSD"
                || field == "Количество слотов расширения" || field == "Объём" || field == "Частота" || field == "Рассеиваемая мощность" || field == "Высота кулера" || field == "Максимальная длина видеокарты"
                || field == "Максимальная высота процессорного кулера" || field == "Количетво отсеков накопителей" || field == "Мощность"  || field == "Размер вентилятора"
                || field == "Скорость записи" || field == "Скорость чтения" || field == "Срок годности";
        }
        

        private void OnlyDigits_KeyPress(object sender, KeyPressEventArgs e) ///
        {
            char ch = e.KeyChar;

            if (!char.IsControl(ch) && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }
        
        private void NameWithoutSpecial_KeyPress(object sender, KeyPressEventArgs e) ///
        {
            char ch = e.KeyChar;

            if (char.IsControl(ch))
                return;

            // Запрет кириллицы
            if ((ch >= 'А' && ch <= 'я') || ch == 'ё' || ch == 'Ё')
            {
                e.Handled = true;
                return;
            }

            // Разрешаем латиницу, цифры и пробел
            if (!char.IsLetterOrDigit(ch) && ch != ' ' && ch != ',' && ch != '!')
            {
                e.Handled = true;
            }
        }
        public void SaveChanges(string theme, int idProduct)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                    return;

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Словарь для сопоставления отображаемых названий столбцов в dgv с реальными именами в БД
                    Dictionary<string, string> columnMapping = new Dictionary<string, string>()
            {
                {"Модель", "model"},
                {"Производитель", "produser"},
                {"Сокет", "socket"},
                {"Частота", "frequency"},
                {"Архитектура", "architecture"},
                {"Количество ядер", "core_int"},
                {"L3 кэш", "L3_caсhe"},
                {"Тепловыделение", "thermal_power"},
                {"Стоимость", "cost"},
                {"Форм фактор", "form_factor"},
                {"Поддерживаемый тип опер. памяти", "ram_support_type"},
                {"Максимальный объём опер. памяти", "ram_max_capacity"},
                {"Чипсет", "chipset"},
                {"Количество слотов расширения", "expansion_slots"},
                {"Тип слотов расширения", "expansion_type"},
                {"Количестов слотов для M.2 SSD", "m2_ssd_slots"},
                {"Тип устройства", "type_of_device"},
                {"Объём", "capacity_gb"},
                {"Скорость записи", "write_speed"},
                {"Скорость чтения", "read_speed"},
                {"Разъём подключения", "interface"},
                {"Цвет", "color"},
                {"Максимальная длина видеокарты", "max_lenght_videocard"},
                {"Максимальная высота процессорного кулера", "max_height_cpu_cooler"},
                {"Количетво отсеков накопителей", "storage_slots"},
                {"Подсветка", "light"},
                {"Размер вентилятора", "scale"},
                {"Сокет процессора", "cpu_socket"},
                {"Объём видеопамяти", "memory"},
                {"Разрядность шины памяти", "bus_width"},
                {"Тип видеопамяти", "memory_type"},
                {"Потребляемая мощность", "power_consumption"},
                {"Производитель версии видеокарты", "vender"},
                {"Длина видеокарты", "gpu_lenght"},
                {"Тип памяти", "ram_type"},
                {"Тип подсветки", "light_type"},
                {"Мощность", "power"},
                {"Частота памяти", "speed_mhz"},
                {"Сертификат", "certificate"},
                {"Рассеиваемая мощность", "max_heat_sink"},
                {"Высота кулера", "cooler_height"},
                {"Теплопроводность", "thermal_conductivity"},
                {"Вес", "packege_volume"},
                {"Срок годности", "shel_life"},
                {"Состав", "composition"}
            };

                    // Генерируем SET часть запроса
                    List<string> setParts = new List<string>();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string displayName = row.Cells[0].Value?.ToString();
                        string value = row.Cells[1].Value?.ToString() ?? "";

                        if (string.IsNullOrEmpty(displayName) || !columnMapping.ContainsKey(displayName))
                            continue;

                        string columnName = columnMapping[displayName];

                        // Экранируем строку для SQL
                        string escapedValue = MySqlHelper.EscapeString(value);

                        setParts.Add($"{columnName} = '{escapedValue}'");
                    }

                    if (setParts.Count == 0)
                        return;

                    string updateQuery = $"UPDATE {theme} SET {string.Join(", ", setParts)} WHERE id = {idProduct};";

                    MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    MessageBox.Show($"Новые данные сохранены!", $"Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult da = MessageBox.Show($"Вы действительно хотите сохранить данные?", $"Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(da == DialogResult.Yes)
            {
                SaveChanges(globalTheme, globalIdProduct);
            }
        }
    }
}
