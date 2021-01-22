using Snowman.Snowman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Snowman.States
{
    sealed class LockedState : State
    {
        private static Timer aTimer = new System.Timers.Timer();

        public LockedState()
        {
            blockTime();
        }
        public override void block()
        {
            aTimer.Enabled = false;
            blockTime();
            // already locked, refresh lock time
        }

        public override void buff()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman_buffed.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = true;
            this.Snowman.TransitionTo(new BuffedState());
        }

        public override void normalize()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new NormalState());
        }

        public void blockTime()
        {
            aTimer.Interval = 3000;

            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Application.Current.Dispatcher.Invoke(normalize, DispatcherPriority.ContextIdle);
        }
    }
}
