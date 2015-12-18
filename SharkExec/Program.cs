using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath;

namespace SharkExec
{
    class Program
    {
        static void Main(string[] args)
        {
            PolyNode pn1 = new PolyNode(new Polynomial("x + 5"));
            PolyNode pn2 = new PolyNode(new Polynomial("x + 3"));

            ProdNode prn1 = new ProdNode(pn1, pn2);

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));

            Expression result = new Expression();

            result.addNode(prn1, true);
            result.addNode(pn3, true);

            Console.WriteLine(result.print());

            Console.Read();
        }

        
    }
}
