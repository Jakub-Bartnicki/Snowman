using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Star : RainDrop
    {
        public Star(BitmapImage image) : base(image)
        {
            this.Health = 0;
            this.Points = 30;
            this.Effect = "buffed";
        }
    }
}
