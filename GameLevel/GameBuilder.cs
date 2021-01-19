using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameLevel
{
    public class GameBuilder : IGameBuilder
    {
        private GameLvl gameLvl = new GameLvl();

        public GameBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.gameLvl = new GameLvl();
        }

        public void setDifficultyEasy()
        {
            this.gameLvl.Difficulty = 0;
            Console.WriteLine("ez");
        }

        public void setDifficultyHard()
        {
            this.gameLvl.Difficulty = 2;
        }

        public void setDifficultyNormal()
        {
            this.gameLvl.Difficulty = 1;
        }

        public void setGamemodeOff()
        {
            this.gameLvl.Gamemode = false;
        }

        public void setGamemodeOn()
        {
            this.gameLvl.Gamemode = true;
            Console.WriteLine("hehe");
        }

        public GameLvl GetGameLvl()
        {
            GameLvl result = this.gameLvl;

            this.reset();

            return result;
        }
    }
}
