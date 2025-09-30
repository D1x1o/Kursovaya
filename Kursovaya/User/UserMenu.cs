using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.User
{
    public partial class UserMenu : Form
    {
        public UserMenu()
        {
            InitializeComponent();
        }

        private void OpenUserProdButton_Click(object sender, EventArgs e)
        {
            UserProduct prod = new UserProduct();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void OpenUserOrder_Click(object sender, EventArgs e)
        {
            UserOrder ord = new UserOrder();
            Hide();
            ord.ShowDialog();
            Show();
        }
    }
}
