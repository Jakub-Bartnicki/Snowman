using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Meteorite : RainDrop
    {
        public Meteorite(BitmapImage image) : base(image)
        {
            this.health = -30;
            this.points = -10;
            this.effect = "blocked";
        }

    }
}
