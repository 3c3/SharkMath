using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharkMath;

namespace UnitTest1
{
    [TestClass]
    public class ExpressionTest
    {
        [TestMethod]
        public void TestExpressionAddSimple()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));

            Expression result = new Expression();

            result.addNode(pn1, false);
            result.addNode(pn2, true);
            result.addNode(pn3, true);

            Assert.AreEqual("3x + 9", result.print());
        }

        [TestMethod]
        public void TestExpressionAddSimple2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            ProdNode prn1 = new ProdNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));

            Expression result = new Expression();

            result.addNode(prn1, false);
            result.addNode(pn3, true);

            Assert.AreEqual("(x + 5)(x + 3) + x + 1", result.print());
        }

        [TestMethod]
        public void TestExpressionAddSimple3()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            ProdNode prn1 = new ProdNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));

            Expression result = new Expression();

            result.addNode(prn1, true);
            result.addNode(pn3, true);

            Assert.AreEqual("x^2 + 9x + 16", result.print());
        }
    }
}
