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

        public override RainDrop DrawRainDrop()
        {
            RainDrop rainDrop = null;
            var rand = new Random();
            int number = rand.Next(1, 101);
            if (number >= 0 && number < 40)
            {
                rainDrop = rainDropList[0];
            }
            else if (number >= 40 && number < 60)
            {
                rainDrop = rainDropList[1];
            }
            else
            {
                rainDrop = rainDropList[2];
            }

            return rainDrop;
        }
    }
}
