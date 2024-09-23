using RPGFinall.Classes;
using System;
using System.Windows;

namespace RPGFinall
{
    public partial class MainGame : Window
    {
        // Store player as a class-level field
        private Player _player;

        public MainGame(Player player)
        {
            // Assign player to the class-level field
            _player = player;

            GameMaster gameMaster = new GameMaster(true, true, 0, 0, _player);
            InitializeComponent();

            // Use _player instead of player
            if (gameMaster.PlayersTurn == true)
            {
                TurnLabel.Content = _player.Name + "'s Turn";
            }
            else
            {
                TurnLabel.Content = "Enemy's turn";
            }
        }

        private void StatsButton_Click(object sender, RoutedEventArgs e)
        {
            
            StatsOverlay.Visibility = Visibility.Visible;
            StatsName.Content = _player.Name + "'s Stats";

            HpStatyLabel.Content = "Health: " + _player.Health;
            DmgStatyLabel.Content = "Damage: " + _player.Damage;
            ArmorStatyLabel.Content = "Armor: " + _player.Armot;

            if (_player.IsStamina == true)
            {
                EnergyStatyLabel.Content = "Stamina: " + _player.Energy;
            }
            else
            {
                EnergyStatyLabel.Content = "Mana: " + _player.Energy;
            }
        }

        private void CloseStatsButton_Click(object sender, RoutedEventArgs e)
        {
            StatsOverlay.Visibility = Visibility.Hidden;
        }
    }
}
