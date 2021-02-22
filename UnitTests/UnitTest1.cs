using ClassLibrary1;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class Tests
    {
        /// <summary>
        /// Demonstrates passing reference types by reference
        /// </summary>
        [Test]
        public void PassCircleByValue()
        {
            Circle circle = new Circle(100);
            CircleByValue(circle);
            Assert.AreEqual(100, circle.Radius);

            //Copy the the reference to another stack variable
            Circle c2 = circle;
            Assert.AreSame(circle, c2);

            CircleByReference(ref circle);
            Assert.AreEqual(10, circle.Radius);
            Assert.AreEqual(100, c2.Radius);
        }

        [Test]
        public void OutParameters()
        {
            Assert.Pass();
        }

        [Test]
        public void BoxingAndUnboxing()
        {
            int i = 42;
            //boxing. value goes inside an object on the heap
            object o = 42;

            //unboxing, extract the value from the "box", 
            //will throw if type does not match
            int j = (int) o;
        }

        [Test]
        public void Int32Alias()
        {
            //int is a c# keyword and alias for the System.Int32 value type
            var t1 = typeof(int);
            var t2 = typeof(Int32);
            Assert.AreSame(t1, t2);
        }

        [Test]
        public void UninitializedLocalVariables()
        {
            int n;
            //next line does not compile
            //Console.WriteLine(n);
        }

        [Test]
        public void StructVsClass()
        {
            //objects are allocated on the heap
            //object initializer and constructor call
            var circle = new Circle(100)
            {
                MyProperty = 100
            };

            Circle c2 = circle;
            //there is only one circle, both stack variables refer to the same object
            Assert.AreSame(circle, c2);

            //struct fields are stored inline
            var point = new Point(10, 20);

            var point2 = point; //copies the values, we now have 2 structs but with the same value
            Assert.AreNotSame(point2, point);

            //todo: DateTime is a struct! and immutable
            
            var now = DateTime.UtcNow;

            //noop, result is not captured!
            now.Add(TimeSpan.FromMinutes(20));

            //capture return value!
            var later = now.Add(TimeSpan.FromMinutes(20));

            //strings are also immutable even though they are reference types

            var s = "BART"; //allocate 8 (2 bytes per char)
            Char c = 's'; //character are utf-16, strings are utf-16

            // allocate a new string, no reference left to previous
            s = s.ToLower();

            Assert.AreEqual("bart", s);
        }

        [Test]
        public void DefaultsOfValueTypesVsReferenceTypes()
        {
            //value types have the natural default value, they can never be null!
            int defaultInt = default(int);
            Assert.AreEqual(0, defaultInt);

            Circle c = default(Circle);
            Assert.IsNull(c);

            Point p = default(Point);
            Assert.AreEqual(0, p.X, 0.0001);
            Assert.AreEqual(0, p.Y, 0.0001);

            Assert.AreEqual(DateTime.MinValue, default(DateTime));

        }

        [Test]
        public void OperatorOverloading()
        {
            var later = DateTime.UtcNow + TimeSpan.FromMinutes(10);

            //button.onclick = function(){ }
            //Button.Click += (s, e) => MessageBox.Show("Hit me!");

            String s1 = "Bart";
            String s2 = "Bart";

            //compare values (strings) in java: s1.equals(s2)
            //s1 == s2 is reference comparison, 

            // == is overloaded for strings in c#
            Assert.IsTrue(s1 == s2);


        }

        [Test]
        public void OldTupleSyntax()
        {
            Tuple<string,string> t = Tuple.Create("name", "Bart");
            Tuple<string, string, int> t2 = Tuple.Create("name", "Homer", 35);
            Assert.AreEqual("Bart", t.Item2);

            //syntactic sugar, but still ugly property names
            var t3 = ("Marge", 32);
            Assert.AreEqual(32, t3.Item2);

            //deconstruction
            var (name, age) = t3;

            //works with arguments and return values
            var coords = (20, 30);
            var newcoords = Translate45(coords, 5);
            Assert.AreEqual(25, newcoords.Item1);
            Assert.AreEqual(35, newcoords.Item2);

            //inline tuple
            var (x, y) = Translate45((10, 20), 2);
            Assert.AreEqual(12, x);
            Assert.AreEqual(22, y);
        }
        [Test]
        public void Nullable()
        {
            //append ? to value type T is syntactic sugar for Nullable<T>

            int? i = null;
            Nullable<int> j;

            Assert.AreSame(typeof(int?), typeof(Nullable<int>));

            //equivalent
            int a = i.GetValueOrDefault();
            int b = i ?? default(int);

            //?? operator
            int c = i ?? 42;


            int sum = Add(100);
            Assert.AreEqual(142, sum);

            sum = Add(100, 100);
            Assert.AreEqual(200, sum);


        }

        [Test]
        public void TryWithOutVariablePattern()
        {
            // next line will throw
            //Int32.Parse("nope");

            //note inline declaration of the result variable and it's scope
            if (Int32.TryParse("nope", out var result))
            {
                Assert.Fail();
            }
            //out var MUST be assigned, assuming 0 when parse fails
            //note the scope of result
            Assert.AreEqual(default(int), result);
        }

        static void CircleByValue(Circle c)
        {
            c = new Circle(42);
            Console.WriteLine(c.Area());
        }

        static void CircleByReference(ref Circle c)
        {
            c = new Circle(10);
            Console.WriteLine(c.Area());
        }

        static void IncIfHappy(bool happy, ref int number)
        {
            if (happy) number++;
        }

        static void HitMe(bool odd, out int number)
        {
            if (odd) number = 13;
            else number = 42;
        }

        static int Add(int a, int? b = null)
        {
            if (b == null) Console.WriteLine("Warn: no arg passed, using default");
            return a + (b ?? 42); 
        }

        static (int,int) Translate45((int,int) coords, int delta)
        {
            var (x, y) = coords;
            return (x + delta, y + delta);
            Console.WriteLine(coords.GetType().Name);
        }

    }
}