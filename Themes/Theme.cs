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
        public bool LightTheme;
        public bool DarkTheme;

        private Theme()
        {
            LightTheme = false;
            DarkTheme = true;
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
            if (DarkTheme)
            {
                LightTheme = LightTheme != true;
                DarkTheme = DarkTheme != true;
                displayBackground();
            }
        }
        
        public void setDarkTheme()
        { 
            if (LightTheme)
            {
                LightTheme = LightTheme != true;
                DarkTheme = DarkTheme != true;
                displayBackground();
            }
        }

        public void displayBackground()
        {
            if (LightTheme)
                Application.Current.MainWindow.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/day.jpg")));
            else
                Application.Current.MainWindow.Background = new ImageBrush(new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/night.jpg")));
        }
    }
}
