using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Snowball : RainDrop
    {
        public Snowball(BitmapImage image) : base(image)
        {
            this.Health = 10;
            this.Points = 10;
            this.Effect = "neutral";
        }
    }
}
