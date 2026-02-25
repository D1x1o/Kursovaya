using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Kursovaya.Administrator
{
    public partial class EditOrder : Form
    {
        int orderID;
        string connStr = ConnectionString.GetConnectionString();
        public EditOrder(int idOrder)
        {
            orderID = idOrder;
            InitializeComponent();
            FillComboBox();
            Fill(idOrder);
        }
        private void FillComboBox()
        {
            try
            {
                string query = $"SELECT id, status FROM `statuses`;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        statusComboBox.DataSource = table;
                        statusComboBox.DisplayMember = "status";     // что показывать
                        statusComboBox.ValueMember = "id";     // что хранить
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void Fill(int idOrder)
        {
            try
            {
                string query = $"SELECT deliveryaddress, phone_number, ordertime, ordercomplitetime, status FROM `order` WHERE idorder = {idOrder} ";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Адрес
                            addressTextBox.Text = reader["deliveryaddress"]?.ToString();

                            // Телефон
                            string phone = reader["phone_number"]?.ToString();

                            if (!string.IsNullOrEmpty(phone))
                            {
                                // Оставляем только цифры
                                phone = new string(phone.Where(char.IsDigit).ToArray());

                                // Если начинается с 8 → меняем на 7
                                if (phone.StartsWith("8"))
                                    phone = "7" + phone.Substring(1);

                                // Если номер начинается с 7 → убираем первую цифру
                                if (phone.StartsWith("7"))
                                    phone = phone.Substring(1);

                                // Вставляем 10 цифр в MaskedTextBox
                                phoneNumberTextBox.Text = phone;
                            }

                            // Статус
                            int statusId = Convert.ToInt32(reader["status"]);

                            // Устанавливаем выбранный статус
                            statusComboBox.SelectedValue = statusId;

                            // Дата
                            if (reader["ordercomplitetime"] != DBNull.Value)
                            {
                                DateTime date = Convert.ToDateTime(reader["ordercomplitetime"]);
                                DateTime maxDate = date.AddMonths(6);
                                monthCalendar1.SetDate(date);
                                monthCalendar1.MinDate = date;
                                monthCalendar1.MaxDate = maxDate;
                            }
                        }
                    }
                }
            }
            catch(Exception ex) {MessageBox.Show(ex.Message);  }
        }
        bool detector = false;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = e.Start;

            // Если дата больше MaxDate — ставим MaxDate
            if (selectedDate > monthCalendar1.MaxDate)
            {
                MessageBox.Show(
                    "Дата не может быть больше, чем через полгода от сегодня",
                    "Ошибка выбора даты",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                monthCalendar1.SetDate(monthCalendar1.MaxDate);
                return;
            }
            // Проверка на выходные
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                if (!detector)
                {
                    MessageBox.Show(
                        "Суббота и воскресенье недоступны",
                        "Ошибка выбора даты",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    detector = true;
                }

                DateTime d = selectedDate;
                do
                {
                    d = d.AddDays(-1);
                } while ((d.DayOfWeek != DayOfWeek.Monday) && d >= monthCalendar1.MinDate);

                if (d < monthCalendar1.MinDate)
                    d = monthCalendar1.MinDate;

                monthCalendar1.SetDate(d);
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = monthCalendar1.SelectionStart;
                DateTime result = date.Date + DateTime.Now.TimeOfDay;
                string formatted = result.ToString("yyyy-MM-dd HH:mm:ss");
                string query = $"UPDATE `order` SET deliveryaddress = '{addressTextBox.Text.Trim()}', phone_number = '{phoneNumberTextBox.Text}', status = {Convert.ToInt32(statusComboBox.SelectedValue)}, ordercomplitetime = '{formatted}' WHERE idorder = {orderID};";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    int affected = cmd.ExecuteNonQuery();
                    if(affected >= 1)
                    {
                        MessageBox.Show(
                    "Данные о заказе успешно изменены",
                    "Успех",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                        this.Close();
                    }
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
