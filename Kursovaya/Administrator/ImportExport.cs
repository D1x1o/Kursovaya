using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace Kursovaya.Administrator
{
    public partial class FormExportImport : Form
    {
        string connStr = ConnectionString.GetConnectionString();
        public FormExportImport()
        {
            InitializeComponent();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            
        }        

        private void importButton_Click(object sender, EventArgs e)
        {

        }

        private void openDump(object sender, EventArgs e)
        {

        }
    }
}
