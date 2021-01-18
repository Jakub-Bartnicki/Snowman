using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Lists
{
    public class AbstractList
    {
        public ShapeListIterator CreateIterator()
        {
            ShapeListIterator shapeListIterator = new ShapeListIterator();
            return shapeListIterator;
        }
    }
}
