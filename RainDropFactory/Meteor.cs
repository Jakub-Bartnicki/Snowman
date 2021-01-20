using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Meteor : RainDrop
    {
        int health = -30;
        int points = -10;

        public override int ChangeHealth()
        {
            return health;
        }

        public override int ChangePoints()
        {
            return points;
        }

        public String AddEffect()
        {
            return "blocked";
        }
    }
}
