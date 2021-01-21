using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Themes
{
    public abstract class Theme
    {
        protected Theme instance;
        protected static readonly object _lock = new object();

        public abstract Theme getInstance();
    }
}
