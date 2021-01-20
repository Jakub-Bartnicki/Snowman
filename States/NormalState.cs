using Snowman.Snowman;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.States
{
    sealed class NormalState : State
    {
        public override void block()
        {
            this.Snowman.Moveable = false;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new LockedState());
        }

        public override void buff()
        {
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = true;
            this.Snowman.TransitionTo(new BuffedState());
        }

        public override void normalize()
        {
            // already normal
        }
    }
}
