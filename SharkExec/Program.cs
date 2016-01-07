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
            rsed.pIrrational = 50;
            rsed.minTransformations = 1;
            rsed.maxTransformations = 2;
            rsed.maxVisualPower = 2;

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
