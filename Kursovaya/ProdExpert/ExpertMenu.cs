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
        public ExpertMenu()
        {
            InitializeComponent();
        }

        private void FormDocSupplyProd_Click(object sender, EventArgs e)
        {
            FormProdSupply prod = new FormProdSupply();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void ProdInStock_Click(object sender, EventArgs e)
        {
            ProdInStock prod = new ProdInStock();
            Hide();
            prod.ShowDialog();
            Show();
        }

        private void addPic_Click(object sender, EventArgs e)
        {
            FormAddPic addPic = new FormAddPic();
            Hide();
            addPic.ShowDialog();
            Show();
        }
    }
}
