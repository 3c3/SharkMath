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
            ReducedSEquationDescriptor rsed = new ReducedSEquationDescriptor();
            rsed.letter = 'x';
            rsed.power = 2;

            SimpleInequation sin = new SimpleInequation(rsed.letter);
            sin.createRational(rsed.toSEquationDescriptor());

            UiData[] stuff = UiConnection.getInequations(5, rsed);

            foreach(UiData ud in stuff)
            {
                Console.WriteLine(ud.problem);
                Console.WriteLine(ud.solution);
                Console.WriteLine();
            }

            Console.ReadLine();
        }        
    }
}
