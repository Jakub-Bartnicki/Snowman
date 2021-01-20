﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Star : RainDrop
    {
        int health = 0;
        int points = 30;

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
            return "buffed";
        }
    }
}
