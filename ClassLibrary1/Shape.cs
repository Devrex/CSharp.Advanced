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
            IChecksum sha1 = new Sha1();
            sha1.
        }
        public abstract double Area();
    }


    public class Sha1 : IChecksum
    {
        public string Calculate(string input)
        {
            throw new NotImplementedException();
        }
    }
    public class Md5 : IChecksum
    {
        public string Calculate(string input)
        {
            throw new NotImplementedException();
        }
    }

    public interface IChecksum
    {
        string Calculate(string input);
    }
}
