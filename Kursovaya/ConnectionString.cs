using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// КЛАСС Формироавния строки подключения к БД 

namespace Kursovaya
{
    class ConnectionString
    {
        public static string GetConnectionString()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // Путь до нашей папки в AppData
            string pepeShopPath = Path.Combine(appDataPath, "pepeShop");
            string pepeConn = Path.Combine(pepeShopPath, "connection.csv");
            string[] connItems = new string[3];

            using (StreamReader reader = new StreamReader(pepeConn))
            {
                reader.ReadLine();
                string input2 = reader.ReadLine();
                if(input2 == null)
                {
                    return "";
                }
                connItems = input2.Split(',').ToArray();                
            }
            return $"Server={connItems[0]}; Database=db95; User Id={connItems[1]}; Password={connItems[2]};";
            //return $"Server={Settings.Default.host}; User Id={Settings.Default.user};Database=1; Password={Settings.Default.pwd};";
        }
    }
}


