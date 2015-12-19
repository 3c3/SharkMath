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
    }
}
