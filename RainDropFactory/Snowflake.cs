using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    class Snowflake : RainDrop
    {
        public Snowflake(BitmapImage image) : base(image)
        {
            this.Health = 5;
            this.Points = 5;
            this.Effect = "neutral";
        }
    }
}
