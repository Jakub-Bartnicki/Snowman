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
    public abstract class Game
    {
        protected List<RainDrop> rainDropList = new List<RainDrop>();
        public static SnowMan Snowman = new SnowMan(new NormalState());
        public int Difficulty { get; set; }
        public bool Buffs { get; set; }

        public Game()
        {
            this.FactoryMethod();
        }

        public List<RainDrop> RainDropList
        {
            get { return rainDropList; }
        }

        public virtual void FactoryMethod() { }

        public virtual RainDrop DrawRainDrop()
        {
            return null;
        }
    }
}
