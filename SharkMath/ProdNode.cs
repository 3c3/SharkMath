using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class ProdNode : Node, IMultipliable
    {
        List<Node> children;

        /// <summary>
        /// за unit test/debug
        /// </summary>
        public int nChildren
        {
            get
            {
                return children.Count;
            }
        }

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

        /// <summary>
        /// Създава произведение по 2 елемента. Взима впредвид коефициентите им.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        public ProdNode(Node n1, Node n2)
        {
            children = new List<Node>(2);
            children.Add(n1.copy() as Node);
            children.Add(n2.copy() as Node);

            coef = n1.coef * n2.coef;

            children[0].coef.makeOne();
            children[1].coef.makeOne();
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

        public override void simplify()
        {
            foreach(Node node in children)
            {
                node.simplify();
                coef.MultiplyBy(node.coef);
                node.coef.makeOne();
            }
        }

        public override void doMath()
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].doMath();
                children[i] = children[i].ToNode(); // в случай че стане сума/произведение от един елемент
            }

            List<PolyNode> polyNodes = new List<PolyNode>(children.Count);
            List<Node> nonPolyNodes = new List<Node>(children.Count);
            
            foreach(Node n in children)
            {
                if (n is PolyNode) polyNodes.Add(n as PolyNode);
                else nonPolyNodes.Add(n);
            }

            if (polyNodes.Count < 2) return; // нищо за правене

            Polynomial product = polyNodes[0].poly * polyNodes[1].poly;
            for (int i = 2; i < polyNodes.Count; i++) product *= polyNodes[i].poly;

            nonPolyNodes.Add(new PolyNode(product));
            children = nonPolyNodes;
        }

        /// <summary>
        /// Добавя към текущото произведение. НЕ ползвай с FracNode!
        /// </summary>
        /// <param name="arg">Това, по което умножаваме. Не се променя</param>
        public void Multiply(Node arg)
        {
            if(arg is ProdNode) // Перфектно, просто сливаме 2 произведения
            {
                ProdNode pn = arg as ProdNode;
                coef.MultiplyBy(pn.coef);
                pn.children.ForEach(n => children.Add(n.copy() as Node));
                return;
            }

            coef.MultiplyBy(arg.coef); // в общия случай
            Node copyNode = arg.copy() as Node; // добавяме само 1 дете
            copyNode.coef.makeOne();
            children.Add(copyNode);
        }

        /// <summary>
        /// Ако съдържа само 1 елемент, го връща(умножават се коефициентите).
        /// Ако има повече от 1 елемент - връща себе си
        /// Ако няма елементи - връща коефициента като PolyNode
        /// </summary>
        /// <returns></returns>
        public override Node ToNode()
        {
            if (children.Count == 0) return new PolyNode(coef);
            if (children.Count == 1)
            {
                children[0].coef.MultiplyBy(coef);
                return children[0];
            }
            return this;
        }
    }
}
