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
            Number a = new Number(-5, 12);
            Number b = new Number(3, 4);

            Console.WriteLine(a.print(false, false));
            Console.WriteLine(b.print(false, false));

            a -= b;
            Console.WriteLine(a.print(false, false));

            Console.Read();
        }

        
    }
}
