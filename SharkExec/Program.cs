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
            SimpleEquationDescriptor sed = new SimpleEquationDescriptor();

            sed.rootDesc.maxDenominator = 1;
            sed.rootDesc.minDenominator = 1;
            sed.rootDesc.maxNumerator = 7;
            sed.rootDesc.minNumerator = 1;

            sed.rootDesc.pIrrational = 100;
            sed.power = 2;

            SimpleEquation se = Generator.getEquation('x', sed);

            Console.WriteLine(se.print());
            Console.WriteLine(se.solution.print());

            Console.Read();
        }

        
    }
}
