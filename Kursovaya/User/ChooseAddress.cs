using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya.User
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class ChooseAddress : Form
    {
        public string SelectedAddress { get; private set; }
        public ChooseAddress()
        {
            InitializeComponent();
        }

        private async void ChooseAddress_Load(object sender, EventArgs e)
        {
            await webView21.EnsureCoreWebView2Async(null);

            webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            string path = Path.Combine(Application.StartupPath, "map.html");
            webView21.Source = new Uri(path);
        }

        private async void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(e.WebMessageAsJson);

            double lat = data.lat;
            double lon = data.lon;
            string address = data.address;
            SelectedAddress = data.address;
            //MessageBox.Show($"Адрес:\n{address}\n\nШирота: {lat}\nДолгота: {lon}");
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }        
    }
}
