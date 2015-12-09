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
            Polynomial p = new Polynomial("x - 1");
            Polynomial q = new Polynomial("x2 + x + 1");

            Node pn1 = new PolyNode(p);
            Node pn2 = new PolyNode(q);
            Node pn3 = pn2.copy() as Node;

            pn3.coef.numerator = -1;

            Console.WriteLine(pn1.print(false, false));
            Console.WriteLine(pn2.print(false, false));

            Node sn1 = new ProdNode(pn1, pn3);
            Console.WriteLine(sn1.print(false, false));

            Node fn1 = new FracNode(sn1, pn2);

            Console.WriteLine(fn1.print(false, false));

            Console.Read();
        }

        
    }
}
