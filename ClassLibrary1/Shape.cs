using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    /// <summary>
    /// Base class for all shapes
    /// </summary>
    public abstract class Shape
    {
        public readonly Point Location;

        public Shape(Point location)
        {
            Location = location;
        }
        public abstract double Area();
    }
}
