using NanoleafAuroraSdk.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafAuroraSdk.Test.UnitTests.HelperTests
{
    [TestFixture]
    public class ColorHelperTests
    {
        [Test]
        public void ConvertColorToRgb_FormatIsExpected_WhenColorGreen()
        {
            // arrange
            Color c = Color.Green;

            // act
            var result = ColorHelpers.ConvertColorToRgb(c);

            // assert
            Assert.IsTrue(result == "0 128 0");
        }

        [Test]
        public void ConvertColorToHex_FormatIsExpected_WhenColorGreen()
        {
            // arrange
            Color c = Color.Green;

            // act
            var result = ColorHelpers.ConvertColorToHex(c);

            // assert
            Assert.IsTrue(result == "0 80 0");
        }
    }
}
