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
    public partial class AdminSettings : Form
    {
        public AdminSettings()
        {
            InitializeComponent();
            numericUpDown1.Value = SessionTime.GetValueSecond();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SessionTime.SetValueSecond(Convert.ToInt32(numericUpDown1.Value));
            MessageBox.Show("Данные сохранены!\nИзменения вступят в силу после перезапуска приложения.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
