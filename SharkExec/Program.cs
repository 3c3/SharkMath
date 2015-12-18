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

            PolyNode pn3 = new PolyNode(new Polynomial("x + 1"));

            Expression result = new Expression();

            Console.WriteLine(result.print(false, false));

            result.doMath();
            result = result.ToNode();

            Console.WriteLine(result.print(false, false));

            Console.Read();
        }

        
    }
}
