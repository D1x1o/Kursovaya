using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kursovaya
{
    static internal class SessionTime
    {
        static public int GetValueSecond()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appDataPath, "pepeShop");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fullPath = Path.Combine(folder, "SessionTime.cfg");

            if (File.Exists(fullPath))
            {
                string text = File.ReadAllText(fullPath);

                if (string.IsNullOrWhiteSpace(text))
                    return 30;

                return Convert.ToInt32(text);
            }
            else
            {
                File.WriteAllText(fullPath, "30");
                return 30;
            }
        }

        static public void SetValueSecond(int seconds)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appDataPath, "pepeShop");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string fullPath = Path.Combine(folder, "SessionTime.cfg");

            File.WriteAllText(fullPath, seconds.ToString());
        }
    }
}
