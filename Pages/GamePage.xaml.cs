using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using System.IO;

namespace Snowman.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private bool goLeft, goRight;
        
        public GamePage()
        {
            InitializeComponent();

            gameScreen.Focus();

            Application.Current.MainWindow.KeyDown += new KeyEventHandler(KeyIsDown);
            Application.Current.MainWindow.KeyUp += new KeyEventHandler(KeyIsUp);
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(6);
            gameTimer.Start();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            
            if (goLeft == true && Canvas.GetLeft(snowman) > 0)
            {
                Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) - 5);
            }
            if (goRight == true && Canvas.GetLeft(snowman) + (snowman.Width * 2) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) + 5);
            }
        }

        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Game.Snowman.startMove(sender, e);
            if (e.Key == Key.Left) goLeft = true;
            if (e.Key == Key.Right) goRight = true;
        }

        public void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Game.Snowman.endMove(sender, e);
            if (e.Key == Key.Left) goLeft = false;
            if (e.Key == Key.Right) goRight = false;
        }
    }
}
