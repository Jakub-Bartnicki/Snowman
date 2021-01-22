using System;

namespace Snowman.Interfaces
{
    public interface IRainDrop
    {
        public int Health { get; }
        public int Points { get; }
        // Snowman state after contact
        public string Effect { get; }
    }
}
