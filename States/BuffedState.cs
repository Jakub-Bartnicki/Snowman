using System;
using System.Timers;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace Snowman.States
{
    sealed class BuffedState : State
    {
        private static Timer aTimer = new Timer();

        public BuffedState()
        {
            aTimer.Enabled = false;
            blockTime();
        }

        // Block snowman not working if snowman is buffed
        public override void block() {}

        // Refresh snowman buff time
        public override void buff()
        {
            aTimer.Enabled = false;
            blockTime();
        }
        
        // Set snowman to normal state
        public override void normalize()
        {
            this.Snowman.Img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowman.png"));
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new NormalState());
        }

        // Timer to buff the snowman for a while
        public void blockTime()
        {
            aTimer.Interval = 4000;

            aTimer.Elapsed += OnTimedEvent;

            aTimer.AutoReset = true;

            aTimer.Enabled = true;
        }

        // Turn off snowman buff method called from blockTime() after set time
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Application.Current.Dispatcher.Invoke(normalize, DispatcherPriority.ContextIdle);
        }
    }
}
