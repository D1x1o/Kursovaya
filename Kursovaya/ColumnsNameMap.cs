using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kursovaya
{
    internal static class ColumnsNameMap
    {
        // Словарь: системное имя колонки → русское название
        public static readonly Dictionary<string, string> Map = new Dictionary<string, string>()
        {
            { "model", "Модель" },
            { "produser", "Производитель" },
            { "socket", "Сокет" },
            { "frequency", "Частота" },
            { "architecture", "Архитектура" },
            { "core_int", "Количество ядер" },
            { "L3_caсhe", "L3 кэш" },
            { "thermal_power", "Тепловыделение" },
            { "cost", "Стоимость" },

            { "form_factor", "Форм фактор" },
            { "cpu_socket", "Сокет процессора" },
            { "ram_slots", "Количество слотов ОЗУ" },
            { "ram_support_type", "Поддерживаемый тип ОЗУ" },
            { "ram_max_capacity", "Максимальный объём ОЗУ" },
            { "chipset", "Чипсет" },
            { "expansion_slots", "Количество слотов расширения" },
            { "expansion_type", "Тип слотов расширения" },
            { "m2_ssd_slots", "Слоты для M.2 SSD" },

            { "type_of_device", "Тип устройства" },
            { "capacity_gb", "Объём" },
            { "write_speed", "Скорость записи" },
            { "read_speed", "Скорость чтения" },
            { "interface", "Разъём подключения" },

            { "color", "Цвет" },
            { "max_lenght_videocard", "Максимальная длина видеокарты" },
            { "max_height_cpu_cooler", "Максимальная высота кулера" },
            { "storage_slots", "Количество отсеков" },

            { "light", "Подсветка" },
            { "scale", "Размер вентилятора" },

            { "memory", "Объём видеопамяти" },
            { "bus_width", "Разрядность шины памяти" },
            { "memory_type", "Тип видеопамяти" },
            { "power_consumption", "Потребляемая мощность" },
            { "vender", "Производитель видеокарты" },
            { "gpu_lenght", "Длина видеокарты" },

            { "speed_mhz", "Частота памяти" },
            { "ram_type", "Тип памяти" },

            { "power", "Мощность" },
            { "certificate", "Сертификат" },

            { "max_heat_sink", "Рассеиваемая мощность" },
            { "cooler_height", "Высота кулера" },
            { "light_type", "Тип подсветки" },

            { "thermal_conductivity", "Теплопроводность" },
            { "packege_volume", "Вес" },
            { "shel_life", "Срок годности" },
            { "composition", "Состав" }
        };

        // Русское → Английское (создаём на основе Map)
        public static readonly Dictionary<string, string> ReverseMap = Map.ToDictionary(kv => kv.Value, kv => kv.Key);
        // ===== СТАТИЧЕСКИЙ КОНСТРУКТОР =====
        static ColumnsNameMap()
        {
            LoadFromJson();

            ReverseMap = Map.ToDictionary(kv => kv.Value, kv => kv.Key);
        }

        private static void LoadFromJson()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tables.json");

            if (!File.Exists(path))
                return;

            string json = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(json))
                return;

            JObject root = JObject.Parse(json);
            JArray tables = (JArray)root["tables"];

            foreach (JObject table in tables)
            {
                JArray columns = (JArray)table["columns"];

                foreach (JObject column in columns)
                {
                    string systemName = column["systemName"]?.ToString();
                    string displayName = column["displayName"]?.ToString();

                    if (!string.IsNullOrEmpty(systemName) &&
                        !string.IsNullOrEmpty(displayName) &&
                        !Map.ContainsKey(systemName))
                    {
                        Map.Add(systemName, displayName);
                    }
                }
            }
        }
        // Метод: Английское → Русское
        public static string GetRussianName(string columnName)
        {
            return Map.ContainsKey(columnName) ? Map[columnName] : columnName;
        }
        // Метод: Русское → Английское
        public static string GetEnglishName(string russianName)
        {
            return ReverseMap.ContainsKey(russianName) ? ReverseMap[russianName] : russianName;
        }        
    }
}
