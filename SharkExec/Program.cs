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

            PolyNode pn1 = new PolyNode(p);
            PolyNode pn2 = new PolyNode(q);
            PolyNode pn3 = new PolyNode(pn2);

            pn3.coef.numerator = 2;

            Console.WriteLine(pn1.print(false, false));
            Console.WriteLine(pn2.print(false, false));

            Node sn1 = new ProdNode(pn1, pn3);
            Console.WriteLine(sn1.print(false, false));

            FracNode fn1 = new FracNode(sn1, pn2);

            Console.WriteLine(fn1.print(false, false));

            Console.Read();
        }

        
    }
}
