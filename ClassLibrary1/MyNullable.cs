using System;

namespace ClassLibrary1
{
    public struct MyNullable<T> where T : struct
    {
        private readonly T _value;
        private bool _hasValue;


        public MyNullable(T value)
        {
            _value = value;
            _hasValue = true;
        }

        public bool HasValue => _hasValue;

        public T Value => _hasValue ? _value : throw new NullReferenceException();

        public T ValueOrDefault() => _hasValue ? _value : default(T);

        /// <summary>
        /// Assign from value of type T
        /// </summary>
        public static implicit operator MyNullable<T>(T o)
        {
            return new MyNullable<T>(o);
        }

        /// <summary>
        /// Assign from null
        /// </summary>
        /// <param name="t"></param>
        public static implicit operator MyNullable<T>(T? t)
        {
            if (t is null)
            {
                return new MyNullable<T>();
            }
            else
            {
                throw new InvalidCastException("");
            }
        }

        public static implicit operator T(MyNullable<T> nullable)
        {
            if (!nullable.HasValue) throw new InvalidOperationException();
            return nullable.Value;
        }
    }
}
