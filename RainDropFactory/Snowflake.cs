using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Snowflake : RainDrop
    {
        public Snowflake()
        {
            this.Health = 2;
            this.Points = 2;
        }
    }
}
