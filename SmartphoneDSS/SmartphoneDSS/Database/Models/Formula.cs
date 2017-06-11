using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database
{
    class Formula
    {
        public String Name { get; }

        public bool Value { get; set; }

        public Formula(String name)
        {
            this.Name = name;
        }
    }
}
