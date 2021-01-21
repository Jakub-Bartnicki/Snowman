using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Meteorite : RainDrop
    {
        String effect = "blocked";

        public Meteorite(BitmapImage image) : base(image)
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/meteorite.png"));
            this.Health = -30;
            this.Points = -10;
        }

        public String AddEffect()
        {
            return effect;
        }
    }
}
