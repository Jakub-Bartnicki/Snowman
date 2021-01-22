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
        private static Dictionary<Rectangle, RainDrop> map;
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private bool goLeft, goRight;
        private List<Rectangle> itemRemover= new List<Rectangle>();

        private Random rand = new Random();

        private int draw;

        private int rainDropCounter = 0;
        private int playerSpeed = 10;
        private int points = 0;
        private int rainDropSpeed = 10;
        private int rainDropSpawnFrequency;

        ImageBrush playerImage = new ImageBrush();
        Rect playerHitBox;

        public GamePage()
        {
            InitializeComponent();

            map = new Dictionary<Rectangle, RainDrop>();

            Application.Current.MainWindow.KeyDown += new KeyEventHandler(KeyIsDown);
            Application.Current.MainWindow.KeyUp += new KeyEventHandler(KeyIsUp);

            gameTimer.Interval = TimeSpan.FromMilliseconds(6);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            gameScreen.Focus();

            playerImage.ImageSource = App.game.Snowman.Img;
            snowman.Fill = playerImage;


            if (App.game.Difficulty == 0) // easy difficulty
            {
                rainDropSpawnFrequency = 30;
            } else if (App.game.Difficulty == 1) // normal difficulty
            {
                rainDropSpawnFrequency = 20;
            } else // hard difficulty
            {
                rainDropSpawnFrequency = 10;
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerImage.ImageSource = App.game.Snowman.Img;
            snowman.Fill = playerImage;

            playerHitBox = new Rect(Canvas.GetLeft(snowman), Canvas.GetTop(snowman), snowman.Width, snowman.Height);

            rainDropCounter -= 1;

            showPoints.Content = "Points: " + points;
            showHealth.Content = "Health: " + App.game.Snowman.Health;

            if(App.game.Snowman.Health == 0)
            {
                EndGame();
                return;
            }

            if (rainDropCounter <= 0)
            {
                draw = rand.Next(1, 101);
                if (draw >=1 && draw < 40)
                {
                    MakeRainDrop("NeutralRainDrop");
                }
                else if (draw >= 40 && draw < 60)
                {
                    MakeRainDrop("PositiveRainDrop");
                } else
                {
                    MakeRainDrop("OffensiveRainDrop");
                }
                rainDropCounter = rainDropSpawnFrequency;
            }

            if (App.game.Snowman.Moveable)
            {
                if (goLeft == true && Canvas.GetLeft(snowman) > 0)
                {
                    Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) - playerSpeed);
                }
                if (goRight == true && Canvas.GetLeft(snowman) + 90 < Application.Current.MainWindow.Width)
                {
                    Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) + playerSpeed);
                }
            }


            foreach (var rect in map)
            {
                Canvas.SetTop(rect.Key, Canvas.GetTop(rect.Key) + rainDropSpeed);

                if (Canvas.GetTop(rect.Key) > 650)
                {
                    itemRemover.Add(rect.Key);
                }
                else
                {
                    Rect rainDropHitBox = new Rect(Canvas.GetLeft(rect.Key), Canvas.GetTop(rect.Key), rect.Key.Width, rect.Key.Height);

                    if (playerHitBox.IntersectsWith(rainDropHitBox))
                    {
                        itemRemover.Add(rect.Key);
                        points += rect.Value.Points;
                        App.game.Snowman.Health += rect.Value.Health;
                        if (rect.Value.Effect.Equals("buffed"))
                            App.game.Snowman.buffSnowman();
                        else if (rect.Value.Effect.Equals("blocked"))
                            App.game.Snowman.blockSnowman();
                    }
                }
            }

            foreach (Rectangle i in itemRemover)
            {
                gameScreen.Children.Remove(i);
                map.Remove(i);
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

        private void MakeRainDrop(string rainDropType)
        {
            RainDrop rainDrop;
            if (rainDropType == "NeutralRainDrop")
            {
                rainDrop = App.game.CreateNeutralRainDrop();
            } else if (rainDropType.Equals("OffensiveRainDrop"))
            {
                rainDrop = App.game.CreateOffensiveRainDrop();
            } else if (rainDropType.Equals("PositiveRainDrop"))
            {
                rainDrop = App.game.CreatePositiveRainDrop();
            } else
            {
                return;
            }

            ImageBrush rainDropSprite = new ImageBrush();
            rainDropSprite.ImageSource = rainDrop.RainDropView.Image;
            
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

            map.Add(newRainDrop, rainDrop);
        }

        private void EndGame()
        {
            endGameText.Content = "Your score: ";
            endGamePoints.Content = points;
            backButton.Content = "BACK";
            backButton.Width = 200;
            backButton.Height = 30;
            gameTimer.Tick -= GameLoop;
            backButton.Click += backButton_Click;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }
    }
}
