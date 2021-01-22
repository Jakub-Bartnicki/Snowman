using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.GameBuilding
{
    public class NormalGame : Game
    {
        public override RainDrop CreateNeutralRainDrop()
        {
            // snowflake image
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowflake.png"));
            Snowflake snowflake = new Snowflake(img);
            return snowflake;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            // icicle image
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/icicle.png"));
            Icicle icicle = new Icicle(img);
            return icicle;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            // star image
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/star.png"));
            Star star = new Star(img);
            return star;
        }
    }
}
