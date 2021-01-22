using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Snowman.RainDropFactory;

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

            // Set interval GameLoop
            gameTimer.Interval = TimeSpan.FromMilliseconds(6);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            gameScreen.Focus();

            // Set starting snowman image
            playerImage.ImageSource = App.Game.Snowman.Img;
            snowman.Fill = playerImage;

            // Set game difficulty (item spawn rate)
            if (App.Game.Difficulty == 0)
            {
                rainDropSpawnFrequency = 20;        // easy difficulty
            } 
            else if (App.Game.Difficulty == 1)
            {
                rainDropSpawnFrequency = 10;        // normal difficulty
            } 
            else
            {
                rainDropSpawnFrequency = 5;         // hard difficulty
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Set snowman image
            playerImage.ImageSource = App.Game.Snowman.Img;
            snowman.Fill = playerImage;

            // Set current snowman position
            playerHitBox = new Rect(Canvas.GetLeft(snowman), Canvas.GetTop(snowman), snowman.Width, snowman.Height);

            rainDropCounter -= 1;

            // Put health and points values on screen
            showPoints.Content = "Points: " + points;
            showHealth.Content = "Health: " + App.Game.Snowman.Health;

            // End game if snowman have no health
            if (App.Game.Snowman.Health == 0)
            {
                EndGame();
                return;
            }

            // Adding item after rainDropSpawnFrequency ticks
            if (rainDropCounter <= 0)
            {
                AddItem();
            }

            // Check if snowman can move
            if (App.Game.Snowman.Moveable)
            {
                MoveSnowman();
            }

            SelectItemToDelete();
            DeleteItems();

        }

        // Check if snowman can move
        private void MoveSnowman()
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

        // Add falling item depending on the difficulty level
        private void AddItem()
        {
            draw = rand.Next(1, 101);
            if (draw >= 1 && draw < 50)
            {
                MakeRainDrop("NeutralRainDrop");
            }
            else if (draw >= 50 && draw < 55)
            {
                MakeRainDrop("PositiveRainDrop");
            }
            else
            {
                MakeRainDrop("OffensiveRainDrop");
            }
            rainDropCounter = rainDropSpawnFrequency;
        }

        // Select falling items to delete
        private void SelectItemToDelete()
        {
            foreach (var rect in map)
            {
                Canvas.SetTop(rect.Key, Canvas.GetTop(rect.Key) + rainDropSpeed);

                // Item fell outside the play area
                if (Canvas.GetTop(rect.Key) > 650)
                {
                    itemRemover.Add(rect.Key);
                }
                else
                {
                    // Set current item position
                    Rect rainDropHitBox = new Rect(Canvas.GetLeft(rect.Key), Canvas.GetTop(rect.Key), rect.Key.Width, rect.Key.Height);

                    // Snowman interaction with item
                    if (playerHitBox.IntersectsWith(rainDropHitBox))
                    {
                        itemRemover.Add(rect.Key);
                        SnowmanReaction(rect.Value.Health, rect.Value.Points, rect.Value.Effect);
                    }
                }
            }
        }

        // Deleting falling items
        private void DeleteItems()
        {
            foreach (Rectangle i in itemRemover)
            {
                gameScreen.Children.Remove(i);
                map.Remove(i);
            }
        }


        // Snowman interaction with items
        private void SnowmanReaction(int health, int points, string effect)
        {
            // Buffed game interaction
            if (App.Game.Buffs)
            {
                if (effect.Equals("buffed"))
                    App.Game.Snowman.buffSnowman();
                else if (effect.Equals("blocked"))
                    App.Game.Snowman.blockSnowman();

                SetSnowmanAttributes(health, points, effect);

            }
            else // Normal game interaction
            {
                App.Game.Snowman.Health += health;
                this.points += points;
            }
        }

        // Changing health and points in buffed game
        private void SetSnowmanAttributes(int health, int points, String effect)
        {
            // Buffed snowman interaction with items
            if (App.Game.Snowman.Buffed)
            {
                if (effect.Equals("buffed"))
                {
                    App.Game.Snowman.Health += health;
                    this.points += points;
                }
                else if (effect.Equals("blocked"))
                {

                }
                else
                {
                    App.Game.Snowman.Health += health;
                    this.points += points;
                }
            }
            // Other snowman interactions with items
            else
            {
                App.Game.Snowman.Health += health;
                this.points += points;
            }

        }

        // Method called when player press button
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Game.Snowman.startMove(sender, e);
            if (e.Key == Key.Left) goLeft = true;
            if (e.Key == Key.Right) goRight = true;
        }

        // Method called when player release button
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) goLeft = false;
            if (e.Key == Key.Right) goRight = false;
        }

        // Making falling objects
        private void MakeRainDrop(string rainDropType)
        {
            RainDrop rainDrop;
            if (rainDropType == "NeutralRainDrop")
            {
                rainDrop = App.Game.CreateNeutralRainDrop();
            } else if (rainDropType.Equals("OffensiveRainDrop"))
            {
                rainDrop = App.Game.CreateOffensiveRainDrop();
            } else if (rainDropType.Equals("PositiveRainDrop"))
            {
                rainDrop = App.Game.CreatePositiveRainDrop();
            } else
            {
                return;
            }

            // Selecting new item image
            ImageBrush rainDropSprite = new ImageBrush();
            rainDropSprite.ImageSource = rainDrop.RainDropView.Image;

            // Creating new rectangle to put item on screen
            Rectangle rainDropRectangle = new Rectangle
            {
                Tag = "raindrop",
                Height = 50,
                Width = 50,
                Fill = rainDropSprite
            };

            // Draw starting position of created item
            Canvas.SetTop(rainDropRectangle, -100);
            Canvas.SetLeft(rainDropRectangle, rand.Next(100, 1100));
            gameScreen.Children.Add(rainDropRectangle);

            // Saving rectangle with concrete item
            map.Add(rainDropRectangle, rainDrop);
        }

        // Method showing score and back to menu button after the game
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

        // Navigation to menu after clicking back button
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MenuPage());
        }
    }
}
