using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Meteorite : RainDrop
    {
        String effect = "blocked";

        public Meteorite()
        {
            this.Health = -30;
            this.Points = -10;
        }

        public String AddEffect()
        {
            return effect;
        }
    }
}
