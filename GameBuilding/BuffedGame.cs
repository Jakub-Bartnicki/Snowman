using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameBuilding
{
    public class BuffedGame : Game
    {
        public override RainDrop CreateNeutralRainDrop()
        {
            return new Snowball();
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            return new Meteorite();
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            return new Star();
        }
    }
}
