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
            Polynomial p = new Polynomial("-x2 - 5x - 6");
            Console.WriteLine(p.print(false, true));
            Console.Read();
        }

        
    }
}
