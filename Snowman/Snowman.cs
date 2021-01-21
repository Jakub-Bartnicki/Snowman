﻿using Snowman.Pages;
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
        private bool moveable;
        private bool buffed;

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0) health = 0;
                else if (value > 100) health = 100;
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
