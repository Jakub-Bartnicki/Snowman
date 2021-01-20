using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Icicle : RainDrop
    {
        int health = -15;
        int points = 0;

        public override int ChangeHealth()
        {
            return health;
        }

        public override int ChangePoints()
        {
            return points;
        }
    }
}
