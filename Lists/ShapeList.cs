using Snowman.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowman.Lists
{
    public class ShapeList : AbstractList
    {
        public new ShapeListIterator CreateIterator()
        {
            ShapeListIterator shapeListIterator = new ShapeListIterator();
            return shapeListIterator;
        }
    }
}
