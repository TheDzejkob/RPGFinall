﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGFinall.Classes
{
    internal class Classy
    {
        public string ClassName { get; set; }
        public int ClassHealth { get; set; }
        public int ClassDamage { get; set; }
        public int ClassArmor { get; set; }
        public int ClassEnergy { get; set; }

        public Classy(string className, int classHealth, int classDamage, int classArmor, int classEnergy)
        {
            ClassName = className;
            ClassHealth = classHealth;
            ClassDamage = classDamage;
            ClassArmor = classArmor;
            ClassEnergy = classEnergy;
        }
    }
}
