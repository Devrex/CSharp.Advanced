using System;

namespace ConsoleCoreApp1
{

    /// <summary>
    /// Inherit this class and add test methods
    /// </summary>
    public abstract class TestFixture
    {
        internal event Action<string> AssertionFailed = delegate{ };
        protected void Assert(bool expression, string errorMessage)
        {
            if (!expression) AssertionFailed.Invoke(errorMessage);
        }
    }
}
