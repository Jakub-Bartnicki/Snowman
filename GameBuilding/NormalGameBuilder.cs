using Snowman.GameBuilding;
using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameLevel
{
    public class NormalGameBuilder : IGameBuilder
    {
        private NormalGame normalGame = new NormalGame();

        public NormalGameBuilder()
        {
            this.reset();
        }

        public void reset()
        {
            this.normalGame = new NormalGame();
        }

        public void setDifficultyEasy()
        {
            this.normalGame.Difficulty = 0;
        }

        public void setDifficultyHard()
        {
            this.normalGame.Difficulty = 2;
        }

        public void setDifficultyNormal()
        {
            this.normalGame.Difficulty = 1;
        }

        public void setGamemodeOff()
        {
            this.normalGame.Buffs = false;
        }

        public void setGamemodeOn()
        {
            this.normalGame.Buffs = true;
        }

        public Game GetGame()
        {
            NormalGame result = this.normalGame;

            this.reset();

            return result;
        }
    }
}
