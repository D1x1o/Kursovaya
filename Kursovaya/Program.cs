using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int? value = SessionTime.GetValueSecond();
            UserActivityMonitor.TimeoutSeconds = value ?? 30;
            UserActivityMonitor.Start();
            Application.Run(new Auth());
        }
    }
}
