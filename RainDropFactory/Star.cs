using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Star : RainDrop
    {
        String effect = "buffed";

        public Star(BitmapImage image) : base(image)
        {
            this.Health = 0;
            this.Points = 30;
        }

        public String AddEffect()
        {
            return effect;
        }
    }
}
