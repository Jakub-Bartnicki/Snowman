using Snowman.GameLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Interfaces
{
    interface IGameBuilder
    {
        void setGamemodeOn();

        void setGamemodeOff();

        void setDifficultyEasy();

        void setDifficultyNormal();

        void setDifficultyHard();
    }
}
