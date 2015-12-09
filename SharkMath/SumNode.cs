using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class SumNode : Node
    {
        List<Node> children;

        /// <summary>
        /// Нулиращ конструктор
        /// </summary>
        public SumNode()
        {
            children = new List<Node>();
            coef = new Number(0);
        }

        /// <summary>
        /// Copy конструктор
        /// </summary>
        /// <param name="src"></param>
        public SumNode(SumNode src)
        {
            children = new List<Node>(src.children.Count);
            src.children.ForEach(n => children.Add(n.copy() as Node));
            coef = new Number(src.coef);
        }

        /// <summary>
        /// Създава сума от 2 елемента
        /// </summary>
        /// <param name="n1">Първи елемент</param>
        /// <param name="n2">Втори елемент</param>
        public SumNode(Node n1, Node n2)
        {
            children = new List<Node>(2);
            children.Add(n1.copy() as Node);
            children.Add(n2.copy() as Node);
            coef = new Number(1);
        }

        public override string print(bool attach, bool brackets)
        {
            string result = "";

            if (!coef.isPosOne)
            {
                // при коеф. различен от 1 задължително имаме скоби
                result += coef.print(attach, false);

                result += "(";
                for (int i = 0; i < children.Count; i++) result += children[i].print(i > 0, false);
                result += ")";
                return result;
            }

            // коефициентът е +1, така че го игнорираме

            if (attach && brackets) result += " + ";

            if (brackets)
            {
                result += "(";
                for (int i = 0; i < children.Count; i++) result += children[i].print(i > 0, false);
                result += ")";
                return result;
            }

            for (int i = 0; i < children.Count; i++) result += children[i].print(i > 0, false);

            return result;
        }

        public override object copy()
        {
            return new SumNode(this);
        }
    }
}
