using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    public class SnowmanObservable
    {
        SnowmanObserver snowmanObserver;

        public SnowmanObservable(SnowmanObserver snowmanObserver)
        {
            this.snowmanObserver = snowmanObserver;
        }

        public void GetState() { }
    }
}
