namespace Snowman.Interfaces
{
    public interface IGameBuilder
    {
        void setGamemodeOn();

        void setGamemodeOff();

        void setDifficultyEasy();

        void setDifficultyNormal();

        void setDifficultyHard();

        Game GetGame();
    }
}
