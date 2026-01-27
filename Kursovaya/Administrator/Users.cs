using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Administrator
{
    public partial class Users : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        int idSelectedUser;
        public Users()
        {
            InitializeComponent();
            fillComboBox();
            filldgv();
            dataGridView1.BackgroundColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(97, 91, 104);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(77, 150, 125);
            dataGridView1.RowHeadersVisible = false;
        }

        public void fillComboBox()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT id, role_name FROM role";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    DataRow row = dt.NewRow();
                    row["id"] = 0;
                    row["role_name"] = "Не выбрано";
                    dt.Rows.InsertAt(row, 0); // вставляем первым
                    userRoleComboBox.DataSource = dt;
                    userRoleComboBox.DisplayMember = "role_name"; // что видно пользователю
                    userRoleComboBox.ValueMember = "id";          // что хранится
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }            
        }

        public void filldgv()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT staff.id, name, surname, patronymic, role_name, role, login, password FROM staff JOIN role ON staff.role = role.id;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["role"].Visible = false;
                    dataGridView1.Columns["name"].HeaderText = "Имя";
                    dataGridView1.Columns["surname"].HeaderText = "Фамилия";
                    dataGridView1.Columns["patronymic"].HeaderText = "Отчество";
                    dataGridView1.Columns["role_name"].HeaderText = "Роль";
                    dataGridView1.Columns["login"].HeaderText = "Логин";
                    dataGridView1.Columns["password"].HeaderText = "Пароль";
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                    
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                userSaveChanges.Text = "Сохранить изменения";
                userNameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                userLoginTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["login"].Value.ToString();
                userSurnameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["surname"].Value.ToString();
                userPatronymicTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells["patronymic"].Value.ToString();
                idSelectedUser = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);
                userRoleComboBox.SelectedValue = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["role"].Value);
            }
        }
        private void CreateUser()
        {
            if (userPasswordTextBox.Text == userPasswordConfirmTextBox.Text)
            {
                int roleId = Convert.ToInt32(userRoleComboBox.SelectedValue);
                if (roleId == 0)
                {
                    MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (userPasswordTextBox.Text == "" || userPasswordTextBox.Text.Length < 3)
                {
                    MessageBox.Show("Пароль слишком короткий!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(checkUniqueLogin(userLoginTextBox.Text.Trim()) == 1)
                {
                    MessageBox.Show("Пользователь с таким логином существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query = $"INSERT INTO staff (name, surname, patronymic, role, login, password) VALUES ('{userNameTextBox.Text}', '{userSurnameTextBox.Text}', '{userPatronymicTextBox.Text}', {userRoleComboBox.SelectedValue}, '{userLoginTextBox.Text.Trim()}', '{GetHashPwd(userPasswordTextBox.Text)}');";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пользователь создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ClearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveUserChanges()
        {
            try
            {
                if (userPasswordTextBox.Text != "")
                {
                    if (userPasswordTextBox.Text == userPasswordConfirmTextBox.Text)
                    {
                        int roleId = Convert.ToInt32(userRoleComboBox.SelectedValue);
                        if (roleId == 0)
                        {
                            MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (userPasswordTextBox.Text == "" || userPasswordTextBox.Text.Length < 3)
                        {
                            MessageBox.Show("Пароль слишком короткий!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DialogResult q = MessageBox.Show("Вы действительно хотите заменить пароль для этой учётной записи?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (q == DialogResult.Yes)
                        {
                            string query = $"UPDATE staff SET name = '{userNameTextBox.Text.Trim()}', surname = '{userSurnameTextBox.Text.Trim()}', patronymic = '{userPatronymicTextBox.Text.Trim()}', role = {userRoleComboBox.SelectedValue}, login = '{userLoginTextBox.Text.Trim()}', password = '{GetHashPwd(userPasswordTextBox.Text)}' where id = {idSelectedUser}";
                            using (MySqlConnection conn = new MySqlConnection(connStr))
                            {
                                conn.Open();
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Данные о полmзователе изменены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                ClearTextBoxes();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    int roleId = Convert.ToInt32(userRoleComboBox.SelectedValue);
                    if (roleId == 0)
                    {
                        MessageBox.Show("Выберите роль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string query = $"UPDATE staff SET name = '{userNameTextBox.Text.Trim()}', surname = '{userSurnameTextBox.Text.Trim()}', patronymic = '{userPatronymicTextBox.Text.Trim()}', role = {userRoleComboBox.SelectedValue}, login = '{userLoginTextBox.Text.Trim()}' where id = {idSelectedUser}";
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные о пользователе изменены", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ClearTextBoxes();
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ClearTextBoxes()
        {
            userNameTextBox.Text = "";
            userSurnameTextBox.Text = "";
            userPatronymicTextBox.Text = "";
            userLoginTextBox.Text = "";
            userPasswordTextBox.Text = "";
            userPasswordConfirmTextBox.Text = "";
            userRoleComboBox.SelectedIndex = 0;
        }

        private void userSaveChanges_Click(object sender, EventArgs e)
        {
            if(userSaveChanges.Text == "Создать")
            {
                CreateUser();
                filldgv();
            }
            else if (userSaveChanges.Text == "Сохранить изменения")
            {
                SaveUserChanges();
                filldgv();
            }                
        }
        private int checkUniqueLogin(string login)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = $"SELECT id FROM staff where login = '{login}'";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if(cmd.ExecuteScalar() == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return 1; }
        }

        private void userNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if ((e.KeyChar >= 'А' && e.KeyChar <= 'я') || e.KeyChar == 'ё' || e.KeyChar == 'Ё')
                return;

            e.Handled = true;
        }

        private void userSurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if ((e.KeyChar >= 'А' && e.KeyChar <= 'я') || e.KeyChar == 'ё' || e.KeyChar == 'Ё' | e.KeyChar == '-' || e.KeyChar == '—')
                return;

            e.Handled = true;
        }

        private void userPatronymicTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;

            if ((e.KeyChar >= 'А' && e.KeyChar <= 'я') || e.KeyChar == 'ё' || e.KeyChar == 'Ё')
                return;

            e.Handled = true;
        }

        private void userPasswordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void userPasswordConfirmTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
                return;

            e.Handled = true;
        }

        private void userLoginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                (e.KeyChar >= 'a' && e.KeyChar <= 'z'))
                return;

            if (char.IsDigit(e.KeyChar))
                return;

            if (char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar))
                return;

            e.Handled = true;
        }

        private string GetHashPwd(string pwd)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(pwd);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }
    }
}
