using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.RainDropFactory
{
    class Snowball : RainDrop
    {
        public Snowball()
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowball.png"));
            this.Health = 10;
            this.Points = 10;
        }
    }
}
