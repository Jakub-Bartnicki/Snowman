using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace Snowman.RainDropViews
{
    public class RainDropViewFactory
    {
        private static List<RainDropView> rainDropViews = new List<RainDropView>();

        public static RainDropView getRainDropView(BitmapImage image)
        {
            RainDropView rainDropView;
            foreach (RainDropView view in rainDropViews)
            {
                if (view.Image.ToString() == image.ToString())
                {
                    rainDropView = view;
                    return rainDropView;
                }
            }
            rainDropView = new RainDropView(image);

            rainDropViews.Add(rainDropView);

            return rainDropView;
        }
    }
}
