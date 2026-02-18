using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Kursovaya.ProdExpert
{
    public partial class FormProdSupply : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public FormProdSupply()
        {

            InitializeComponent();
            fillDgv();
            LoadAmountsFromJson();
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
            LoadSuppliers();
        }
        public void LoadSuppliers()
        {
            try
            {
                string query = "SELECT * FROM suppliers";
                using(MySqlConnection conn  = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            supplierComboBox.Items.Add(reader.GetString(1));                            
                        }
                    }
                    supplierComboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public class ProductAmount
        {
            public string model { get; set; }
            public int Amount { get; set; }
        }
        public void fillDgv()
        {
            string query = $@"SELECT * FROM (SELECT id, concat(produser, space(1), model) as model, inStock, 'processors'   AS SourceTable FROM processors
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'videocards'       FROM videocards
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'thermo_interface' FROM thermo_interface
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'ram'              FROM ram
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'power_supplier'   FROM power_supplier
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'motherboards'     FROM motherboards
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'cpu_cooler'        FROM cpu_cooler
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'cases'             FROM cases
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'case_coolers'       FROM case_coolers
UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, 'storage'            FROM storage ";

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json");
            if (File.Exists(path))
            {

                string json = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(json))
                {

                }
                else
                {
                    JObject root = JObject.Parse(json);

                    JArray tables = (JArray)root["tables"];
                    foreach (JObject table in tables)
                    {
                        string SystemName = table["systemName"].ToString();
                        string DisplayName = table["displayName"].ToString();
                        query += $"UNION ALL SELECT id, concat(produser, space(1), model) as model, inStock, '{DisplayName}' FROM {SystemName} ";
                    }
                }

            }
            query += ") as products ";
            if (SearchTextBox.Text != "")
            {
                query += $"Where model like '%{SearchTextBox.Text.Trim()}%'";
            }
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
            }

            dataGridView1.Columns["model"].HeaderText = "Наименование";
            dataGridView1.Columns["inStock"].Visible = true;
            dataGridView1.Columns["inStock"].HeaderText = "Количество на складе";
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["SourceTable"].Visible = false;
            if (!dataGridView1.Columns.Contains("AmountDec"))
            {
                DataGridViewButtonColumn AmountDec = new DataGridViewButtonColumn();
                AmountDec.Name = "AmountDec";
                AmountDec.HeaderText = "Убавить";
                AmountDec.Text = "-";
                AmountDec.UseColumnTextForButtonValue = true;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Add(AmountDec);
                dataGridView1.Columns["AmountDec"].Width = 150;
            }            
            if (!dataGridView1.Columns.Contains("Amount"))
            {
                DataGridViewTextBoxColumn Amount = new DataGridViewTextBoxColumn();
                Amount.Name = "Amount";
                Amount.HeaderText = "Количество для поставки";
                dataGridView1.Columns.Add(Amount);
                dataGridView1.Columns["Amount"].Width = 150;
                dataGridView1.Columns["Amount"].ReadOnly = false;
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
                dataGridView1.Columns["AmountInc"].Width = 100;
            }
            dataGridView1.ReadOnly = false;
            
            dataGridView1.Columns["model"].ReadOnly = true;
            dataGridView1.Columns["inStock"].ReadOnly = true;
            dataGridView1.Columns["AmountDec"].ReadOnly = true;
            dataGridView1.Columns["AmountInc"].ReadOnly = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Amount"].Value == null)
                    row.Cells["Amount"].Value = "0";
            }            
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Сохраняем текущие значения Amount
            var currentAmounts = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string model = row.Cells["model"].Value?.ToString() ?? "";
                if (int.TryParse(row.Cells["Amount"].Value?.ToString(), out int amount))
                    currentAmounts[model] = amount;
            }

            // Перезагружаем таблицу
            fillDgv();

            // Восстанавливаем сохранённые значения Amount
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                string model = row.Cells["model"].Value?.ToString() ?? "";
                if (currentAmounts.ContainsKey(model))
                {
                    row.Cells["Amount"].Value = currentAmounts[model];
                }
                else
                {
                    row.Cells["Amount"].Value = 0;
                }
            }

            // Подгружаем значения из JSON только для моделей, которые уже есть в JSON
            LoadAmountsFromJson();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // защита от клика по заголовку
            if (dataGridView1.Columns[e.ColumnIndex].Name == "AmountDec" && dataGridView1.Rows[e.ColumnIndex].Cells["Amount"].Value == null)
            {
                dataGridView1.Rows[e.ColumnIndex].Cells["Amount"].Value = 0;
                return;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.Name == "Amount")
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.MaxLength = 3;
                    tb.KeyPress -= Amount_KeyPress;
                    tb.KeyPress += Amount_KeyPress;
                }                
            }
        }
        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Amount")
            {
                string value = e.FormattedValue.ToString();

                if (value.Length > 3)
                {
                    MessageBox.Show("Можно вводить максимум 3 цифры");
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["AmountDec"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Цвет кнопки
                using (SolidBrush buttonColor = new SolidBrush(Color.FromArgb(77, 150, 125)))
                {
                    e.Graphics.FillRectangle(buttonColor, e.CellBounds);
                }

                // Текст кнопки
                TextRenderer.DrawText(e.Graphics,
                                      (e.FormattedValue ?? "").ToString(),
                                      e.CellStyle.Font,
                                      e.CellBounds,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; // Система больше не рисует кнопку
            }
            if (e.ColumnIndex == dataGridView1.Columns["AmountInc"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Цвет кнопки
                using (SolidBrush buttonColor = new SolidBrush(Color.FromArgb(77, 150, 125)))
                {
                    e.Graphics.FillRectangle(buttonColor, e.CellBounds);
                }

                // Текст кнопки
                TextRenderer.DrawText(e.Graphics,
                                      (e.FormattedValue ?? "").ToString(),
                                      e.CellStyle.Font,
                                      e.CellBounds,
                                      Color.White,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true; // Система больше не рисует кнопку
            }
        }


        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Amount"].Value = "0";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Уменьшение
            if (dataGridView1.Columns[e.ColumnIndex].Name == "AmountDec")
            {
                ChangeAmount(e.RowIndex, -1);
            }

            // Увеличение
            if (dataGridView1.Columns[e.ColumnIndex].Name == "AmountInc")
            {
                ChangeAmount(e.RowIndex, 1);
            }
        }
        private void ChangeAmount(int rowIndex, int delta)
        {
            var cell = dataGridView1.Rows[rowIndex].Cells["Amount"];

            int value = 0;

            if (cell.Value != null)
                int.TryParse(cell.Value.ToString(), out value);

            value += delta;

            if (value < 0) value = 0; // запрет минуса

            cell.Value = value;
        }
        private string GetJsonPath()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "pepeShop");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            return Path.Combine(folder, "products.json");
        }

        private void MakeDoc_Click(object sender, EventArgs e)
        {
            string path = GetJsonPath();

            if (!File.Exists(path))
            {
                MessageBox.Show("JSON файл с товарами не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Загружаем данные из JSON
            JArray jsonArray = JArray.Parse(File.ReadAllText(path));

            // Создаём список товаров для Word
            var itemsToOrder = new List<(string name, int amount)>();

            foreach (JObject obj in jsonArray)
            {
                var name = obj["model"]?.ToString() ?? "";
                if (!int.TryParse(obj["Amount"]?.ToString(), out int amount) || amount == 0)
                    continue; // пропускаем товары с нулевым количеством

                itemsToOrder.Add((name, amount));
            }

            if (itemsToOrder.Count == 0)
            {
                MessageBox.Show("Нет товаров для поставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Создаём Word
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;

            Word.Document doc = wordApp.Documents.Add();

            // Общие настройки шрифта и межстрочного интервала
            doc.Content.Font.Name = "Times New Roman";
            doc.Content.Font.Size = 12;
            doc.Content.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;

            // Заголовок
            Word.Paragraph title = doc.Paragraphs.Add();
            title.Range.Text = "Запрос на поставку";
            title.Range.Font.Size = 18;
            title.Range.Font.Bold = 1;
            title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();

            // Вступительный текст
            Word.Paragraph intro = doc.Paragraphs.Add();
            intro.Range.Text = $"Прошу поставщика \"{supplierComboBox.SelectedItem.ToString()}\" обеспечить поставку следующих комплектующих для магазина pepeShop. Ниже приведена таблица с наименованиями и необходимым количеством:";
            intro.Range.Font.Size = 12;
            intro.Range.Font.Bold = 0;
            intro.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            intro.Range.InsertParagraphAfter();

            // Таблица
            Word.Table table = doc.Tables.Add(doc.Paragraphs.Add().Range, itemsToOrder.Count + 1, 2);
            table.Borders.Enable = 1;

            // Шапка таблицы
            table.Cell(1, 1).Range.Text = "Наименование комплектующего";
            table.Cell(1, 2).Range.Text = "Количество для поставки";
            table.Rows[1].Range.Bold = 1;
            table.Rows[1].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;

            // Заполняем строки из JSON
            for (int i = 0; i < itemsToOrder.Count; i++)
            {
                table.Cell(i + 2, 1).Range.Text = itemsToOrder[i].name;
                table.Cell(i + 2, 2).Range.Text = itemsToOrder[i].amount.ToString();
            }

            // Форматирование таблицы
            table.Range.Font.Size = 12;
            table.Range.Font.Name = "Times New Roman";
            MessageBox.Show("Документ Word сформирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Проверяем, что редактируется столбец Amount
            if (dataGridView1.Columns[e.ColumnIndex].Name != "Amount") return;

            string model = dataGridView1.Rows[e.RowIndex].Cells["model"].Value?.ToString() ?? "";
            var val = dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value;

            if (val == null) return;

            if (!int.TryParse(val.ToString(), out int amount)) return;

            // Обновляем JSON только если:
            // 1) amount > 0
            // 2) или запись уже есть в JSON (то есть был выбран ранее)
            UpdateJsonConditional(model, amount);
        }
        private void UpdateJsonConditional(string model, int amount)
        {
            string path = GetJsonPath();

            JArray array;
            if (File.Exists(path))
                array = JArray.Parse(File.ReadAllText(path));
            else
                array = new JArray();

            bool needSave = false;

            // Ищем существующую запись
            JObject existing = array.FirstOrDefault(x => x["model"]?.ToString() == model) as JObject;

            if (existing != null)
            {
                existing["Amount"] = amount; // обновляем любое значение, включая 0
                needSave = true;
            }
            else if (amount > 0)
            {
                JObject obj = new JObject
                {
                    ["model"] = model,
                    ["Amount"] = amount
                };
                array.Add(obj);
                needSave = true;
            }

            if (needSave)
                File.WriteAllText(path, array.ToString(Formatting.Indented));
        }


        private void LoadAmountsFromJson()
        {
            string path = GetJsonPath();
            if (!File.Exists(path)) return;

            JArray array = JArray.Parse(File.ReadAllText(path));

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string model = row.Cells["model"].Value?.ToString() ?? "";
                JObject saved = array.FirstOrDefault(x => x["model"]?.ToString() == model) as JObject;

                if (saved != null)
                {
                    if (int.TryParse(saved["Amount"]?.ToString(), out int amount))
                        row.Cells["Amount"].Value = amount;
                }
            }
        }
        private void ClearJson()
        {
            string path = GetJsonPath();
            File.WriteAllText(path, "[]");
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ClearJson();
            fillDgv();
        }

        private void FormProdSupply_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearJson();
        }
    }
}
