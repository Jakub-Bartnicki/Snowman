using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    abstract class RainDrop : Interfaces.IRainDrop
    {
        abstract public int ChangePoints();
        abstract public int ChangeHealth();
    }
}
