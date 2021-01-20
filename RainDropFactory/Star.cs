﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Star : RainDrop
    {
        String effect = "buffed";

        public Star()
        {
            this.Health = 0;
            this.Points = 30;
        }

        public String AddEffect()
        {
            return effect;
        }
    }
}
