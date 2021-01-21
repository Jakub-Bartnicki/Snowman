using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.Themes
{
    public class DarkTheme : Theme
    {
        private DarkTheme() {
            Application.Current.MainWindow.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/day.jpg")));
        }

        public override Theme getInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new DarkTheme();
                    }
                }
            }
            return instance;
        }
    }
}
