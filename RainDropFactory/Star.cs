using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Star : RainDrop
    {
        public Star(BitmapImage image) : base(image)
        {
            this.health = 0;
            this.points = 30;
            this.effect = "buffed";
        }
    }
}
