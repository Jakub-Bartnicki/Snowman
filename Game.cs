using Snowman.RainDropFactory;
using Snowman.Snowman;
using Snowman.States;
using Snowman.Themes;
using System.Collections.Generic;



namespace Snowman
{
    public abstract class Game
    {
        private static List<RainDrop> rainDropList = new List<RainDrop>();
        public SnowMan Snowman;
        public Theme theme;
        public int Difficulty { get; set; }
        public bool Buffs { get; set; }

        public Game()
        {
            RainDropList.Clear();
            Snowman = new SnowMan(new NormalState());
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
