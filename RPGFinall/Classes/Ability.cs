using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGFinall.Classes
{
    internal class Ability
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int EnergyCost { get; set; }
        public int Cooldown { get; set; }
        public int Regen { get; set; }
    }
}
