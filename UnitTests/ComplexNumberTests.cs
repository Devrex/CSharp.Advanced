using ClassLibrary1;
using NUnit.Framework;

namespace UnitTests
{
    public class ComplexNumberTests
    {
        [Test]
        public void ComplexToString()
        {
            var complex = new Complex(10, 20);
            Assert.AreEqual("(10i + 20)", complex.ToString());
        }

        [Test]
        public void Multiplication()
        {
            var c1 = new Complex(2, 3);
            var c2 = new Complex(5, 7);
            var c3 = c1 * c2;
            Assert.AreEqual(29, c3.Imaginary);
            Assert.AreEqual(11, c3.Real);
        }
    }
}