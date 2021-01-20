using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    abstract public class RainDrop : Interfaces.IRainDrop
    {
        public int Health { get; set; }
        public int Points { get; set; }
    }
}
