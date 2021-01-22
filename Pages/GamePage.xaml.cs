﻿using System;
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

            gameTimer.Interval = TimeSpan.FromMilliseconds(6);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            gameScreen.Focus();

            playerImage.ImageSource = App.Game.Snowman.Img;
            snowman.Fill = playerImage;


            if (App.Game.Difficulty == 0) // easy difficulty
            {
                rainDropSpawnFrequency = 20;
            } else if (App.Game.Difficulty == 1) // normal difficulty
            {
                rainDropSpawnFrequency = 10;
            } else // hard difficulty
            {
                rainDropSpawnFrequency = 5;
            }
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerImage.ImageSource = App.Game.Snowman.Img;
            snowman.Fill = playerImage;

            playerHitBox = new Rect(Canvas.GetLeft(snowman), Canvas.GetTop(snowman), snowman.Width, snowman.Height);

            rainDropCounter -= 1;

            showPoints.Content = "Points: " + points;
            showHealth.Content = "Health: " + App.Game.Snowman.Health;

            if(App.Game.Snowman.Health == 0)
            {
                EndGame();
                return;
            }

            if (rainDropCounter <= 0)
            {
                draw = rand.Next(1, 101);
                if (draw >=1 && draw < 50)
                {
                    MakeRainDrop("NeutralRainDrop");
                }
                else if (draw >= 50 && draw < 55)
                {
                    MakeRainDrop("PositiveRainDrop");
                } else
                {
                    MakeRainDrop("OffensiveRainDrop");
                }
                rainDropCounter = rainDropSpawnFrequency;
            }

            if (App.Game.Snowman.Moveable)
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
                        SnowmanReaction(rect.Value.Health, rect.Value.Points, rect.Value.Effect);
                    }
                }
            }

            foreach (Rectangle i in itemRemover)
            {
                gameScreen.Children.Remove(i);
                map.Remove(i);
            }

        }

        // Checking what type of game we play
        private void SnowmanReaction(int health, int points, String effect)
        {
            if (App.Game.Buffs)
            {
                if (effect.Equals("buffed"))
                    App.Game.Snowman.buffSnowman();
                else if (effect.Equals("blocked"))
                    App.Game.Snowman.blockSnowman();

                SetSnowmanAttributes(health, points, effect);

            } else //If it is normal game set health and points
            {
                App.Game.Snowman.Health += health;
                this.points += points;
            }
        }

        // Changing health and points in Buffed Game
        private void SetSnowmanAttributes(int health, int points, String effect)
        {
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
            else
            {
                App.Game.Snowman.Health += health;
                this.points += points;
            }

        }

        // Method called when player press button
        public void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Game.Snowman.startMove(sender, e);
            if (e.Key == Key.Left) goLeft = true;
            if (e.Key == Key.Right) goRight = true;
        }

        // Method called when player release button
        public void KeyIsUp(object sender, KeyEventArgs e)
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
            Canvas.SetLeft(newRainDrop, rand.Next(100, 1100));
            gameScreen.Children.Add(newRainDrop);

            map.Add(newRainDrop, rainDrop);
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
