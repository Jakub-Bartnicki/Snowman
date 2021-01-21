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
        public NormalGame() : base()
        {

        }

        public override RainDrop CreateNeutralRainDrop()
        {
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowflake.png"));
            Snowflake snowflake = new Snowflake(img);
            RainDropList.Add(snowflake);
            return snowflake;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/icicle.png"));
            Icicle icicle = new Icicle(img);
            RainDropList.Add(icicle);
            return icicle;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/star.png"));
            Star star = new Star(img);
            RainDropList.Add(star);
            return star;
        }
    }
}
