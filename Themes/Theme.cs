using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.Themes
{
    public class Theme
    {
        private static Theme instance;
        protected static readonly object _lock = new object();
        private bool lightTheme;
        private bool darkTheme;

        private Theme()
        {
            lightTheme = false;
            darkTheme = true;
        }

        public static Theme getInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new Theme();
                    }
                }
            }
            return instance;
        }

        public void setLightTheme()
        { 
            if (darkTheme)
            {
                lightTheme = lightTheme != true;
                darkTheme = darkTheme != true;
                displayBackground();
            }
        }
        
        public void setDarkTheme()
        { 
            if (lightTheme)
            {
                lightTheme = lightTheme != true;
                darkTheme = darkTheme != true;
                displayBackground();
            }
        }

        public void displayBackground()
        {
            if (lightTheme)
                Application.Current.MainWindow.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/day.jpg")));
            else
                Application.Current.MainWindow.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/night.jpg")));
        }
    }
}
