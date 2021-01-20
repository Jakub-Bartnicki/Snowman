using Snowman.Snowman;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.States
{
    public abstract class State
    {
        protected SnowMan Snowman;
        public abstract void block();
        public abstract void buff();
        public abstract void normalize();
        public void setSnowman(SnowMan snowman)
        {
            this.Snowman = snowman;
        }
    }
}
