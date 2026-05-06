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

        private double lastLat = 0;
        private double lastLon = 0;
        private double lastZoom = 0;

        private bool isProcessing = false;

        public ChooseAddress()
        {
            InitializeComponent();
        }

        private async void ChooseAddress_Load(object sender, EventArgs e)
        {
            try
            {
                await webView21.EnsureCoreWebView2Async(null);

                webView21.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                string path = Path.Combine(Application.StartupPath, "map.html");
                webView21.Source = new Uri(path);

                webView21.CoreWebView2.NavigationCompleted += async (s, args) =>
                {
                    await Task.Delay(300);

                    double lat = Properties.Settings.Default.LastLat;
                    double lon = Properties.Settings.Default.LastLon;
                    double zoom = Properties.Settings.Default.LastZoom;
                    MessageBox.Show($"LOAD: {lat}, {lon}, zoom={zoom}");
                    if (IsValid(lat, lon) && zoom > 0)
                    {
                        await webView21.CoreWebView2.ExecuteScriptAsync(
                            $"setInitialLocation({lat}, {lon}, {zoom});"
                        );
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                if (isProcessing) return;

                var data = JObject.Parse(e.WebMessageAsJson);

                double lat = (double)data["lat"];
                double lon = (double)data["lon"];
                double zoom = (double)data["zoom"];
                string address = data["address"].ToString();

                if (!IsValid(lat, lon)) return;

                lastLat = lat;
                lastLon = lon;
                lastZoom = zoom;

                isProcessing = true;

                this.Invoke(new Action(() =>
                {
                    var result = MessageBox.Show(
                        $"Выбрать адрес доставки?\n\n{address}",
                        "Подтверждение",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        SelectedAddress = address;

                        Properties.Settings.Default.LastLat = lastLat;
                        Properties.Settings.Default.LastLon = lastLon;
                        Properties.Settings.Default.LastZoom = lastZoom;
                        Properties.Settings.Default.Save();
                        MessageBox.Show($"SAVE: {lat}, {lon}, zoom={zoom}");
                        DialogResult = DialogResult.OK;
                        Close();
                    }

                    isProcessing = false;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isProcessing = false;
            }
        }

        private bool IsValid(double lat, double lon)
        {
            return !(lat == 0 && lon == 0) &&
                   lat >= -85 && lat <= 85 &&
                   lon >= -180 && lon <= 180;
        }

        private void ChooseAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsValid(lastLat, lastLon))
            {
                Properties.Settings.Default.LastLat = lastLat;
                Properties.Settings.Default.LastLon = lastLon;
                Properties.Settings.Default.LastZoom = lastZoom;
                Properties.Settings.Default.Save();
            }
        }
    }
}

