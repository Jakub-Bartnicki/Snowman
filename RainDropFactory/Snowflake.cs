using System.Windows.Media.Imaging;

namespace Snowman.RainDropFactory
{
    public class Snowflake : RainDrop
    {
        public Snowflake(BitmapImage image) : base(image)
        {
            this.health = 5;
            this.points = 5;
            this.effect = "neutral";
        }
    }
}
