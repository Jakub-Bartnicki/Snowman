using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Snowball : RainDrop
    {
        public Snowball(BitmapImage image) : base(image)
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowball.png"));
            this.Health = 10;
            this.Points = 10;
        }
    }
}
