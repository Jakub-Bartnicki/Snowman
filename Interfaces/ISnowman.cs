using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Interfaces
{
    public interface ISnowman
    {
        void Attach(SnowmanObserver snowmanObserver);
        void Detach(SnowmanObserver snowmanObserver);
        void Notify();
        void Request();

    }
}
