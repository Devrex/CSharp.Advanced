using ClassLibrary1;
using System;
using System.Reflection;

namespace ConsoleCoreApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myAssembly = Assembly.GetExecutingAssembly();
            var runner = new Runner(myAssembly);
            var result = runner.Run();
            foreach(var testResult in result)
            {
                Console.WriteLine(result);
            }

            //MyMath.Demo();
        }
    }
}
