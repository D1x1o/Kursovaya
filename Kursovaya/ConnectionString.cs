﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya
{
    class ConnectionString
    {
        public static string GetConnectionString()
        {
            return "Server=localhost; Database=cursovaya; User Id=root; Password=;";
            //return "Server = localhost; Port = 3306; Database = cursovaya; User Id = root; Password =; AllowPublicKeyRetrieval = true; ";
            //return $"Server={Settings.Default.host};" +
            //       $"User Id={Settings.Default.user};" +
            //       $"Password={Settings.Default.pwd};";
        }
    }
}


