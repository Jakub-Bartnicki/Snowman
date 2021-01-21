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
            Snowflake snowflake = new Snowflake();
            RainDropList.Add(snowflake);
            return snowflake;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            Icicle icicle = new Icicle();
            RainDropList.Add(icicle);
            return icicle;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            Star star = new Star();
            RainDropList.Add(star);
            return star;
        }
    }
}
