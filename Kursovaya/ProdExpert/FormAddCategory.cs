using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.ProdExpert
{
    public partial class FormAddCategory : Form
    {
        private string connStr = ConnectionString.GetConnectionString();
        public FormAddCategory()
        {
            InitializeComponent();
            EnsureColumnsForTableDesigner();
        }

        private void EnsureColumnsForTableDesigner()
        {
            if (dgvColumns.Columns.Count > 0)
                return;

            dgvColumns.AutoGenerateColumns = false;
            dgvColumns.AllowUserToAddRows = true;
            dgvColumns.BackgroundColor = Color.FromArgb(97, 91, 104);
            dgvColumns.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dgvColumns.DefaultCellStyle.ForeColor = Color.White;
            dgvColumns.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dgvColumns.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvColumns.EnableHeadersVisualStyles = false;
            dgvColumns.RowHeadersVisible = false;
            dgvColumns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColumns.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);

            // Имя столбца
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "ColumnName",
                HeaderText = "Имя поля",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            var colNameRu = new DataGridViewTextBoxColumn
            {
                Name = "ColumnNameRu",
                HeaderText = "Имя поля кириллицей",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            // Тип данных
            var colType = new DataGridViewComboBoxColumn
            {
                Name = "ColumnType",
                HeaderText = "Тип данных",
                DataSource = new[] { "INT", "VARCHAR" },
                Width = 120
            };

            // Длина (только для VARCHAR)
            var colLength = new DataGridViewTextBoxColumn
            {
                Name = "ColumnLength",
                HeaderText = "Длина",
                Width = 80
            };

            dgvColumns.Columns.AddRange(colNameRu, colName, colType, colLength);
        }


        // ================= ВАЛИДАЦИЯ ИМЁН =================
        private bool IsValidName(string name)
        {
            return name.Length >= 5 && Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$");
        }

        // ================= КНОПКА: ДОБАВИТЬ СТОЛБЕЦ =================
        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            dgvColumns.Rows.Add();
        }

        // ================= КНОПКА: УДАЛИТЬ СТОЛБЕЦ =================
        private void btnRemoveColumn_Click(object sender, EventArgs e)
        {
            if (dgvColumns.SelectedRows.Count == 0)
                return;

            var row = dgvColumns.SelectedRows[0];

            if (row.IsNewRow)
            {
                MessageBox.Show("Нельзя удалить строку для ввода новых данных.");
                return;
            }

            if (dgvColumns.Rows.Count > 1)
            {
                dgvColumns.Rows.RemoveAt(row.Index);
            }
            else
            {
                MessageBox.Show("Нельзя создать таблицу без столбцов!");
            }
        }

        // ================= БЛОКИРОВКА ДЛИНЫ VARCHAR =================
        private void dgvColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvColumns.Columns[e.ColumnIndex].Name == "ColumnType")
            {
                var row = dgvColumns.Rows[e.RowIndex];
                string type = row.Cells["ColumnType"].Value?.ToString();

                row.Cells["ColumnLength"].ReadOnly = type != "VARCHAR";
                if (type != "VARCHAR")
                    row.Cells["ColumnLength"].Value = null;
            }
        }

        // ================= СОЗДАНИЕ ТАБЛИЦЫ =================
        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvColumns.Rows)
            {
                if(row.Cells["ColumnName"].Value?.ToString() == "id" || row.Cells["ColumnName"].Value?.ToString() == "model" || row.Cells["ColumnName"].Value?.ToString() == "produser" || row.Cells["ColumnName"].Value?.ToString() == "cost" || row.Cells["ColumnName"].Value?.ToString() == "inStock" || row.Cells["ColumnName"].Value?.ToString() == "image")
                {
                    MessageBox.Show($"Столбец {row.Cells["ColumnName"].Value?.ToString()} является стандарным и создаётся автоматически, удалите его для создания категории!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (!IsValidNameRu(txtTableNameRu.Text))
            {
                return;
            }
            string tableName = txtTableName.Text.Trim();

            if (!IsValidName(tableName))
            {
                MessageBox.Show("Некорректное имя таблицы");
                return;
            }

            List<string> columnsSql = new List<string>();

            foreach (DataGridViewRow row in dgvColumns.Rows)
            {
                if (row.IsNewRow) continue;

                string colName = row.Cells["ColumnName"].Value?.ToString();
                string colType = row.Cells["ColumnType"].Value?.ToString();
                string colLength = row.Cells["ColumnLength"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(colName) || !IsValidName(colName))
                {
                    MessageBox.Show("Некорректное имя поля");
                    return;
                }

                if (colType == "INT")
                {
                    columnsSql.Add($"{colName} INT");
                }
                else if (colType == "VARCHAR")
                {
                    if (!int.TryParse(colLength, out int len) || len <= 0)
                    {
                        MessageBox.Show($"Неверная длина VARCHAR у поля {colName}");
                        return;
                    }

                    columnsSql.Add($"{colName} VARCHAR({len})");
                }
                else
                {
                    MessageBox.Show($"Не выбран тип данных для поля {colName}");
                    return;
                }
            }

            if (columnsSql.Count == 0)
            {
                MessageBox.Show("Добавьте хотя бы один столбец");
                return;
            }

            string sql = $@"
            CREATE TABLE `{tableName}` (
             id INT PRIMARY KEY AUTO_INCREMENT,
             model varchar(255) NOT NULL,
             produser varchar(255) NOT NULL,
                 {string.Join(",\n    ", columnsSql)},
               inStock int NOT NULL DEFAULT 0,
                image varchar(255) NULL,
              cost int NOT NULL
        
);";
            SaveToJSON();
            ExecuteSql(sql);
        }

        // ================= ВЫПОЛНЕНИЕ SQL =================
        private void ExecuteSql(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Таблица успешно создана");
        }

        

        private void txtTableName_TextChanged_1(object sender, EventArgs e)
        {
            string input = txtTableName.Text;

            if (IsValidName(input))
            {
                txtTableName.BackColor = Color.FromArgb(77, 150, 125); // допустимое имя
                txtTableName.ForeColor = Color.White;
            }
            else
            {
                txtTableName.BackColor = Color.Red; // недопустимое имя
                txtTableName.ForeColor = Color.White;
            }
        }

        private void txtTableName_Leave(object sender, EventArgs e)
        {
            string input = txtTableName.Text;

            if (!IsValidName(input))
            {
                MessageBox.Show("Неверное имя! Оно должно начинаться с буквы или '_' и содержать только буквы, цифры и '_'.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTableName.Focus(); // возвращаем фокус в textbox
            }
        }

        private void dgvColumns_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvColumns.Columns[e.ColumnIndex].Name == "ColumnType")
            {
                var row = dgvColumns.Rows[e.RowIndex];
                var type = row.Cells["ColumnType"].Value?.ToString();

                row.Cells["ColumnLength"].ReadOnly = type != "VARCHAR";
                if (type != "VARCHAR")
                    row.Cells["ColumnLength"].Value = null;
            }
        }

        private void dgvColumns_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is System.Windows.Forms.TextBox tb)
            {
                // Сначала снимаем все обработчики, чтобы не дублировать
                tb.KeyPress -= ColumnLength_KeyPress;
                tb.KeyPress -= ColumnName_KeyPress;
                tb.KeyPress -= ColumnNameRu_KeyPress;

                string columnName = dgvColumns.CurrentCell.OwningColumn.Name;

                if (columnName == "ColumnLength")
                {
                    tb.MaxLength = 3;
                    tb.KeyPress += ColumnLength_KeyPress;
                }
                else if (columnName == "ColumnName")
                {
                    tb.MaxLength = 50;
                    tb.KeyPress += ColumnName_KeyPress;
                }
                else if (columnName == "ColumnNameRu")
                {
                    tb.MaxLength = 50;
                    tb.KeyPress += ColumnNameRu_KeyPress;
                }
            }
        }
        private void ColumnLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            // разрешаем цифры и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void ColumnNameRu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Разрешаем пробел
            if (e.KeyChar == ' ')
                return;

            // Проверяем, что символ — русская буква (А–Я, а–я, Ё, ё)
            if (!((e.KeyChar >= 'А' && e.KeyChar <= 'Я') ||
                  (e.KeyChar >= 'а' && e.KeyChar <= 'я') ||
                  e.KeyChar == 'Ё' || e.KeyChar == 'ё'))
            {
                e.Handled = true; // запрещаем ввод
            }
        }
        private void ColumnName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // разрешаем Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // A–Z, a–z, _
            if (!(char.IsLetter(e.KeyChar) && e.KeyChar <= 127) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void SaveToJSON()
        {
            JObject table = new JObject
            {
                ["systemName"] = txtTableName.Text,
                ["displayName"] = txtTableNameRu.Text,
                ["columns"] = new JArray(
        dgvColumns.Rows
            .Cast<DataGridViewRow>()
            .Where(r => !r.IsNewRow)
            .Select(r => new JObject
            {
                ["systemName"] = r.Cells["ColumnName"].Value?.ToString(),
                ["displayName"] = r.Cells["ColumnNameRu"].Value?.ToString()
            })
    )
            };

            JObject root = new JObject
            {
                ["tables"] = new JArray(table)
            };
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json");
            File.WriteAllText(path, root.ToString());
        }

        private void txtTableNameRu_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            // Проверяем: русские буквы или пробел
            if (!char.IsControl(c) && !((c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё' || c == ' '))
            {
                e.Handled = true; // блокируем ввод
            }
        }

        private void txtTableNameRu_TextChanged(object sender, EventArgs e)
        {
            string input = txtTableNameRu.Text;

            if (IsValidNameRu(input))
            {
                txtTableNameRu.BackColor = Color.FromArgb(77, 150, 125); // допустимое имя
                txtTableNameRu.ForeColor = Color.White;
            }
            else
            {
                txtTableNameRu.BackColor = Color.Red; // недопустимое имя
                txtTableNameRu.ForeColor = Color.White;
            }
        }
        private bool IsValidNameRu(string name)
        {
            // Проверяем длину
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5)
                return false;

            // Разрешаем только русские буквы и пробелы, без пробела в начале
            return Regex.IsMatch(name, @"^[А-Яа-яЁё]+(?: [А-Яа-яЁё]+)*$");
        }
    }
}
