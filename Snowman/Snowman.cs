using Snowman.Pages;
using Snowman.States;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snowman.Snowman
{
    public class SnowMan
    {
        State state = null;
        private int health;
        private int x;
        private int y;
        private int movementSpeed;
        private bool moveable;
        private bool buffed;
        public bool goLeft, goRight, goUp, goDown;

        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0) health = 0;
                else health = value;
            }
        }

        public bool Moveable
        {
            get { return moveable; }
            set { moveable = value; }
        }

        public bool Buffed
        {
            get { return buffed; }
            set { buffed = value; }
        }

        public SnowMan(State state)
        {
            this.state = state;
            health = 100;
            moveable = true;
            buffed = false;
        }

        public void changeHealth(int amountOfHealth)
        {
            this.Health += amountOfHealth;
        }

        private void remove()
        {
            
        }

        public void move(object sender, EventArgs e, Image snowman)
        {
            if (goLeft && Canvas.GetLeft(snowman) > 5)
            { 
                Canvas.SetLeft(snowman, Canvas.GetLeft(snowman) - movementSpeed);
            }
        }

        public void startMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) goLeft = true;
            else if (e.Key == Key.Right) goRight = true;
            else if (e.Key == Key.Down) goDown = true;
            else if (e.Key == Key.Up) goUp = true;
        }

        public void endMove(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) goLeft = false;
            else if (e.Key == Key.Right) goRight = false;
            else if (e.Key == Key.Down) goDown = false;
            else if (e.Key == Key.Up) goUp = false;
        }

        public void TransitionTo(State state)
        {
            this.state = state;
            this.state.setSnowman(this);
        }

        public void blockSnowman() 
        {
            this.state.block();
        }
        
        public void normalizeSnowman() 
        {
            this.state.normalize();
        }

        public void buffSnowman() 
        {
            this.state.buff();
        }
    }
}
