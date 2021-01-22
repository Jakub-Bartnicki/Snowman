using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropViews
{
    public class RainDropView
    {
        private BitmapImage image;
        public BitmapImage Image { 
            get { return image; } 
            set { image = value; } 
        }

        public RainDropView(BitmapImage image)
        {
            this.image = image;
        }
    }
}
