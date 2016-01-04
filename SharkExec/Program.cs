using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath;
using SharkMath.MathProblems;
using SharkMath.MathProblems.Problems;

namespace SharkExec
{
    class Program
    {
        static void Main(string[] args)
        {
            Interval i1 = new Interval(new Number(-1), new Number(5), true, false);
            Console.WriteLine(i1.print(false, false));

            Console.ReadLine();
        }        
    }
}
