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

        public static Point operator +(Point lhs, Point rhs)
            => new Point(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Point operator-(Point p)
        {
            return new Point(-p.X, -p.Y);
        }
    }
}
