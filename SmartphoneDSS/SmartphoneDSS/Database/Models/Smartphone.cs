using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Models
{
    class Smartphone
    {
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
    }
}
