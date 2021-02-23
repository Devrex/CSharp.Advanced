using ClassLibrary1;
using NUnit.Framework;

namespace UnitTests
{
    public class MyNullableTests
    {
        [Test]
        public void CanAssignNull()
        {
            MyNullable<int> m = null;
            Assert.NotNull(m);
            Assert.IsFalse(m.HasValue);
        }

        [Test]
        public void CanAssignValue()
        {
            MyNullable<int> m = 42;
            Assert.NotNull(m);
            Assert.IsTrue(m.HasValue);
            Assert.AreEqual(42, m.Value);
        }

        [Test]
        public void CanCastToValueOfType()
        {
            var m = new MyNullable<int>(100);
            int i = m;
            Assert.AreEqual(100,i);
        }

        [Test]
        public void DefaultWhenNoValue()
        {
            MyNullable<int> m = null;
            Assert.AreEqual(default(int), m.ValueOrDefault());
        }

    }
}