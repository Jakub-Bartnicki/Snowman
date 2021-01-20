using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Snowball : RainDrop
    {
        public Snowball()
        {
            this.Health = 10;
            this.Points = 10;
        }
    }
}
