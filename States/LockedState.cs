using System;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Snowman.States
{
    sealed class LockedState : State
    {
        private static Timer aTimer = new Timer();

        public LockedState()
        {
            blockTime();
        }

        // Refresh snowman block time
        public override void block()
        {
            aTimer.Enabled = false;
            blockTime();
        }

        // Set snowman to buffed state
        public override void buff()
        {
            aTimer.Enabled = false;
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman_buffed.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = true;
            this.Snowman.TransitionTo(new BuffedState());
        }

        // Set snowman to normal state
        public override void normalize()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new NormalState());
        }

        // Timer to block the snowman for a while
        public void blockTime()
        {
            aTimer.Interval = 1000;

            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;
        }

        // Unblock snowman method called from blockTime() after set time
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Application.Current.Dispatcher.Invoke(normalize, DispatcherPriority.ContextIdle);
        }
    }
}
