using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ФОРМА отображения подробных характеристик товара

namespace Kursovaya.User
{
    public partial class UserProductCharacteristic : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public UserProductCharacteristic(string theme, int idProduct)
        {
            InitializeComponent();
            showProductCharacteristic(theme, idProduct); // функция отображения характеристик
            setProductPicture(theme, idProduct); // функция отображения изображения товара
            setProductName(theme, idProduct); // функция установки названия товара
            CopyDefaultImagesToAppData(); // копируем имеющиеся изображения в AppData

            // настройки дизайна
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
        }
        // функция отображения характеристик
        public void showProductCharacteristic(string theme, int idProduct)
        {
            try
            {
                dataGridView1.Columns.Add("characteristicName", "Тип характеристики");
                dataGridView1.Columns.Add("characteristic", "Характеристики");
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = theme == "case"
                        ? $"SELECT * FROM cases WHERE id = {idProduct};"
                        : $"SELECT * FROM {theme} WHERE id = {idProduct};";

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            
                            

                            if (columnName == "iduser" || columnName == "id" || columnName == "image")
                                continue;

                            if (reader.IsDBNull(i))
                                continue;

                            string value = reader.GetValue(i).ToString();


                            if (columnName == "model") { columnName = "Модель"; }
                            else if (columnName == "produser") { columnName = "Производитель"; }
                            else if (columnName == "socket") { columnName = "Сокет"; }
                            else if (columnName == "frequency") { columnName = "Частота"; }
                            else if (columnName == "architecture") { columnName = "Архитектура"; }
                            else if (columnName == "core_int") { columnName = "Количетсво ядер"; }
                            else if (columnName == "L3_caсhe") { columnName = "L3 кэш"; value += " МБ"; }
                            else if (columnName == "thermal_power") { columnName = "Тепловыделение"; value += "  Вт"; }
                            else if (columnName == "cost") { columnName = "Стоимость"; value += " ₽"; }


                            else if (columnName == "form_factor") { columnName = "Форм фактор"; }
                            else if (columnName == "cpu_socket") { columnName = "Сокет"; }
                            else if (columnName == "ram_slots") { columnName = "Количетсво слотов опер. памяти"; }
                            else if (columnName == "ram_support_type") { columnName = "Поддерживаемый тип опер. памяти"; }
                            else if (columnName == "ram_max_capacity") { columnName = "Максимальный объём опер. памяти"; }
                            else if (columnName == "chipset") { columnName = "Чипсет"; }
                            else if (columnName == "expansion_slots") { columnName = "Количество слотов расширения"; }
                            else if (columnName == "expansion_type") { columnName = "Тип слотов расширения"; }
                            else if (columnName == "m2_ssd_slots") { columnName = "Количестов слотов для M.2 SSD"; }

                            else if (columnName == "type_of_device") { columnName = "Тип устройства"; }
                            else if (columnName == "capacity_gb") { columnName = "Объём"; value += " ГБ"; }
                            else if (columnName == "write_speed") { columnName = "Скорость записи"; value += " MБ/c"; }
                            else if (columnName == "read_speed") { columnName = "Скорость чтения"; value += " MБ/c"; }
                            else if (columnName == "interface") { columnName = "Разъём подключения"; }

                            else if (columnName == "color") { columnName = "Цвет"; }
                            else if (columnName == "max_lenght_videocard") { columnName = "Максимальная длина видеокарты"; value += " мм"; }
                            else if (columnName == "max_height_cpu_cooler") { columnName = "Максимальная высота процессорного кулера"; value += " мм"; }
                            else if (columnName == "storage_slots") { columnName = "Количетво отсеков накопителей";  }

                            else if (columnName == "light") { columnName = "Подсветка"; }
                            else if (columnName == "scale") { columnName = "Размер вентилятора"; value += " мм"; }

                            else if (columnName == "memory") { columnName = "Объём видеопамяти"; value += " ГБ"; }
                            else if (columnName == "bus_width") { columnName = "Разрядность шины памяти"; value += " бит"; }
                            else if (columnName == "memory_type") { columnName = "Тип видеопамяти";  }
                            else if (columnName == "power_consumption") { columnName = "Потребляемая мощность"; value += " Вт"; }
                            else if (columnName == "vender") { columnName = "Производитель версии видеокарты"; }
                            else if (columnName == "gpu_lenght") { columnName = "Длина видеокарты"; value += " мм"; }

                            else if (columnName == "speed_mhz") { columnName = "Частота"; value += " МГц"; }
                            else if (columnName == "ram_type") { columnName = "Тип памяти";  }

                            else if (columnName == "power") { columnName = "Мощность"; value += " Вт"; }
                            else if (columnName == "certificate") { columnName = "Сертификат"; }

                            else if (columnName == "max_heat_sink") { columnName = "Рассеиваемая мощность"; value += " Вт"; }
                            else if (columnName == "cooler_height") { columnName = "Высота кулера"; value += " мм"; }
                            else if (columnName == "light_type") { columnName = "Подсветка"; }

                            else if (columnName == "thermal_conductivity") { columnName = "Теплопроводность"; value += " Вт/мК"; }
                            else if (columnName == "packege_volume") { columnName = "Вес"; value += " г"; }
                            else if (columnName == "shel_life") { columnName = "Срок годности"; value += " Г"; }
                            else if (columnName == "composition") { columnName = "Состав";}


                            // ОДНА строка — ДВЕ колонки
                            dataGridView1.Rows.Add(columnName, value);
                        }

                        dataGridView1.RowHeadersVisible = false;

                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }            
        }

        // копируем имеющиеся изображения в AppData
        void CopyDefaultImagesToAppData()
        {
            try
            {
                string exeImgFolder = Path.Combine(Application.StartupPath, "img");

                string appDataImgFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "pepeShop",
                    "img"
                );

                Directory.CreateDirectory(appDataImgFolder);

                string[] filesToCopy = { "no-image.png", "gigabyte3060.png" };

                foreach (string fileName in filesToCopy)
                {
                    string sourcePath = Path.Combine(exeImgFolder, fileName);
                    string destPath = Path.Combine(appDataImgFolder, fileName);

                    if (File.Exists(sourcePath) && !File.Exists(destPath))
                    {
                        File.Copy(sourcePath, destPath);
                    }
                }
            }
            catch(Exception e) {  MessageBox.Show(e.Message); }
        }
        // функция отображения изображения товара
        public void setProductPicture(string theme, int idProduct)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string query = theme == "case"
                        ? $"SELECT image FROM cases WHERE id = {idProduct};"
                        : $"SELECT image FROM {theme} WHERE id = {idProduct};";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (cmd.ExecuteScalar().ToString() == "")
                    {
                        string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pepeShop");

                        string imagePath = Path.Combine(imgFolder, "no-image.png");

                        productPictureBox.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        string path = cmd.ExecuteScalar().ToString();
                        string imgFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "pepeShop");

                        string imagePath = Path.Combine(imgFolder, path);

                        productPictureBox.Image = Image.FromFile(imagePath);
                                        
                    }
                }
            }
            catch (Exception ex) {string err = ex.Message; productPictureBox.Image = Image.FromFile("img/no-image.png"); }
        }
        // функция установки названия товара
        public void setProductName(string theme, int idProduct)
        {
            try
            {
                string query = $@"SELECT ";
                if (theme == "processors") { query += "concat(processors.produser, space(1), processors.model) as processor "; }
                else if (theme == "motherboards") { query += "concat(motherboards.produser, space(1), motherboards.model) as motherboard "; }
                else if (theme == "videocards") { query += "concat(videocards.produser, space(1), videocards.vender, space(1), videocards.model) as vidocard "; }
                else if (theme == "cpu_cooler") { query += "concat(cpu_cooler.produser, space(1), cpu_cooler.model) as cpu_cooler "; }
                else if (theme == "case") { query += "concat(cases.produser, space(1), cases.model) as cases "; }
                else if (theme == "case_coolers") { query += "concat(case_coolers.produser, space(1), case_coolers.model) as case_coolers "; }
                else if (theme == "power_supplier") { query += "concat(power_supplier.produser, space(1), power_supplier.model, space(1), power_supplier.power, space(1), 'ВАТТ') as power_supplier "; }
                else if (theme == "thermo_interface") { query += "concat(thermo_interface.produser, space(1), thermo_interface.model) as thermo_interface "; }
                else if (theme == "ram") { query += "concat(ram.produser, space(1), ram.model, space(1), ram.capacity_gb, space(1), 'ГБ') as ram "; }
                else if (theme == "storage") { query += "concat(storage.produser, space(1), storage.model, space(1), storage.capacity_gb, space(1), 'ГБ') as storage "; }
                if (theme == "case") { query += "FROM cases "; }
                else { query += $"FROM {theme} "; }
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
                    ProductNameLabel.Text = productName;                    
                }
            }catch (Exception ex) { MessageBox.Show(ex.Message); }   
            

        }
    }
}
