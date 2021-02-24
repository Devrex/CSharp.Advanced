using ClassLibrary1;
using System;
using System.Drawing;
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

            //remember the current textcolor so we can restore later
            var oldColor = Console.ForegroundColor;

            foreach (var testResult in result)
            {
                if (testResult.Passed) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(testResult);                
            }
            Console.ForegroundColor = oldColor;
        }
    }
}
