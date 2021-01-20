using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.RainDropFactory
{
    class BuffedGame : Game
    {
        public override void FactoryMethod()
        {
            RainDropList.Add(new Snowflake());
            RainDropList.Add(new Snowball());
            RainDropList.Add(new Icicle());
            RainDropList.Add(new Star());
            RainDropList.Add(new Meteorite());
        }

        public override RainDrop DrawRainDrop()
        {
            RainDrop rainDrop = null;
            var rand = new Random();
            int number = rand.Next(1, 101);
            if (number >= 0 && number < 30)
            {
                rainDrop = rainDropList[0];
            }
            else if (number >= 30 && number < 50)
            {
                rainDrop = rainDropList[1];
            }
            else if (number >=50 && number < 70)
            {
                rainDrop = rainDropList[2];
            }
            else if (number >=70 && number < 85)
            {
                rainDrop = rainDropList[3];
            }
            else
            {
                rainDrop = rainDropList[4];
            }

            return rainDrop;
        }
    }
}
