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

            Console.WriteLine(pn1.print(false, false));
            Console.WriteLine(pn2.print(false, false));

            SumNode sn1 = new SumNode(pn1, pn2);
            Console.WriteLine(sn1.print(false, false));

            FracNode fn1 = new FracNode(sn1, pn2);

            Console.WriteLine(fn1.print(false, false));

            Console.Read();
        }

        
    }
}
