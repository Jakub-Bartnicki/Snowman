using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Meteorite : RainDrop
    {
        public Meteorite(BitmapImage image) : base(image)
        {
            this.Health = -30;
            this.Points = -10;
            this.Effect = "blocked";
        }

    }
}
