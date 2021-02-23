using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{

    internal class SneakyCircle : Circle
    {
        Circle _decoratedCircle;
        public SneakyCircle(Circle circle) : base(0)
        {
            _decoratedCircle = circle;
        }

        public override double Area()
        {
            return _decoratedCircle.Area() + 0.00001;
        }
    }

    public class Circle : System.Object
    {
        public const double PI = 3;

        public const string CircleName = "CircleName";

        public Circle()
        {

        }

        //factory method
        public static Circle Create(int radius)
        {
            return new SneakyCircle(radius);
        }

        public Circle(double radius)
        {
            if (radius <= 0) throw new ArgumentException();
            Radius = radius;
        }
        public readonly double Radius;

        //auto property
        public DateTime Foo { get; private set; } = DateTime.UtcNow;


        public virtual double Area() => Math.PI * Radius * Radius;


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

        //To compare objects by value, override Equals.
        // (structs are compared by value by default)
        // Always implement GetHashCode when overriding Equals
        //public override bool Equals(object obj)
        //{
        //    return obj is Circle c && c.Radius == Radius;
        //}


    }

    public abstract class Component
    {
        public abstract int Weight();
    }

    public class ConcreteComponent : Component
    {
        private int _weight;

        public override int Weight()
        {
            return _weight;
        }
    }
    
    public class CompositeComponent : Component
    {
        List<Component> _children;

        public void Add(Component c)
        {
            _children.Add(c);
        }

        public override int Weight()
        {
            return _children.Sum(c => c.Weight());
        }
    }

    public interface IResolver
    {
        T Resolve<T>();
        object Resolve(Type t);
    }

    public interface IRegistry
    {
        /// <summary>
        /// Register scoped, new instance each resolution call
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Register<T>();

        /// <summary>
        /// Register singleton
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        void Register<T>(T instance);
    }
}
