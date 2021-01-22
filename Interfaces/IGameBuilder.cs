namespace Snowman.Interfaces
{
    public interface IGameBuilder
    {
        public void setGamemodeOn();

        public void setGamemodeOff();

        public void setDifficultyEasy();

        public void setDifficultyNormal();

        public void setDifficultyHard();

        public Game GetGame();
    }
}
