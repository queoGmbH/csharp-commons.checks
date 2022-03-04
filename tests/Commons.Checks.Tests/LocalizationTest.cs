using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FluentAssertions;

using NUnit.Framework;

using Queo.Commons.Checks;

namespace Commons.Checks.Tests
{
    [TestFixture]
    public class LocalizationTest
    {
        [Test]
        public void TestEn()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine("Current culture is now en-US");
            Action action = () => Require.Le(4, 2, "propertyName");
            action.Should().Throw<ArgumentOutOfRangeException>().WithMessage("The parameter propertyName must be less or equals to 2. But it was 4.*");
        }
    }
}
