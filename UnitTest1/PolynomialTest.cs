using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharkMath;

namespace UnitTest1
{
    [TestClass]
    public class PolynomialTest
    {
        [TestMethod]
        public void TestPolynomialAddition()
        {
            Polynomial p1 = new Polynomial("x2 + 5x + 6");
            Polynomial p2 = new Polynomial("x2 - 3x + 2");
            Polynomial p3 = new Polynomial("-x2 + x + 1");
            Polynomial p4 = new Polynomial("-x2 - 2x + 3");

            Polynomial result = p1 + p2;
            Polynomial result2 = p1 - p2;
            Polynomial result3 = p3 - p4;
            Polynomial result4 = p3 - p3;

            Assert.AreEqual("2x^2 + 2x + 8", result.print(false, false));
            Assert.AreEqual("8x + 4", result2.print(false, false));
            Assert.AreEqual("3x - 2", result3.print(false, false));
            Assert.AreEqual("0", result4.print(false, false));
        }

        [TestMethod]
        public void TestPolynomialMultiplication()
        {
            Polynomial p1 = new Polynomial("x + 1");
            Polynomial p2 = new Polynomial("x + 1");
            Polynomial p3 = new Polynomial("x - 1");
            Polynomial p5 = new Polynomial("x2 - x + 1");
            Polynomial p6 = new Polynomial("x2 + x + 1");

            Polynomial result1 = p1 * p2;
            Assert.AreEqual("x^2 + 2x + 1", result1.print());

            Polynomial result2 = p1 * p1;
            Assert.AreEqual("x^2 + 2x + 1", result2.print());

            Polynomial result3 = p1 * p3;
            Assert.AreEqual("x^2 - 1", result3.print());

            Polynomial result4 = p1 * p5;
            Assert.AreEqual("x^3 + 1", result4.print());

            Polynomial result5 = p3 * p6;
            Assert.AreEqual("x^3 - 1", result5.print());
        }

        [TestMethod]
        public void TestPolyNodePrintPositive()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));

            Assert.AreEqual("x^2 + 5x + 6", pn1.print(false, false));
            Assert.AreEqual(" + x^2 + 5x + 6", pn1.print(true, false));
            Assert.AreEqual("(x^2 + 5x + 6)", pn1.print(false, true));
            Assert.AreEqual(" + (x^2 + 5x + 6)", pn1.print(true, true));

            pn1.poly.flipSigns();

            Assert.AreEqual("-x^2 - 5x - 6", pn1.print(false, false));
            Assert.AreEqual(" - x^2 - 5x - 6", pn1.print(true, false));
            Assert.AreEqual("(-x^2 - 5x - 6)", pn1.print(false, true));
            Assert.AreEqual(" + (-x^2 - 5x - 6)", pn1.print(true, true));

            pn1.poly.flipSigns();
            pn1.coef.numerator = 2;

            Assert.AreEqual("2(x^2 + 5x + 6)", pn1.print(false, false));
            Assert.AreEqual(" + 2(x^2 + 5x + 6)", pn1.print(true, false));
            Assert.AreEqual("2(x^2 + 5x + 6)", pn1.print(false, true));
            Assert.AreEqual(" + 2(x^2 + 5x + 6)", pn1.print(true, true));

            pn1.poly.flipSigns();

            Assert.AreEqual("2(-x^2 - 5x - 6)", pn1.print(false, false));
            Assert.AreEqual(" + 2(-x^2 - 5x - 6)", pn1.print(true, false));
            Assert.AreEqual("2(-x^2 - 5x - 6)", pn1.print(false, true));
            Assert.AreEqual(" + 2(-x^2 - 5x - 6)", pn1.print(true, true));

        }

        [TestMethod]
        public void TestPolyNodePrintNegative()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            pn1.coef.numerator *= -1;


            Assert.AreEqual("-(x^2 + 5x + 6)", pn1.print(false, false));
            Assert.AreEqual(" - (x^2 + 5x + 6)", pn1.print(true, false));
            Assert.AreEqual("-(x^2 + 5x + 6)", pn1.print(false, true));
            Assert.AreEqual(" - (x^2 + 5x + 6)", pn1.print(true, true));

            pn1.poly.flipSigns();

            Assert.AreEqual("-(-x^2 - 5x - 6)", pn1.print(false, false));
            Assert.AreEqual(" - (-x^2 - 5x - 6)", pn1.print(true, false));
            Assert.AreEqual("-(-x^2 - 5x - 6)", pn1.print(false, true));
            Assert.AreEqual(" - (-x^2 - 5x - 6)", pn1.print(true, true));

            pn1.poly.flipSigns();
            pn1.coef.numerator = -2;

            Assert.AreEqual("-2(x^2 + 5x + 6)", pn1.print(false, false));
            Assert.AreEqual(" - 2(x^2 + 5x + 6)", pn1.print(true, false));
            Assert.AreEqual("-2(x^2 + 5x + 6)", pn1.print(false, true));
            Assert.AreEqual(" - 2(x^2 + 5x + 6)", pn1.print(true, true));

            pn1.poly.flipSigns();

            Assert.AreEqual("-2(-x^2 - 5x - 6)", pn1.print(false, false));
            Assert.AreEqual(" - 2(-x^2 - 5x - 6)", pn1.print(true, false));
            Assert.AreEqual("-2(-x^2 - 5x - 6)", pn1.print(false, true));
            Assert.AreEqual(" - 2(-x^2 - 5x - 6)", pn1.print(true, true));
        }

        [TestMethod]
        public void TestFracNodePrintPositive()
        {
            Polynomial p1 = new Polynomial("x2 - 3x + 5");
            Polynomial p2 = new Polynomial("x - 3");

            PolyNode pn1 = new PolyNode(p1);
            PolyNode pn2 = new PolyNode(p2);

            FracNode fn = new FracNode(pn1, pn2);

            Assert.AreEqual("\\frac{x^2 - 3x + 5}{x - 3}", fn.print(false, false));
            Assert.AreEqual(" + \\frac{x^2 - 3x + 5}{x - 3}", fn.print(true, false));
            Assert.AreEqual("(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(false, true));
            Assert.AreEqual(" + (\\frac{x^2 - 3x + 5}{x - 3})", fn.print(true, true));

            fn.coef.numerator = 2;

            Assert.AreEqual("2\\frac{x^2 - 3x + 5}{x - 3}", fn.print(false, false));
            Assert.AreEqual(" + 2\\frac{x^2 - 3x + 5}{x - 3}", fn.print(true, false));
            Assert.AreEqual("2(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(false, true));
            Assert.AreEqual(" + 2(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(true, true));
        }

        [TestMethod]
        public void TestFracNodePrintNegative()
        {
            Polynomial p1 = new Polynomial("x2 - 3x + 5");
            Polynomial p2 = new Polynomial("x - 3");

            PolyNode pn1 = new PolyNode(p1);
            PolyNode pn2 = new PolyNode(p2);

            FracNode fn = new FracNode(pn1, pn2);
            fn.coef.numerator = -1;

            Assert.AreEqual("-\\frac{x^2 - 3x + 5}{x - 3}", fn.print(false, false));
            Assert.AreEqual(" - \\frac{x^2 - 3x + 5}{x - 3}", fn.print(true, false));
            Assert.AreEqual("-(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(false, true));
            Assert.AreEqual(" - (\\frac{x^2 - 3x + 5}{x - 3})", fn.print(true, true));

            fn.coef.numerator = -2;

            Assert.AreEqual("-2\\frac{x^2 - 3x + 5}{x - 3}", fn.print(false, false));
            Assert.AreEqual(" - 2\\frac{x^2 - 3x + 5}{x - 3}", fn.print(true, false));
            Assert.AreEqual("-2(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(false, true));
            Assert.AreEqual(" - 2(\\frac{x^2 - 3x + 5}{x - 3})", fn.print(true, true));
        }

        [TestMethod]
        public void TestSumNodePrintPositive()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x - 7"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 5"));

            SumNode sn = new SumNode(pn1, pn2);

            Assert.AreEqual("x^2 + 5x - 7 + x - 5", sn.print(false, false));
            Assert.AreEqual(" + x^2 + 5x - 7 + x - 5", sn.print(true, false));
            Assert.AreEqual("(x^2 + 5x - 7 + x - 5)", sn.print(false, true));
            Assert.AreEqual(" + (x^2 + 5x - 7 + x - 5)", sn.print(true, true));
        }

        [TestMethod]
        public void TestSumNodePrintNegative()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x - 7"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 5"));

            SumNode sn = new SumNode(pn1, pn2);
            sn.flipSign();

            Assert.AreEqual("-(x^2 + 5x - 7 + x - 5)", sn.print(false, false));
            Assert.AreEqual(" - (x^2 + 5x - 7 + x - 5)", sn.print(true, false));
            Assert.AreEqual("-(x^2 + 5x - 7 + x - 5)", sn.print(false, true));
            Assert.AreEqual(" - (x^2 + 5x - 7 + x - 5)", sn.print(true, true));
        }

    }
}
