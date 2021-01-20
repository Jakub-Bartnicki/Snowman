using Snowman.GameLevel;
using Snowman.Interfaces;
using Snowman.RainDropFactory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    class Game
    {
        private List<RainDrop> rainDropList = new List<RainDrop>();
        private static IGameBuilder gameBuilder = new GameBuilder();

        public Game()
        {
            this.FactoryMethod();
        }

        public List<RainDrop> RainDropList
        {
            get { return rainDropList; }
        }
        public static IGameBuilder GameBuilder
        {
            get{ return gameBuilder; }
        }

        public virtual void FactoryMethod() { }
    }
}
