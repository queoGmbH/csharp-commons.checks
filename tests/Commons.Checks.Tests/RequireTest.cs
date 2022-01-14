using System;

using NUnit.Framework;

using Queo.Commons.Checks;

namespace Commons.Checks.Tests
{
    [TestFixture]
    public class RequireTest
    {
        [Test]
        public void TestLeForClass()
        {
            MyTestClass param = new MyTestClass(2);
            MyTestClass limit = new MyTestClass(5);

            Require.Le(param, limit, "param");
        }

        [Test]
        public void TestLeForEqual()
        {
            Require.Le(2, 5, "param1");
        }

        [Test]
        public void TestLeForLess()
        {
            Require.Le(2, 5, "param1");
        }

        [Test]
        public void TestNotNull()
        {
            string param = "Test";
            Require.NotNull(param, nameof(param));
            Assert.Pass();
        }

        [Test]
        public void TestNotNullWithNull()
        {
            object test = null;
            // ReSharper disable once ExpressionIsAlwaysNull : Das ist der Testfall
            ArgumentNullException argumentNullException = Assert.Throws<ArgumentNullException>(() => Require.NotNull(test, "param1"));
            Assert.AreEqual("param1", argumentNullException.ParamName);
        }

        [Test]
        public void TestNotNullWithNullAsName()
        {
            ArgumentNullException argumentNullException = Assert.Throws<ArgumentNullException>(() => Require.NotNull((string)null, null));
            Assert.AreEqual("unknown", argumentNullException.ParamName);
        }
    }

    internal class MyTestClass : IComparable<MyTestClass>, IComparable
    {
        private int _anyValue;

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public MyTestClass(int anyValue)
        {
            _anyValue = anyValue;
        }

        public int AnyValue
        {
            get { return _anyValue; }
            set { _anyValue = value; }
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return obj is MyTestClass other
                ? CompareTo(other)
                : throw new ArgumentException($"Object must be of type {nameof(MyTestClass)}");
        }

        public int CompareTo(MyTestClass other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return _anyValue.CompareTo(other._anyValue);
        }
    }
}
