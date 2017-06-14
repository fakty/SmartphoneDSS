using SmartphoneDSS.Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SmartphoneDSS.Database
{
    class SmartphoneReader
    {
        private static readonly String FileName = "smartphones.csv";
        private static readonly string FilePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Assets\\" + FileName;

        private static List<Smartphone> Smartphones;

        public static List<Smartphone> GetSmartphones()
        {
            if (Smartphones != null)
            {
                return Smartphones;
            } 
            else
            {
                ReadFromFile();
                return Smartphones;
            }
        }

        private static void ReadFromFile()
        {
            Smartphones = new List<Smartphone>();
            using (var fs = File.OpenRead(FilePath))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    if (values[0].Equals("Nazwa"))
                    {
                        continue;
                    }
                    else
                    {
                        Smartphones.Add(ParseLine(values));
                    }
                }
            }
        }

        private static Smartphone ParseLine(string[] values)
        {
            Smartphone smartphone = new Smartphone()
            {
                Name = values[0],
                RAM = float.Parse(values[1], CultureInfo.InvariantCulture),
                BatteryCapacity = int.Parse(values[2]),
                ScreenSize = float.Parse(values[3], CultureInfo.InvariantCulture),
                IsFullHD = ParseToBoolean(values[4]),
                HasToughenedGlass = ParseToBoolean(values[5]),
                Camera = float.Parse(values[6], CultureInfo.InvariantCulture),
                HasLTE = ParseToBoolean(values[7]),
                MaxConversationTime = int.Parse(values[8]),
                HasFastCharging = ParseToBoolean(values[9]),
                InternalMemory = int.Parse(values[10]),
                HasExternalSlot = ParseToBoolean(values[11]),
                Price = float.Parse(values[12], CultureInfo.InvariantCulture)
            };
            return smartphone;
        }

        private static bool ParseToBoolean(String value)
        {
            if (value.Equals("Tak"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
