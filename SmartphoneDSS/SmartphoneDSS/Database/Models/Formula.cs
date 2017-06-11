﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartphoneDSS.Database.Models
{
    class Formula : IEquatable<Formula>
    {
        public String Name { get; }

        public bool Value { get; set; } = false;

        public Formula(String name)
        {
            this.Name = name;
        }

        public bool Equals(Formula other)
        {
            return Name.Equals(other.Name) && Value == other.Value;
        }
    }
}
