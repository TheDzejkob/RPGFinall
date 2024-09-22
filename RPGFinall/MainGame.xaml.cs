using RPGFinall.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RPGFinall
{
    /// <summary>
    /// Interakční logika pro MainGame.xaml
    /// </summary>
    public partial class MainGame : Window
    {
        public MainGame(Player player)
        {
            GameMaster gameMaster = new GameMaster(true, true, 0, 0, player);


            InitializeComponent();
            
            if (gameMaster.PlayersTurn == true)
            {
                TurnLabel.Content = player.Name + "'s Turn";
            }
            else
            {
                TurnLabel.Content = "Enemy's turn";
            }

        }
    }
}
