using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Snowball : RainDrop
    {
        int health = 10;
        int points = 10;

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
