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
    sealed class BuffedState : State
    {
        private static Timer aTimer = new System.Timers.Timer();

        public BuffedState()
        {
            blockTime();
        }

        public override void block()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman_blocked.png"));
            this.Snowman.Moveable = false;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new LockedState());
        }

        public override void buff()
        {
            aTimer.Enabled = false;
            blockTime();
            // already locked, refresh lock time
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
