using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGFinall.Classes
{
    internal class Player
    {
        public int Health { get; set; }
        public String Name { get; set; }
        public int Armot { get; set; }
        public int Damage { get; set; }
        public int Energy { get; set; }
        public bool IsStamina { get; set; }

        public Classy PlayerClass { get; set; }


        public Player(int health, string name, int armot, int damage, int energy, bool isStamina ,Classy playerClassa)
        {
            Health = health;
            Name = name;
            Armot = armot;
            Damage = damage;
            Energy = energy;
            IsStamina = isStamina;
            PlayerClass = playerClassa;
        }
    }
    
}
