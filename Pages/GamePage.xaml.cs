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
using Snowman.RainDropFactory;
using System.Linq;

namespace Snowman.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private bool goLeft, goRight;
        List<Rectangle> itemRemover= new List<Rectangle>();

        Random rand = new Random();

        String gametype;

        int rainDropSpriteCounter = 0;
        int rainDropCounter = 0;
        int playerSpeed = 10;
        int limit = 50;
        int health = 0;
        int points = 0;
        int rainDropSpeed = 10;

        Rect playerHitBox;

        public GamePage()
        {
            InitializeComponent();

            gameScreen.Focus();

            Application.Current.MainWindow.KeyDown += new KeyEventHandler(KeyIsDown);
            Application.Current.MainWindow.KeyUp += new KeyEventHandler(KeyIsUp);

            gameTimer.Interval = TimeSpan.FromMilliseconds(6);
            
            gametype = App.game.GetType().ToString();

            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            gameScreen.Focus();

            ImageBrush neutralRainDrop = new ImageBrush();
            ImageBrush positiveRainDrop = new ImageBrush();
            ImageBrush offensiveRainDrop = new ImageBrush();

            ImageBrush playerImage = new ImageBrush();
            playerImage.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/snowman.png"));
            snowman.Fill = playerImage;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(snowman), Canvas.GetTop(snowman), snowman.Width, snowman.Height);

            rainDropCounter -= 1;

            showPoints.Content = "Points: " + points;
            showHealth.Content = "Health: " + health;

            if (rainDropCounter < 30)
            {
                MakeRainDrop();
                rainDropCounter = limit;
            }

            if (goLeft == true && Canvas.GetLeft(snowman) > 0)
            {
                Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) - playerSpeed);
            }
            if (goRight == true && Canvas.GetLeft(snowman) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) + playerSpeed);
            }

            foreach (var x in gameScreen.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "raindrop")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + rainDropSpeed);

                    if (Canvas.GetTop(x) > 650)
                    {
                        itemRemover.Add(x);
                    }
                    else
                    {
                        Rect rainDropHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);

                        if (playerHitBox.IntersectsWith(rainDropHitBox))
                        {
                            itemRemover.Add(x);
                            //Change health
                        }
                    }
                }
            }

            foreach (Rectangle i in itemRemover)
            {
                gameScreen.Children.Remove(i);
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

        private void MakeRainDrop()
        {
            ImageBrush rainDropSprite = new ImageBrush();

            if (gametype.Equals("Snowman.GameBuilding.NormalGame"))
            {
                rainDropSpriteCounter = rand.Next(1, 4);
            }
            else
            {
                rainDropSpriteCounter = rand.Next(4, 7);
            }

            switch (rainDropSpriteCounter)
            {
                case 1:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/snowflake.png"));
                    break;
                case 2:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/icicle.png"));
                    break;
                case 3:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/star.png"));
                    break;
                case 4:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/snowball.png"));
                    break;
                case 5:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/meteorite.png"));
                    break;
                case 6:
                    rainDropSprite.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "../Images/star.png"));
                    break;
            }

            Rectangle newRainDrop = new Rectangle
            {
                Tag = "raindrop",
                Height = 50,
                Width = 50,
                Fill = rainDropSprite
            };

            Canvas.SetTop(newRainDrop, -100);
            Canvas.SetLeft(newRainDrop, rand.Next(300, 900));
            gameScreen.Children.Add(newRainDrop);
        }
    }
}
