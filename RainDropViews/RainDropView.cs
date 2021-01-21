using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropViews
{
    public class RainDropView
    {
        private Type rainDropType;
        private BitmapImage image;
        public BitmapImage Image { 
            get { return image; } 
            set { image = value; } 
        }
        public Type RainDropType { get; set; }

        public RainDropView(Type rainDropType, BitmapImage image)
        {
            this.rainDropType = rainDropType;
            this.image = image;
        }
    }
}
