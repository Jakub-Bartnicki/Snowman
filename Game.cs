using Snowman.RainDropFactory;
using Snowman.Snowman;
using Snowman.States;
using System.Collections.Generic;



namespace Snowman
{
    public abstract class Game
    {
        private SnowMan snowman;
        private int difficulty;
        public SnowMan Snowman
        {
            get { return snowman; }
        }
        public int Difficulty 
        { 
            get { return difficulty; }
            set { difficulty = (0 <= value && value <= 2) ? value : 0; }
        }
        public bool Buffs { get; set; }

        public Game()
        {
            snowman = new SnowMan(new NormalState());
        }

        public abstract RainDrop CreateNeutralRainDrop();
        public abstract RainDrop CreateOffensiveRainDrop();
        public abstract RainDrop CreatePositiveRainDrop();
    }
}
