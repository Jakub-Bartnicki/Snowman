using Snowman.States;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.Snowman
{
    public class SnowMan
    {
        private BitmapImage img;
        private State state = null;
        private int health;
        private bool moveable;
        private bool buffed;


        public BitmapImage Img
        {
            get { return img; }
            set { img = value; }
        }
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
            state.setSnowman(this);
            this.state = state;
            img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman.png"));
            health = 100;
            moveable = true;
            buffed = false;
        }

        public void changeHealth(int amountOfHealth)
        {
            this.Health += amountOfHealth;
        }

        // Setting the state of snowman
        public void TransitionTo(State state)
        {
            this.state = state;
            this.state.setSnowman(this);
        }

        // Changing snowman to blocked state
        public void blockSnowman() 
        {
            this.state.block();
        }

        // Changing snowman to normal state
        public void normalizeSnowman() 
        {
            this.state.normalize();
        }

        // Changing snowman to buffed state
        public void buffSnowman()
        {
            this.state.buff();
        }
    }
}
