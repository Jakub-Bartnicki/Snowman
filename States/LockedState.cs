using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.States
{
    sealed class LockedState : State
    {
        public override void block()
        {
            // already locked, refresh lock time
        }

        public override void buff()
        {
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = true;
            this.Snowman.TransitionTo(new BuffedState());
        }

        public override void normalize()
        {
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new NormalState());
        }
    }
}
