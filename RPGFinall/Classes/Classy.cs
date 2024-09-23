namespace RPGFinall.Classes
{
    public class Classy
    {
        public string ClassName { get; set; }
        public int ClassHealth { get; set; }
        public int ClassDamage { get; set; }
        public int ClassArmor { get; set; }
        public int ClassEnergy { get; set; }

        public string GraphicFile { get; set; }


        public Classy(string className, int classHealth, int classDamage, int classArmor, int classEnergy, string graphicFile)
        {
            ClassName = className;
            ClassHealth = classHealth;
            ClassDamage = classDamage;
            ClassArmor = classArmor;
            ClassEnergy = classEnergy;
            GraphicFile = graphicFile;
        }
    }
}
