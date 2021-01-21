using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameBuilding
{
    public class NormalGame : Game
    {
        public override RainDrop CreateNeutralRainDrop()
        {
            return new Snowflake();
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            return new Icicle();
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            return new Star();
        }
    }
}
