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
            Console.WriteLine(p.print(false, false));
            Console.WriteLine(q.print(false, false));
            Polynomial c = p * q;
            Console.WriteLine(c.print(false, false));
            Console.Read();
        }

        
    }
}
