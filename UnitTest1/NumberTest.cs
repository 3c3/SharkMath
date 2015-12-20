using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharkMath;

namespace UnitTest1
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void TestIsSquare()
        {
            for(int i = 1; i < 1000; i++)
            {
                Assert.IsTrue(Number.isSquare(i * i));
            }

            for (int i = 1; i < 1000; i++)
            {
                Assert.IsFalse(Number.isSquare(i * i - 1));
            }
        }

        [TestMethod]
        public void PrintTest()
        {
            Number n1 = new Number(1);

            Assert.AreEqual("1", n1.print(false, true));
            Assert.AreEqual("", n1.print(false, false));

            Number n2 = new Number(-1);

            Assert.AreEqual("-1", n2.print(false, true), "-1 true");
            Assert.AreEqual("-", n2.print(false, false), "-1 false");
        }
    }
}
