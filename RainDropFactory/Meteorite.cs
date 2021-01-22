using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Meteorite : RainDrop
    {
        public Meteorite(BitmapImage image) : base(image)
        {
            this.Health = -30;
            this.Points = -10;
            this.Effect = "blocked";
        }

    }
}
