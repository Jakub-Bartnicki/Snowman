using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.States
{
    sealed class BuffedState : State
    {
        public override void block()
        {
            this.Snowman.Moveable = false;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new LockedState());
        }

        public override void buff()
        {
            // already buffed, refresh buff time
        }

        public override void normalize()
        {
            this.Snowman.Moveable = true;
            this.Snowman.Buffed = false;
            this.Snowman.TransitionTo(new NormalState());
        }
    }
}
