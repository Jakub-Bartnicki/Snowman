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
            App.game.RainDropList.Add(snowball);
            return snowball;
        }

        public override RainDrop CreateOffensiveRainDrop()
        {
            Meteorite meteorite = new Meteorite();
            App.game.RainDropList.Add(meteorite);
            return meteorite;
        }

        public override RainDrop CreatePositiveRainDrop()
        {
            Star star = new Star();
            App.game.RainDropList.Add(star);
            return star;
        }
    }
}
