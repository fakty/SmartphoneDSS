using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Models
{
    abstract class Formula : IEquatable<Formula>
    {
        public String Name { get; }

        public bool Value { get; set; } = false;

        public Formula(String name)
        {
            this.Name = name;
        }

        public Formula(Formula f)
        {
            this.Name = f.Name;
            this.Value = f.Value;
        }

        public bool Equals(Formula other)
        {
            return this.Name.Equals(other.Name) && this.Value == other.Value;
        }
    }
}
