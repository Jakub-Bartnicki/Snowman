using Snowman.GameLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    public interface IGameBuilder
    {
        void setGamemodeOn();

        void setGamemodeOff();

        void setDifficultyEasy();

        void setDifficultyNormal();

        void setDifficultyHard();
    }
}
