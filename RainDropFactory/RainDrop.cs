﻿using Snowman.Interfaces;
using Snowman.RainDropViews;
using System;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    abstract public class RainDrop : IRainDrop
    {
        public RainDropView RainDropView { get; set; }
        public int Health { get; set; }
        public int Points { get; set; }
        public String Effect { get; set; }

        public RainDrop(BitmapImage image)
        {
            this.RainDropView = RainDropViewFactory.getRainDropView(image);
        }
    }
}
