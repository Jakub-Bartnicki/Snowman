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
            rainDropList.Add(snowball);
            return snowball;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            Meteorite meteorite = new Meteorite();
            rainDropList.Add(meteorite);
            return meteorite;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            Star star = new Star();
            rainDropList.Add(star);
            return star;
        }
    }
}
