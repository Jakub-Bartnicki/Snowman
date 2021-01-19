using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameLevel
{
    public class GameLvl
    {
        private bool gamemode;
        private int difficulty;

        public bool Gamemode
        {
            get
            {
                return gamemode;
            }
            set
            {
                gamemode = value;
            }
        }
        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                if (value >= 0 && value <= 2)
                {
                    difficulty = value;
                }
                else
                {
                    throw new Exception("rainDropRatio should be between 0 and 2");
                }
            }
        }


    }
}
