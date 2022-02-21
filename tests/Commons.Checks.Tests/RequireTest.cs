using System;

using FluentAssertions;

using NUnit.Framework;

using Queo.Commons.Checks;

namespace Commons.Checks.Tests
{
    [TestFixture]
    public class RequireTest
    {
        [Test]
        public void TestGeForGreater()
        {
            Require.Ge(4, 2, "param");
        }

        [Test]
        public void TestGeForEqual()
        {
            Require.Ge(3, 3, "param");
        }

        [Test]
        public void TestGeForLessThanThrows()
        {
            Action action = () => Require.Ge(2, 4, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TestGtWithGreater()
        {
            Require.Gt(4, 2, "param");
        }

        [Test]
        public void TestGtWithEqualThrows()
        {
            Action action = () => Require.Gt(3, 3, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TestGtWithLessThrows()
        {
            Action action = () => Require.Gt(2, 4, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

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
            Require.Le(2, 2, "param1");
        }

        [Test]
        public void TestLeForLess()
        {
            Require.Le(2, 5, "param1");
        }

        [Test]
        public void TestLeForGreaterShouldThrow()
        {
            Action action = () => Require.Le(5, 2, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TestLtWithLess()
        {
            Require.Lt(2, 3, "param");
        }

        [Test]
        public void TestLtWithEqualThrows()
        {
            Action action = () => Require.Lt(2, 2, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TestLtWithGreaterThrows()
        {
            Action action = () => Require.Lt(5, 2, "param");
            action.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void TestNotNull()
        {
            string param = "Test";
            Require.NotNull(param, nameof(param));
            Assert.Pass();
        }

        [Test]
        public void TestNotNullWithNullWithoutParamNameThrows()
        {
            Action action = () => Require.NotNull((object)null);
            action.Should().Throw<ArgumentNullException>();
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

        [Test]
        public void TestNotNullOrEmpty()
        {
            Require.NotNullOrEmpty("test", "param");
        }

        [Test]
        public void TestNotNullOrEmptyWithNullThrows()
        {
            Action action = () => Require.NotNullOrEmpty((string)null, "Param");
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void TestNotNullOrEmptyWithEmptyThrows()
        {
            Action action = () => Require.NotNullOrEmpty(string.Empty, "param");
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void TestNotNullOrEmptySuccess()
        {
            Require.NotNullOrEmpty("text", "param");
        }

        [Test]
        public void TestNotNullOrWhitespaceSuccess()
        {
            Require.NotNullOrWhiteSpace("test", "param");
        }

        [Test]
        public void TestNotNullOrWhitespaceWithNullThrows()
        {
            string test = null;
            Action action = () => Require.NotNullOrWhiteSpace(test, "param");
            action.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void TestNotNullOrWhitespaceWithWhitespaceThrows()
        {
            Action action = () => Require.NotNullOrWhiteSpace(" ", "param");
            action.Should().Throw<ArgumentNullException>();
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
