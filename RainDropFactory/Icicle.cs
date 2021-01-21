using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.RainDropFactory
{
    class Icicle : RainDrop
    {
        public Icicle(BitmapImage image) : base(image)
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/icicle.png"));
            this.Health = -15;
            this.Points = 0;
        }
    }
}
