using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class MyMath
    {

        public delegate int BinaryOperator(int lhs, int rhs);


        public static IEnumerable<int> NaturalNumbers()
        {
            int i = 1;
            while (true)
            {
                yield return i;
                i++;
            }
        }

        public static void Demo()
        {
            BinaryOperator myOperator = Add;

            Func<int, int, int> op = Add;
            ApplyAndPrint(op, 100, 200);

            int result = myOperator(10, 20);
            System.Console.WriteLine(result);

            ApplyAndPrint((a,b) => Add(a,b), 10, 10);

            ApplyUnaryAndPrint(a => Negate(a), 20);

            Func<int, int, int> myLambda = (a, b) => a - b;
            //{
            //    return a - b;
            //};

            ApplyAndPrint(myLambda, 4,4);

            //Send direct reference
            ApplyAndPrint(Add, 20, 20);

            var someNumbers = NaturalNumbers()
                .Where(n => n % 2 == 0)
                .Skip(1000)
                .Take(40)
                .ToList();

            foreach (var number in NaturalNumbers())
            {
                if (number > 1000) break;
                Console.WriteLine(number);
            }
        }

        private static int Negate(int a)
        {
            return -a;
        }

        private static IEnumerable<U> Map<T,U>(IEnumerable<T> input, Func<T, U> mapper)
        {
            return input.Select(item => mapper.Invoke(item));
        }

        private static void ApplyUnaryAndPrint(Func<int, int> f, int v)
        {
            var result = f(v);
            Console.WriteLine(result);
        }

        private static void ApplyAndPrint(Func<int,int,int> op, int a, int b)
        {
            var result = op.Invoke(a,b);
            System.Console.WriteLine(result);
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
