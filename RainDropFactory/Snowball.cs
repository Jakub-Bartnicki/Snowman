using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Snowball : RainDrop
    {
        public Snowball(BitmapImage image) : base(image)
        {
            this.health = 10;
            this.points = 10;
            this.effect = "neutral";
        }
    }
}
