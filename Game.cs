using Snowman.RainDropFactory;
using Snowman.Snowman;
using Snowman.States;
using System.Collections.Generic;



namespace Snowman
{
    public abstract class Game
    {
        private static List<RainDrop> rainDropList = new List<RainDrop>();
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
            RainDropList.Clear();
            snowman = new SnowMan(new NormalState());
        }

        public static List<RainDrop> RainDropList
        {
            get { return rainDropList; }
        }

        public abstract RainDrop CreateNeutralRainDrop();
        public abstract RainDrop CreateOffensiveRainDrop();
        public abstract RainDrop CreatePositiveRainDrop();

        public virtual RainDrop DrawRainDrop()
        {
            return null;
        }
    }
}
