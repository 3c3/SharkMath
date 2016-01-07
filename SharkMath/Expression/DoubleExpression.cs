using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class DoubleExpression
    {
        public Expression left, right;

        public DoubleExpression()
        {
            left = new Expression();
            right = new Expression();
        }

        public void addNode(Node node, bool choice)
        {
            left.addNode(node, choice);
            right.addNode(node, !choice);
        }

        public void fixPolynomials()
        {
            int idxLeft = -1;
            int idxRight = -1;
            for (int i = 0; i < left.nodes.Count; i++)
                if (left.nodes[i] is PolyNode)
                {
                    idxLeft = i;
                    break;
                }

            for (int i = 0; i < right.nodes.Count; i++)
                if (right.nodes[i] is PolyNode)
                {
                    idxRight = i;
                    break;
                }

            if (idxLeft != -1 && idxRight != -1)
            {
                PolyNode leftPoly = left.nodes[idxLeft] as PolyNode;
                PolyNode rightPoly = right.nodes[idxRight] as PolyNode;
                leftPoly.exchange(rightPoly);
                if (leftPoly.poly.isZero) left.nodes.RemoveAt(idxLeft);
                if (rightPoly.poly.isZero) right.nodes.RemoveAt(idxRight);
            }
        }
    }
}
