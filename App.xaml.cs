using Snowman.GameLevel;
using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Snowman
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IGameBuilder gameBuilder;
        public static Game game;

        public static IGameBuilder GameBuilder
        {
            get { return gameBuilder; }
            set { gameBuilder = value; }
        }

        public static void newGame()
        {
            game = gameBuilder.GetGame();
        }
    }
}
