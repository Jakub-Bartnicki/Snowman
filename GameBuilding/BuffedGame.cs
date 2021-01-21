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
            Snowball snowball = new Snowball();
            RainDropList.Add(snowball);
            return snowball;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            Meteorite meteorite = new Meteorite();
            RainDropList.Add(meteorite);
            return meteorite;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            Star star = new Star();
            RainDropList.Add(star);
            return star;
        }
    }
}
