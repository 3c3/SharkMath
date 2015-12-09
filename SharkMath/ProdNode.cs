using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class ProdNode : Node
    {
        List<Node> children;

        public ProdNode()
        {
            children = new List<Node>();
            coef = new Number(0);
        }

        public ProdNode(ProdNode src)
        {
            children = new List<Node>(src.children.Count);
            src.children.ForEach(n => children.Add(n.copy() as Node));
            coef = new Number(src.coef);
        }

        public ProdNode(Node n1, Node n2)
        {
            children = new List<Node>(2);
            children.Add(n1.copy() as Node);
            children.Add(n2.copy() as Node);
            coef = new Number(1);
        }
        /// <summary>
        /// Принтира произведение
        /// </summary>
        /// <param name="attach">Дали да се слепва, т.е. знак с интервали</param>
        /// <param name="brackets">Игнорира се</param>
        /// <returns></returns>
        public override string print(bool attach, bool brackets)
        {
            string result = "";

            if (!coef.isPosOne)
            {
                // при коеф. различен от 1 задължително имаме скоби
                result += coef.print(attach, false);
            }
            else if (attach) result += " + "; // коефициентът е +1, така че го игнорираме

            for (int i = 0; i < children.Count; i++) result += "(" + children[i].print(false, false) + ")";

            return result;
        }

        public override object copy()
        {
            return new ProdNode(this);
        }
    }
}
