using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.RainDropFactory
{
    class Star : RainDrop
    {
        String effect = "buffed";

        public Star()
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/star.png"));
            this.Health = 0;
            this.Points = 30;
        }

        public String AddEffect()
        {
            return effect;
        }
    }
}
