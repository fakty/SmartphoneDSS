using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Models
{
    class Smartphone
    {
        public static float TRESHOLD_RAM = 2f;
        public static int TRESHOLD_BATTERY_CAPACITY = 3300;
        public static float TRESHOLD_SCREEN_SIZE = 5.5f;
        public static float TRESHOLD_CAMERA = 13f;
        public static int TRESHOLD_MAX_CONVERSATION_TIME = 20;
        public static int TRESHOLD_INTERNAL_MEMORY = 16;

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
    }
}
