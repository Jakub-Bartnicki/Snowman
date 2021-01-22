using Snowman.Snowman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.States
{
    sealed class NormalState : State
    {
        // Set snowman to blocked state
        public override void block()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman_blocked.png"));
            this.Snowman.Moveable = false;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new LockedState());
        }

        // Set snowman to buffed state
        public override void buff()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman_buffed.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = true;
            this.Snowman.TransitionTo(new BuffedState());
        }

        // Set snowman to normal state
        public override void normalize()
        {
            // already normal
        }
    }
}
