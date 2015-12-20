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

            sed.rootDesc.maxDenominator = 3;
            sed.rootDesc.minDenominator = 1;
            sed.rootDesc.maxNumerator = 5;
            sed.rootDesc.minNumerator = 1;

            sed.rootDesc.pIrrational = 50;
            sed.rootDesc.pNatural = 50;
            sed.rootDesc.pRational = 0;
            sed.power = 2;

            SimpleEquation se = Generator.getEquation('x', sed);

            Console.WriteLine(se.print());
            Console.WriteLine(se.solution.print());

            Console.Read();
        }

        
    }
}
