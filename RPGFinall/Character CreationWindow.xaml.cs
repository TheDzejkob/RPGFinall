using RPGFinall.Classes;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RPGFinall
{
    public partial class Character_CreationWindow : Window
    {
        string filepathKnight = "Obrazky/KnightClass.png";
        string filepathMage = "Obrazky/MageClass.png";
        string filepathRogue = "Obrazky/RogueClass.png";
        string filepathArcher = "Obrazky/ArcherClass.png";

        // HardCoded Classy později přidat deserializaci z json filu pro jednoduší scalování (týká se i enemaku)
        new Classy Knight = new Classy("Knight", 15, 2, 6, 30);
        new Classy Mage   = new Classy("Mage",10,5,1,35);
        new Classy Rogue = new Classy("Rogue", 12, 4, 2, 40);
        new Classy Archer = new Classy("Archer", 8, 6, 0, 20);


        // hráč
        new Player player = new Player(1, "default name", 1, 1, 1, true, null);

        public Character_CreationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

            // po tom co se klikneš na jeden z buttonů tak se zmení image 
        private void KnightButton_Click(object sender, RoutedEventArgs e)
        {   
            player.PlayerClass = Knight;
            ClassImage.Source = new BitmapImage(new Uri(filepathKnight, UriKind.Relative));
            ClassNameLabel.Content = Knight.ClassName;
            HpStatyLabel.Content = "Class Hp‎ " + Knight.ClassHealth;
            DmgStatyLabel.Content = "Class Dmg‎ " + Knight.ClassDamage;
            ArmorStatyLabel.Content = "Class Armor‎ " + Knight.ClassArmor;
            EnergyStatyLabel.Content = "Class Stamina‎ " + Knight.ClassEnergy;

        }

        private void MageButton_Click(object sender, RoutedEventArgs e)
        {
            player.PlayerClass = Mage;
            ClassImage.Source = new BitmapImage(new Uri(filepathMage, UriKind.Relative));
            ClassNameLabel.Content = Mage.ClassName;
            HpStatyLabel.Content = "Class Hp‎ " + Mage.ClassHealth;
            DmgStatyLabel.Content = "Class Dmg‎ " + Mage.ClassDamage;
            ArmorStatyLabel.Content = "Class Armor‎ " + Mage.ClassArmor;
            EnergyStatyLabel.Content = "Class Mana‎ ‎‎‎‎‎‎‎‎‎ ‎" + Mage.ClassEnergy;

        }

        private void RogueButton_Click(object sender, RoutedEventArgs e)
        {
            player.PlayerClass = Rogue;
            ClassImage.Source = new BitmapImage(new Uri(filepathRogue, UriKind.Relative));
            ClassNameLabel.Content = Rogue.ClassName;
            HpStatyLabel.Content = "Class Hp‎ " + Rogue.ClassHealth;
            DmgStatyLabel.Content = "Class Dmg‎ " + Rogue.ClassDamage;
            ArmorStatyLabel.Content = "Class Armor‎ " + Rogue.ClassArmor;
            EnergyStatyLabel.Content = "Class Stamina‎ " + Rogue.ClassEnergy;

        }

        private void ArcherButton_Click(object sender, RoutedEventArgs e)
        {
            player.PlayerClass = Archer;
            ClassImage.Source = new BitmapImage(new Uri(filepathArcher, UriKind.Relative));
            ClassNameLabel.Content = Archer.ClassName;
            HpStatyLabel.Content = "Class Hp‎ " + Archer.ClassHealth;
            DmgStatyLabel.Content = "Class Dmg‎ " + Archer.ClassDamage;
            ArmorStatyLabel.Content = "Class Armor‎ " + Archer.ClassArmor;
            EnergyStatyLabel.Content = "Class Stamina‎ " + Archer.ClassEnergy;

        }

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            NameLabel.Visibility = Visibility.Visible;
            NameTextBox.Visibility = Visibility.Visible;

            ClassImage.Visibility = Visibility.Hidden;
            ClassNameLabel.Visibility = Visibility.Hidden;
            HpStatyLabel.Visibility = Visibility.Hidden;
            DmgStatyLabel.Visibility = Visibility.Hidden;
            ArmorStatyLabel.Visibility = Visibility.Hidden;
            EnergyStatyLabel.Visibility = Visibility.Hidden;

            KnightButton.Visibility = Visibility.Hidden;
            MageButton.Visibility = Visibility.Hidden;
            RogueButton.Visibility = Visibility.Hidden;
            ArcherButton.Visibility = Visibility.Hidden;

            NameButton.Visibility = Visibility.Hidden;
            ReadyButton.Visibility = Visibility.Visible;

        }
        private void CreateCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            player.Name = NameTextBox.Text;
            player.Health = player.PlayerClass.ClassHealth;
            player.Damage = player.PlayerClass.ClassDamage;
            player.Armot = player.PlayerClass.ClassArmor;
            player.Energy = player.PlayerClass.ClassEnergy;

            MainGame mainGame = new MainGame(player);
            mainGame.Show();
            this.Close();
        }
    }
}
