using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Icicle : RainDrop
    {
        public Icicle(BitmapImage image) : base(image)
        {
            this.Health = -15;
            this.Points = 0;
            this.Effect = "blocked";
        }
    }
}
