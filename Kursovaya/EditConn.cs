using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class EditConn : Form
    {
        public EditConn()
        {
            InitializeComponent();
            showConnData();
        }

        private void showConnData()
        {
            serverAddres.Text = Settings.Default.host;
            serverUser.Text = Settings.Default.user;
            serverPassword.Text = Settings.Default.pwd;
        } 

        private void saveConnData_Click(object sender, EventArgs e)
        {
            Settings.Default.host = serverAddres.Text;
            Settings.Default.user = serverUser.Text;
            Settings.Default.pwd = serverPassword.Text;
            MessageBox.Show("Данные для подключения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }
    }
}
