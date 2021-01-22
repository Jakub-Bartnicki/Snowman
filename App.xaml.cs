using Snowman.Interfaces;
using Snowman.Themes;
using System.Windows;

namespace Snowman
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IGameBuilder gameBuilder;
        private static Game game;
        public static Game Game { get { return game; } }

        public App() : base()
        { }

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
