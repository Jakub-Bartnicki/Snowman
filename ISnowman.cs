using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman
{
    public interface ISnowman
    {
        void attach(SnowmanObserver snowmanObserver);
        void detach(SnowmanObserver snowmanObserver);
        void notify();
        void request();

    }
}
