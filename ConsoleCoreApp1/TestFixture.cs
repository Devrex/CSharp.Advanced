namespace ConsoleCoreApp1
{
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
        protected void Assert(bool expression, string message)
        {
            if (!expression) throw new AssertionFailedException();
        }
    }
}
