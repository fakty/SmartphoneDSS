using System;
using System.Globalization;

namespace SmartphoneDSS.Database.Models
{
    class Smartphone
    {
        private static String CSV_DELIMITER = ",";

        public String Name { get; set; }
        public float RAM { get; set; }
        public int BatteryCapacity { get; set; }
        public float ScreenSize { get; set; }
        public bool IsFullHD { get; set; }
        public bool HasToughenedGlass { get; set; }
        public float Camera { get; set; }
        public bool HasLTE { get; set; }
        public int MaxConversationTime { get; set; }
        public bool HasFastCharging { get; set; }
        public int InternalMemory { get; set; }
        public bool HasExternalSlot { get; set; }
        public float Price { get; set; }

        public static bool operator <=(Smartphone toComparePhone, Smartphone basePhone)
        {
            if (basePhone == null || toComparePhone == null)
            {
                return false;
            }
            return (
               toComparePhone.RAM <= basePhone.RAM &&
               toComparePhone.BatteryCapacity <= basePhone.BatteryCapacity &&
               toComparePhone.ScreenSize <= basePhone.ScreenSize &&
               Convert.ToInt32(toComparePhone.IsFullHD) <= Convert.ToInt32(basePhone.IsFullHD) &&
                Convert.ToInt32(toComparePhone.HasToughenedGlass) <= Convert.ToInt32(basePhone.HasToughenedGlass) &&
                toComparePhone.Camera <= basePhone.Camera &&
                Convert.ToInt32(toComparePhone.HasLTE) <= Convert.ToInt32(basePhone.HasLTE) &&
                toComparePhone.MaxConversationTime <= basePhone.MaxConversationTime &&
                Convert.ToInt32(toComparePhone.HasFastCharging) <= Convert.ToInt32(basePhone.HasFastCharging) &&
                toComparePhone.InternalMemory <= basePhone.InternalMemory &&
                Convert.ToInt32(toComparePhone.HasExternalSlot) <= Convert.ToInt32(basePhone.HasExternalSlot) &&
                toComparePhone.Price <= basePhone.Price);
        }

        public static bool operator >=(Smartphone toComparePhone, Smartphone basePhone)
        {
            if (basePhone == null || toComparePhone == null)
            {
                return false;
            }
            return (
               toComparePhone.RAM >= basePhone.RAM &&
               toComparePhone.BatteryCapacity >= basePhone.BatteryCapacity &&
               toComparePhone.ScreenSize >= basePhone.ScreenSize &&
               Convert.ToInt32(toComparePhone.IsFullHD) >= Convert.ToInt32(basePhone.IsFullHD) &&
                Convert.ToInt32(toComparePhone.HasToughenedGlass) >= Convert.ToInt32(basePhone.HasToughenedGlass) &&
                toComparePhone.Camera >= basePhone.Camera &&
                Convert.ToInt32(toComparePhone.HasLTE) >= Convert.ToInt32(basePhone.HasLTE) &&
                toComparePhone.MaxConversationTime >= basePhone.MaxConversationTime &&
                Convert.ToInt32(toComparePhone.HasFastCharging) >= Convert.ToInt32(basePhone.HasFastCharging) &&
                toComparePhone.InternalMemory >= basePhone.InternalMemory &&
                Convert.ToInt32(toComparePhone.HasExternalSlot) >= Convert.ToInt32(basePhone.HasExternalSlot) &&
                toComparePhone.Price >= basePhone.Price);
        }

        public override bool Equals(object obj)
        {
            if (this == null || obj == null)
            {
                return false;
            }
            return this.Name == (obj as Smartphone).Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string csvString = "\n" + Name + CSV_DELIMITER
                + Convert.ToString(RAM, CultureInfo.InvariantCulture) + CSV_DELIMITER
                + BatteryCapacity + CSV_DELIMITER
                + Convert.ToString(ScreenSize, CultureInfo.InvariantCulture) + CSV_DELIMITER
                + SmartphoneFileHandler.ParseFromBoolean(IsFullHD) + CSV_DELIMITER
                + SmartphoneFileHandler.ParseFromBoolean(HasToughenedGlass) + CSV_DELIMITER
                + Convert.ToString(Camera, CultureInfo.InvariantCulture) + CSV_DELIMITER
                + SmartphoneFileHandler.ParseFromBoolean(HasLTE) + CSV_DELIMITER
                + MaxConversationTime + CSV_DELIMITER
                + SmartphoneFileHandler.ParseFromBoolean(HasFastCharging) + CSV_DELIMITER
                + InternalMemory + CSV_DELIMITER
                + SmartphoneFileHandler.ParseFromBoolean(HasExternalSlot) + CSV_DELIMITER
                + Convert.ToString(Price, CultureInfo.InvariantCulture) + "\n";
                                
            return csvString;
        }
    }
}
