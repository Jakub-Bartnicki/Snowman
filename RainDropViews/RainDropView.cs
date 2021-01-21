using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropViews
{
    public class RainDropView
    {
        private RainDrop rainDrop;
        private BitmapImage image;
        public BitmapImage Image { 
            get { return image; } 
            set { image = value; } 
        }

        public RainDropView(RainDrop rainDrop, BitmapImage image)
        {
            this.rainDrop = rainDrop;
            this.image = image;
        }
    }
}
