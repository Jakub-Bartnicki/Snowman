using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class NormalGame : Game
    {
        public override void FactoryMethod()
        {
            RainDropList.Add(new Snowflake());
            RainDropList.Add(new Snowball());
            RainDropList.Add(new Icicle());
        }
    }
}
