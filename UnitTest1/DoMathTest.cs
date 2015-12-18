using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharkMath;

namespace UnitTest1
{
    [TestClass]
    public class DoMathTest
    {
        [TestMethod]
        public void DoMathMultiplicationTest()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            Node result = Node.Multiply2(pn1, pn2);
            result.doMath();
            result = result.ToNode();
            Assert.AreEqual("x^2 + 8x + 15", result.print(false, false));
        }

        [TestMethod]
        public void DoMathMultiplicationTest2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            pn1.coef.numerator = 2;
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            Node result = Node.Multiply2(pn1, pn2);
            result.doMath();
            result = result.ToNode();
            Assert.AreEqual("2(x^2 + 8x + 15)", result.print(false, false));
        }

        [TestMethod]
        public void DoMathAdditionTest()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            Node result = Node.Add2(pn1, pn2);
            result.doMath();
            result = result.ToNode();
            Assert.AreEqual("2x + 8", result.print(false, false));
        }

        [TestMethod]
        public void DoMathAdditionTest2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            pn1.coef.numerator = 2;
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            Node result = Node.Add2(pn1, pn2);
            result.doMath();
            result = result.ToNode();
            Assert.AreEqual("3x + 13", result.print(false, false));
        }

        public void DoFracAdditionTest()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            FracNode fn = new FracNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));
        }
    }
}
