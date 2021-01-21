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
            rainDropList.Add(snowflake);
            return snowflake;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            Icicle icicle = new Icicle();
            rainDropList.Add(icicle);
            return icicle;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            Star star = new Star();
            rainDropList.Add(star);
            return star;
        }
    }
}
