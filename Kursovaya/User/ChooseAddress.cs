using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using System.Windows.Forms;

namespace Kursovaya.User
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class ChooseAddress : Form
    {
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
        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var json = e.WebMessageAsJson;

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            double lat = data.lat;
            double lon = data.lon;

            MessageBox.Show($"Широта: {lat}\nДолгота: {lon}");
        }
    }
}
