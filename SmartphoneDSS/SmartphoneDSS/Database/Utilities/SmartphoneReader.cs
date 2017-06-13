using SmartphoneDSS.Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database
{
    class SmartphoneReader
    {
        private static readonly String FileName = "smartphones.csv";
        private static readonly string FilePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Assets\\" + FileName;

        private static List<Smartphone> Smartphones;

        public static List<Smartphone> getSmartphones()
        {
            if (Smartphones != null)
            {
                return Smartphones;
            } 
            else
            {
                readFromFile();
                return Smartphones;
            }
        }

        private static void readFromFile()
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
                        Smartphones.Add(parseLine(values));
                    }
                }
            }
        }

        private static Smartphone parseLine(string[] values)
        {
            Smartphone smartphone = new Smartphone();
   
            smartphone.Name = values[0];
            smartphone.RAM = float.Parse(values[1], CultureInfo.InvariantCulture);
            smartphone.BatteryCapacity = int.Parse(values[2]);
            smartphone.ScreenSize = float.Parse(values[3], CultureInfo.InvariantCulture);
            smartphone.IsFullHD = parseToBoolean(values[4]);
            smartphone.HasToughenedGlass = parseToBoolean(values[5]);
            smartphone.Camera = float.Parse(values[6], CultureInfo.InvariantCulture);
            smartphone.HasLTE = parseToBoolean(values[7]);
            smartphone.MaxConversationTime = int.Parse(values[8]);
            smartphone.HasFastCharging = parseToBoolean(values[9]);
            smartphone.InternalMemory = int.Parse(values[10]);
            smartphone.HasExternalSlot = parseToBoolean(values[11]);
            smartphone.Price = float.Parse(values[12], CultureInfo.InvariantCulture);

            return smartphone;
        }

        private static bool parseToBoolean(String value)
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
