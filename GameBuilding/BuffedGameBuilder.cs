using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.GameBuilding
{
    class BuffedGameBuilder : IGameBuilder
    {
        private BuffedGame buffedGame = new BuffedGame();

        public BuffedGameBuilder()
        {
            this.reset();
        }

        // reset game
        public void reset()
        {
            this.buffedGame = new BuffedGame();
        }

        public void setDifficultyEasy()
        {
            this.buffedGame.Difficulty = 0;
        }

        public void setDifficultyHard()
        {
            this.buffedGame.Difficulty = 2;
        }

        public void setDifficultyNormal()
        {
            this.buffedGame.Difficulty = 1;
        }

        public void setGamemodeOff()
        {
            this.buffedGame.Buffs = false;
        }

        public void setGamemodeOn()
        {
            this.buffedGame.Buffs = true;
        }

        public Game GetGame()
        {
            BuffedGame result = this.buffedGame;

            this.reset();

            return result;
        }
    }
}
