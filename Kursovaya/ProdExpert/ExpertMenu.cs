using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.ProdExpert
{
    public partial class ExpertMenu : Form
    {
        public ExpertMenu() // конструктор формы меню эксперта
        {
            InitializeComponent(); // инициализация компонентов формы (автоматически генерируемый код)
        }

        private void FormDocSupplyProd_Click(object sender, EventArgs e) // обработчик нажатия кнопки для документа поставки товаров
        {
            FormProdSupply prod = new FormProdSupply(); // создание экземпляра формы поставки товаров
            Hide(); // скрытие текущей формы меню
            prod.ShowDialog(); // открытие формы поставки в модальном режиме (блокирует работу с родительской формой)
            Show(); // после закрытия формы поставки снова показываем меню
        }

        private void ProdInStock_Click(object sender, EventArgs e) // обработчик нажатия кнопки для просмотра товаров на складе
        {
            ProdInStock prod = new ProdInStock(); // создание экземпляра формы товаров на складе
            Hide(); // скрытие текущей формы меню
            prod.ShowDialog(); // открытие формы склада в модальном режиме
            Show(); // после закрытия формы снова показываем меню
        }

        private void addPic_Click(object sender, EventArgs e) // обработчик нажатия кнопки для добавления изображения
        {
            FormAddPic addPic = new FormAddPic(); // создание экземпляра формы добавления изображения
            Hide(); // скрытие текущей формы меню
            addPic.ShowDialog(); // открытие формы добавления изображения в модальном режиме
            Show(); // после закрытия формы снова показываем меню
        }

        private void EditProdButton_Click(object sender, EventArgs e) // обработчик нажатия кнопки для редактирования товара
        {
            FormEditProd EditProd = new FormEditProd(); // создание экземпляра формы редактирования товара
            Hide(); // скрытие текущей формы меню
            EditProd.ShowDialog(); // открытие формы редактирования в модальном режиме
            Show(); // после закрытия формы снова показываем меню
        }

        private void button1_Click(object sender, EventArgs e) // обработчик нажатия кнопки для добавления категории
        {
            FormAddCategory category = new FormAddCategory(); // создание экземпляра формы добавления категории
            Hide(); // скрытие текущей формы меню
            category.ShowDialog(); // открытие формы добавления категории в модальном режиме
            Show(); // после закрытия формы снова показываем меню
        }

        private void button2_Click(object sender, EventArgs e) // обработчик нажатия кнопки для добавления товара
        {
            FormAddProd addprod = new FormAddProd(); // создание экземпляра формы добавления товара
            Hide(); // скрытие текущей формы меню
            addprod.ShowDialog(); // открытие формы добавления товара в модальном режиме
            Show(); // после закрытия формы снова показываем меню
        }
    }
}