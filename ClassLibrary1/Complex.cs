namespace ClassLibrary1
{
    /// <summary>
    /// Represents a complex number as a polynom
    /// </summary>
    public class Complex
    {
        
        /// <summary>
        /// The imaginary component (coefficient of i)
        /// </summary>
        public readonly double Imaginary;

        /// <summary>
        /// The real number component
        /// </summary>
        public readonly double Real;

        public Complex(double i, double r)
        {
            Imaginary = i;
            Real = r;
        }

        public static Complex operator*(Complex lhs, Complex rhs)
        {
            double imaginary = lhs.Real * rhs.Imaginary ;
            imaginary += rhs.Real * lhs.Imaginary;

            double real = lhs.Real * rhs.Real;
            real += -lhs.Imaginary * rhs.Imaginary; // i * i cancel each other

            return new Complex(imaginary, real);
        }

        public override string ToString()
        {
            return $"({Imaginary}i + {Real})";
        }
    }
}
