using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Themes
{
    public class LightTheme : Theme
    {
        private LightTheme() { }

        public override Theme getInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new LightTheme();
                    }
                }
            }
            return instance;
        }
    }
}
