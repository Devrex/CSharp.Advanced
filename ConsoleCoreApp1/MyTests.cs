using System;

namespace ConsoleCoreApp1
{
    class MyTests : TestFixture
    {
        public void PassingTest()
        {
            Assert(12 == 12, "expected 12 to equal 12");
        }

        public void FailingTest()
        {
            Assert(12 == 14, "expected 12 to equal 14");
        }

        public void CrashingTest()
        {
            throw new Exception("BOOM!");
        }
    }
}
