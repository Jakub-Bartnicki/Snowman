using System;

namespace Snowman.Interfaces
{
    interface IRainDrop
    {
        public int Health { get; set; }
        public int Points { get; set; }
        public String Effect { get; set; }
    }
}
