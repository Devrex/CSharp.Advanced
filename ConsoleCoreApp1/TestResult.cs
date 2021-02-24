using System;

namespace ConsoleCoreApp1
{
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

        private TestResult(string testName, bool passed, string message)
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
            return String.Format("{0,-30}{1}", TestName, Message);
        }
    }
}
