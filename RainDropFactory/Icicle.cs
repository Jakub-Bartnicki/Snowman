using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Icicle : RainDrop
    {
        public Icicle(BitmapImage image) : base(image)
        {
            this.health = -15;
            this.points = 0;
            this.effect = "blocked";
        }
    }
}
