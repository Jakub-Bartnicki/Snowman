using Snowman.GameLevel;
using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    public class Game
    {
        // private List<RainDrop> rainDropList;
        private static IGameBuilder gameBuilder = new GameBuilder();

        public static IGameBuilder GameBuilder
        {
            get
            {
                return gameBuilder;
            }
        }

        public Game()
        {
        }
    }
}
