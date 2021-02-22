using System;

namespace ClassLibrary1
{
    /// <summary>
    /// Make structs immutable and don't use too many fields as they 
    /// are always copied when assigning on struct to another
    /// </summary>

    public struct Point
    {
        public readonly double X;
        public readonly double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point Translate(double deltaX, double deltaY)
        {
            return new Point(X + deltaX, Y + deltaY);
        }
    }

    public class Circle : System.Object
    {

        public const double PI = 3;

        public const string CircleName = "CircleName";

        public Circle()
        {

        }

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException();
            Radius = radius;
        }
        public readonly double Radius;

        //auto property
        public DateTime Foo { get; private set; } = DateTime.UtcNow;


        public double Area() => Math.PI * Radius * Radius;


        private int myVar;

        public int MyProperty
        {
            get => myVar;
            set
            {
                if (value <= 0) throw new ArgumentException("");
                myVar = value;
            }
        }

        public void Do(int newValue)
        {
            if (newValue < 100) throw new ArgumentException("newValue must be >= 100", nameof(newValue));
            myVar = newValue;
        }

    }
}
