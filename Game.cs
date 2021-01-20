using Snowman.GameLevel;
using Snowman.Interfaces;
using Snowman.RainDropFactory;
using Snowman.Snowman;
using Snowman.States;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Threading;


namespace Snowman
{
    class Game
    {
        protected List<RainDrop> rainDropList = new List<RainDrop>();
        private static IGameBuilder gameBuilder = new GameBuilder();
        public static SnowMan Snowman = new SnowMan(new NormalState());

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

        public virtual RainDrop DrawRainDrop()
        {
            return null;
        }
    }
}
