using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharkMath;

namespace UnitTest1
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void TestNodeAddition1()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            Node result = Node.Add2(pn1, pn2);
            Assert.AreEqual("x^2 + 5x + 6 + x - 3", result.print(false, false));
        }

        [TestMethod]
        public void TestNodeMultiplication()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            Node result = Node.Multiply2(pn1, pn2);
            Assert.AreEqual("(x^2 + 5x + 6)(x - 3)", result.print(false, false));

            PolyNode pn3 = new PolyNode(new Polynomial("x - 4"));
            result = Node.Multiply2(result, pn3);
            Assert.AreEqual("(x^2 + 5x + 6)(x - 3)(x - 4)", result.print(false, false));

            ProdNode pr = result as ProdNode;
            Assert.IsTrue(pr.nChildren == 3);
        }

        [TestMethod]
        public void TestNodeAddition2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            Node frac = new FracNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 4"));

            Node result = Node.Add2(frac, pn3);
            Assert.AreEqual("\\frac{x^2 + 5x + 6 + (x - 3)(x + 4)}{x - 3}", result.print(false, false));
        }

        [TestMethod]
        public void TestNodeAddition1_coef()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            pn2.coef.numerator = 2;

            Node result = Node.Add2(pn1, pn2);
            Assert.AreEqual("x^2 + 5x + 6 + 2(x - 3)", result.print(false, false));
        }

        [TestMethod]
        public void TestNodeMultiplication_coef()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            pn2.coef.numerator = 2;

            Node result = Node.Multiply2(pn1, pn2);
            Assert.AreEqual("2(x^2 + 5x + 6)(x - 3)", result.print(false, false));

            PolyNode pn3 = new PolyNode(new Polynomial("x - 4"));
            result = Node.Multiply2(result, pn3);
            Assert.AreEqual("2(x^2 + 5x + 6)(x - 3)(x - 4)", result.print(false, false));

            ProdNode pr = result as ProdNode;
            Assert.IsTrue(pr.nChildren == 3);
        }

        [TestMethod]
        public void TestNodeAddition2_coef()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            Node frac = new FracNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 4"));

            pn3.coef.numerator = 2;

            Node result = Node.Add2(frac, pn3);
            Assert.AreEqual("\\frac{x^2 + 5x + 6 + 2(x - 3)(x + 4)}{x - 3}", result.print(false, false));
        }

        [TestMethod]
        public void TestNodeAddition1_coef2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            pn1.coef.numerator = 2;

            Node result = Node.Add2(pn1, pn2);
            Assert.AreEqual("2(x^2 + 5x + 6) + x - 3", result.print(false, false));
        }

        [TestMethod]
        public void TestNodeMultiplication_coef2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            pn1.coef.numerator = 2;

            Node result = Node.Multiply2(pn1, pn2);
            Assert.AreEqual("2(x^2 + 5x + 6)(x - 3)", result.print(false, false));

            PolyNode pn3 = new PolyNode(new Polynomial("x - 4"));
            result = Node.Multiply2(result, pn3);
            Assert.AreEqual("2(x^2 + 5x + 6)(x - 3)(x - 4)", result.print(false, false));

            ProdNode pr = result as ProdNode;
            Assert.IsTrue(pr.nChildren == 3);
        }

        [TestMethod]
        public void TestNodeAddition2_coef2()
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x2 + 5x + 6"));
            PolyNode pn2 = new PolyNode(new Polynomial("x - 3"));

            Node frac = new FracNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 4"));

            frac.coef.numerator = 2;

            Node result = Node.Add2(frac, pn3);
            Assert.AreEqual("2\\frac{x^2 + 5x + 6 + \\frac{1}{2}(x - 3)(x + 4)}{x - 3}", result.print(false, false));
        }
    }
}
