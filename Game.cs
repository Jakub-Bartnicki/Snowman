using Snowman.GameLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    public class Game
    {
        // private List<RainDrop> rainDropList;
        IGameBuilder gameBuilder;

        public Game()
        {
            gameBuilder = new GameBuilder();
            gameBuilder.setDifficultyEasy();
            gameBuilder.setGamemodeOn();
        }


    }
}
