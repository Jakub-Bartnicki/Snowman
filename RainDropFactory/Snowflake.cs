using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.RainDropFactory
{
    class Snowflake : RainDrop
    {
        public Snowflake()
        {
            ImageSrc = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowflake.png"));
            this.Health = 2;
            this.Points = 2;
        }
    }
}
