using ClassLibrary1;
using System;
using System.Collections.Generic;
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

            MyMath.Demo();
        }
    }

    public class Runner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly">The assembly containing tests to be executed</param>
        public Runner(Assembly assembly)
        {

        }

        /// <summary>
        /// Run the tests and return a list of test results
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestResult> Run()
        {
            yield break;
        }
    }

    public class TestResult
    {
        /// <summary>
        /// Name of the test
        /// </summary>
        public readonly string TestName;

        /// <summary>
        /// True if the test passed, false if fails or exception was thrown
        /// </summary>
        public readonly bool Passed;

        /// <summary>
        /// Failure description
        /// </summary>
        public readonly string Message;

        public TestResult(string testName, bool passed, string message)
        {
            TestName = testName;
            Passed = passed;
            Message = message;
        }

        public static TestResult Failure(string testName, string reason)
        {
            return new TestResult(testName, false, reason);
        }

        public static TestResult Ok(string testName)
        {
            return new TestResult(testName, true, "Ok");
        }

        public override string ToString()
        {
            return "TODO";
        }
    }

 


    //class MyTests : MyTestBase
    //{
    //    [Fact]
    //    public void MathTest()
    //    {
    //        Assert.AreEqual(12, 12);
    //    }
    //}

    /// <summary>
    /// Inherit this class and add test methods
    /// </summary>
    public abstract class TestFixture
    {
        public void Assert(bool expression, string message)
        {
            if (!expression) throw new AssertionFailedException();
        }
    }
}
