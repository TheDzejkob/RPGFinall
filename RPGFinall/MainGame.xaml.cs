﻿using RPGFinall.Classes;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RPGFinall
{
    public partial class MainGame : Window
    {

        private Player _player;
        GameMaster gameMaster;
        Player CurentEnemy;
        int clicked;

        Ability basicAttack;
        Ability basicHeal;
        Ability heavyAttack;
        Ability armorUP;
        bool EnemyAbilityUsed;
        bool PlayerAbilityUsed;

        private Classy basicEnemy;
        private Player BoneSprout;

        public MainGame(Player player)
        {
            _player = player;
            EnemyAbilityUsed = false;
            PlayerAbilityUsed = false;


            InitializeComponent();

            basicAttack = new Ability("Light Attack", "the most basic attack", player.Damage, 1, 0, 0, 0);
            basicHeal = new Ability("Heal", "restore small portion of your HP", 0, 2, 99, 3, 0);
            heavyAttack = new Ability("Heavy Attack", "Heavy attack that uses more stamina but deals more ddemage", player.Damage * 2, 2, 0, 0, 0);
            armorUP = new Ability("Armor Up", "Increase your armor", 0, 3, 99, 0, 3);
            basicEnemy = new Classy("Basic Enemy", 5, 1, 0, 5, "obrazky/BoneSprout.png");
            BoneSprout = new Player(8, "Bone Sprout", 0, 1, 5, true, basicEnemy);

            gameMaster = new GameMaster(true, true, 0, 0, _player, false);

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


            StatsPageImg.Source = new BitmapImage(new Uri(_player.PlayerClass.GraphicFile, UriKind.Relative));
        }

        private void GetUpButton_Click(object sender, RoutedEventArgs e)
        {
            clicked++;
            if (clicked == 1)
            {
                WakeUpText.Text = "As you gather your wits and rise from the cold ground, your eyes catch sight of \n a small creature skittering toward you. A skeletal fiend, its bones brittle yet quick, \n with empty sockets burning with malice. It’s a BoneSprout, and it hungers for your death";
                EEEEEE.Content = "Defend yourself!";
            }
            else if (clicked == 2)
            {

                WakeUpText.Visibility = Visibility.Hidden;
                GetUpButton.Visibility = Visibility.Hidden;

                StartCombat();
            }
        }

        private void CloseStatsButton_Click(object sender, RoutedEventArgs e)
        {
            StatsOverlay.Visibility = Visibility.Hidden;
        }

        void StartCombat()
        {
            gameMaster.InCombat = true;
            CurentEnemy = BoneSprout;
            EnemyCombatImage.Source = new BitmapImage(new Uri(CurentEnemy.PlayerClass.GraphicFile, UriKind.Relative));
            PlayerCombatImage.Source = new BitmapImage(new Uri(_player.PlayerClass.GraphicFile, UriKind.Relative));
            PlayerCombatHp.Visibility = Visibility.Visible;
            EnemyCombatHp.Visibility = Visibility.Visible;
            PlayerCombatHp.Content = "HP " + _player.Health;
            EnemyCombatHp.Content = "HP " + CurentEnemy.Health;
            PlayerCombatArmor.Content = "Armor " + _player.Armot;
            PlayerCombatStamina.Content = "Stamina " + _player.Energy;


            if (gameMaster.PlayersTurn == true)
            {
                TurnLabel.Content = _player.Name + "'s Turn";
            }
            else
            {
                TurnLabel.Content = "Enemy's turn";
            }
        }



        void UpdateCombatLabels()
        {
            PlayerCombatHp.Content = "HP " + _player.Health;
            EnemyCombatHp.Content = "HP " + CurentEnemy.Health;
            PlayerCombatArmor.Content = "Armor " + _player.Armot;
            PlayerCombatStamina.Content = "Stamina " + _player.Energy;
            if(gameMaster.PlayersTurn == true)
            {
                TurnLabel.Content = _player.Name + "'s Turn";
            }
            else
            {
                TurnLabel.Content = "Enemy's turn";
            }
            if (_player.Health <= 0)
            {
                Death();
            }
            if (CurentEnemy.Health <= 0)
            {
                EnemyDeath();
            }
        }

        async void EnemyTurn()
        {
            if (CurentEnemy.Health <= CurentEnemy.Health / 2 && EnemyAbilityUsed == false)
            {
                CurentEnemy.Health += basicHeal.Regen;

                EnemyAbilityUsed = true;
                await System.Threading.Tasks.Task.Delay(2000); 
            }
            else
            {
                if (_player.Armot > 0)
                {
                    _player.Armot -= BoneSprout.Damage;
                    await System.Threading.Tasks.Task.Delay(2000);

                }
                else
                {
                    _player.Health -= basicAttack.Damage;
                    await System.Threading.Tasks.Task.Delay(2000);

                }
            }
            gameMaster.PlayersTurn = true;
            UpdateCombatLabels();
        }

        private void BasicAttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_player.Energy >= basicAttack.EnergyCost && gameMaster.PlayersTurn == true)
            {
                if (CurentEnemy.Armot > 0)
                {
                    CurentEnemy.Armot -= basicAttack.Damage;
                }
                else
                {
                    CurentEnemy.Health -= basicAttack.Damage;
                }
                _player.Energy -= basicAttack.EnergyCost;
            }
            else
            {
                MessageBox.Show("Not enough energy or not ur turn ");
            }
            gameMaster.PlayersTurn = false;
            UpdateCombatLabels();
            EnemyTurn();
        }
        //kašlu na nejake komentovani kdo se ma psat s komentama  
        // jsou 4 ráno miluju fr -_- 👌
        private void HeavyAttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (_player.Energy >= heavyAttack.EnergyCost && gameMaster.PlayersTurn == true)
            {
                if (CurentEnemy.Armot > 0)
                {
                    CurentEnemy.Armot -= heavyAttack.Damage;
                }
                else
                {
                    CurentEnemy.Health -= heavyAttack.Damage;
                }
                _player.Energy -= heavyAttack.EnergyCost;
            }
            else
            {
                MessageBox.Show("Not enough energy or not ur turn");
            }
            gameMaster.PlayersTurn = false;
            UpdateCombatLabels();
            EnemyTurn();
        }

        private void ArmorUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (_player.Energy >= armorUP.EnergyCost && gameMaster.PlayersTurn == true)
            {
                _player.Armot += armorUP.Armor;
                _player.Energy -= armorUP.EnergyCost;
            }
            else
            {
                MessageBox.Show("Not enough energy or not ur turn");
            }
            gameMaster.PlayersTurn = false;
            UpdateCombatLabels();
            EnemyTurn();
        }

        void Death()
        {
            WakeUpText.Visibility = Visibility.Visible;
            WakeUpText.Text = "U DIED";

            BasicAttackButton.Visibility = Visibility.Hidden;
            HeavyAttackButton.Visibility = Visibility.Hidden;
            ArmorUpButton.Visibility = Visibility.Hidden;
            CloseWonButton.Visibility = Visibility.Visible;
        }
        void EnemyDeath()
        {
            WakeUpText.Visibility = Visibility.Visible;
            WakeUpText.Text = "U KILLED THE ENEMY";

            BasicAttackButton.Visibility = Visibility.Hidden;
            HeavyAttackButton.Visibility = Visibility.Hidden;
            ArmorUpButton.Visibility = Visibility.Hidden;
            CloseWonButton.Visibility = Visibility.Visible;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
