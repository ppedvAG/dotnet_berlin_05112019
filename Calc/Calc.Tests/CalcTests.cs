using System;
using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_4_result_7()
        {
            var calc = new Calc();

            var result = calc.Sum(3, 4);

            Assert.AreEqual(7, result);

            result.Should().Be(7);
            result.Should().BeInRange(3, 4);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_result____()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(Int32.MaxValue, 1));

        }

        [TestMethod]
        public void Calc_IsWeekend()
        {
            var calc = new Calc();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 11, 5);
                Assert.IsFalse(calc.IsWeekend());

                //So
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2019, 11, 10);
                Assert.IsTrue(calc.IsWeekend());
            }

        }
    }
}
