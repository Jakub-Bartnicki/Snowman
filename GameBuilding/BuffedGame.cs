using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Snowman.GameBuilding
{
    public class BuffedGame : Game
    {
        public override RainDrop CreateNeutralRainDrop()
        {
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/snowball.png"));
            Snowball snowball = new Snowball(img);
            RainDropList.Add(snowball);
            return snowball;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            BitmapImage img = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(Application.Current.MainWindow), "../Images/meteorite.png"));
            Meteorite meteorite = new Meteorite(img);
            RainDropList.Add(meteorite);
            return meteorite;
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
