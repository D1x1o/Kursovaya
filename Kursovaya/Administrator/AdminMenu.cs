using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.Administrator
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void ShowUsers_Click(object sender, EventArgs e)
        {
            Users prod = new Users();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void ShowOrders_Click(object sender, EventArgs e)
        {
            Orders prod = new Orders();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void ShowProducts_Click(object sender, EventArgs e)
        {
            Prod prod = new Prod();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void AddProdPicture_Click(object sender, EventArgs e)
        {
            ProdPic prod = new ProdPic();
            Hide();
            prod.ShowDialog();
            Show();
        }
    }
}
