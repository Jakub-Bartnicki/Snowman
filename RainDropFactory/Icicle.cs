using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class Icicle : RainDrop
    {
        public Icicle()
        {
            this.Health = -15;
            this.Points = 0;
        }
    }
}
