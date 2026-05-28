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
    public partial class OrderDetail : Form
    {
        public OrderDetail(string compound)
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("info", "Состав заказа");
            dataGridView1.Rows.Add(compound);
        }
    }
}
