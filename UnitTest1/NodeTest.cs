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
    }
}
