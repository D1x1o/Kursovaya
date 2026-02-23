using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ФОРМА меню админисратора 

namespace Kursovaya.Administrator
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void ShowUsers_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Пользователи" 
        {
            Users prod = new Users(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму работы с пользователями
            Show(); // после окончания работы с пользователями обратно отображаем меню
        }

        private void ShowOrders_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Заказы" 
        {
            Orders prod = new Orders(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму работы с заказами
            Show(); // после окончания работы с заказами обратно отображаем меню
        }

        private void ShowProducts_Click(object sender, EventArgs e) // обработчик нажатия на кнопку "Товары" 
        {
            Prod prod = new Prod(); // создаём экземпляр класса
            Hide(); // скрываем текущую форму
            prod.ShowDialog(); // отображаем форму просмотра товаров
            Show(); // после окончания работы с товарами обратно отображаем меню
        }
    }
}
