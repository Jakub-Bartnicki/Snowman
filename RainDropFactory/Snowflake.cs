using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Snowflake : RainDrop
    {
        int health = 2;
        int points = 2;

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
