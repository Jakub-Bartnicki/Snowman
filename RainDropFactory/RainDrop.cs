using Snowman.Interfaces;
using Snowman.RainDropViews;
using System;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    abstract public class RainDrop : IRainDrop
    {
        protected RainDropView rainDropView;
        protected int health;
        protected int points;
        protected string effect;
        public RainDropView RainDropView 
        {
            get { return rainDropView; }
        }
        public int Health 
        { 
            get { return health; }
        }
        public int Points
        {
            get { return points; }
        }
        public String Effect
        {
            get { return effect; }
        }

        public RainDrop(BitmapImage image)
        {
            this.rainDropView = RainDropViewFactory.getRainDropView(image);
        }
    }
}
