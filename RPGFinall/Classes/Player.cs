namespace RPGFinall.Classes
{
    public class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Armot { get; set; } 
        public int Damage { get; set; }
        public int Energy { get; set; }
        public bool IsStamina { get; set; }
        public Classy PlayerClass { get; set; }

        public Player(int health, string name, int armot, int damage, int energy, bool isStamina, Classy playerClassa)
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
