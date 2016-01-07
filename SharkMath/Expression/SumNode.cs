using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class SumNode : Node, IAddable
    {
        List<Node> children;

        #region Конструктори

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

        #endregion

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

            if (attach) result += " + ";

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

        /// <summary>
        /// Ако първият елемент е със знак -, обръща значците на всички и коефициентът на сумата
        /// </summary>
        public override void simplify()
        {
            if (children.Count == 0) return;

            for(int i = 0; i < children.Count; i++)
            {
                children[i].simplify();
                children[i] = children[i].ToNode();
            }

            if(children[0].coef.isNegative)
            {
                children.ForEach(n => n.flipSign());
                coef.numerator *= -1;
            }
        }

        public override double eval()
        {
            double result = 0;
            children.ForEach(n => result += n.coef.eval());
            return result * coef.eval();
        }

        public override void doMath()
        {           
            for (int i = 0; i < children.Count; i++)
            {
                children[i].coef.MultiplyBy(coef);
                children[i].doMath();
                children[i] = children[i].ToNode(); // в случай че стане сума/произведение от един елемент
            }

            coef.makeOne();

            List<PolyNode> polyNodes = new List<PolyNode>(children.Count);
            List<Node> nonPolyNodes = new List<Node>(children.Count);

            foreach (Node n in children)
            {
                if (n is PolyNode) polyNodes.Add(n as PolyNode);
                else nonPolyNodes.Add(n);
            }

            if (polyNodes.Count < 2) return; // нищо за правене

            polyNodes.ForEach(pn => pn.poly.MultiplyByNumber(pn.coef));

            Polynomial product = polyNodes[0].poly + polyNodes[1].poly;
            for (int i = 2; i < polyNodes.Count; i++) product += polyNodes[i].poly;

            nonPolyNodes.Add(new PolyNode(product));
            children = nonPolyNodes;
            simplify();
        }

        /// <summary>
        /// Добавя елемента към текущата сума. НЕ ползвай с FracNode!
        /// </summary>
        /// <param name="arg">Добавяемото, не се променя</param>
        public void Add(Node arg)
        {
            Number modCoef = arg.coef / coef; // нагласяме коефициентите

            if(arg is SumNode) // ако елемента е сума
            { // сливаме елементите на двете суми
                SumNode sn = arg as SumNode;

                if (modCoef.isPosOne) sn.children.ForEach(n => children.Add(n.copy() as Node)); // нищо не променяме по елементите, защото
                else                                                                            // коеф. им са еднакви
                {
                    foreach(Node node in sn.children)
                    { // не са еднаки, затова коригираме
                        Node copyNode = node.copy() as Node;
                        copyNode.coef.MultiplyBy(modCoef); 
                        children.Add(copyNode);
                    }
                }
                return;
            }

            // елемента не е сума, затова просто го добавяме като дете
            Node cpyNode = arg.copy() as Node;
            cpyNode.coef.MultiplyBy(modCoef);
            children.Add(cpyNode);
        }

        /// <summary>
        /// Ако съдържа само 1 елемент, го връща(умножават се коефициентите).
        /// Ако има повече от 1 елемент - връща себе си
        /// Ако няма елементи - връща 0
        /// </summary>
        /// <returns></returns>
        public override Node ToNode()
        {
            if (children.Count == 0) return new PolyNode();
            if(children.Count == 1)
            {
                children[0].coef.MultiplyBy(coef);
                return children[0];
            }
            return this;
        }
    }
}
