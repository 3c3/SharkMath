using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    class Expression : IPrintable
    {
        public List<Node> nodes;

        /// <summary>
        /// Добавя елемент към израза
        /// </summary>
        /// <param name="node">Елементът - не се променя</param>
        /// <param name="calculate">Дали да го добави във суров вид, или пресметнат(и да слее
        /// със съществуващ, ако е възможно)</param>
        public void addNode(Node node, bool calculate)
        {
            if(!calculate)
            {
                nodes.Add(node.copy() as Node);
                return;
            }

            if (node is FracNode) throw new NotImplementedException("Cannot add fractions with calculate yet!");

            for (int i = 0; i < nodes.Count; i++)
            {
                if(nodes[i] is IAddable)
                {
                    IAddable iad = nodes[i] as IAddable;
                    iad.Add(node);
                    return;
                }
                if(nodes[i] is PolyNode)
                {
                    Node result = Node.Add2(nodes[i], node);
                    result.doMath();
                    result = result.ToNode();

                    nodes.RemoveAt(i);
                    nodes.Add(result);
                    return;
                }
            }

            nodes.Add(node.copy() as Node);            
        }

        public string print(bool attach, bool brackets)
        {
            if (nodes.Count == 0) return "0";

            string result = nodes[0].print(false, false);
            for (int i = 1; i < nodes.Count; i++) result += nodes[i].print(true, false);
            return result;
        }
    }
}
