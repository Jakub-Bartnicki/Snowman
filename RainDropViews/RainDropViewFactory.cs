using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropViews
{
    public class RainDropViewFactory
    {
        private static HashSet<RainDropView> rainDropViews = new HashSet<RainDropView>();

        public static RainDropView getRainDropView(RainDrop rainDrop, BitmapImage image)
        {  
            RainDropView rainDropView = new RainDropView(rainDrop.GetType(), image);

            rainDropViews.Add(rainDropView);

            return rainDropView;
        }
    }
}
