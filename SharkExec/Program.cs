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
            PolyNode pon = new PolyNode(new Polynomial("x + 1"));
            PowerNode pn = new PowerNode(pon, new Number(2));
            pn.doMath();
            Node res = pn.ToNode();
            Console.WriteLine(res.print(false, false));

            SimpleEquationDescriptor sed = new SimpleEquationDescriptor();

            sed.rootDesc.maxDenominator = 3;
            sed.rootDesc.minDenominator = 1;
            sed.rootDesc.maxNumerator = 5;
            sed.rootDesc.minNumerator = 1;

            sed.rootDesc.pIrrational = 50;
            sed.rootDesc.pNatural = 50;
            sed.rootDesc.pRational = 0;
            sed.power = 2;

            sed.maxVisualPower = 2;
            sed.minTransformations = 1;
            sed.maxTransformations = 1;

            sed.elemCoefDesc.maxDenominator = 1;
            sed.elemCoefDesc.minDenominator = 1;
            sed.elemCoefDesc.maxNumerator = 5;
            sed.elemCoefDesc.minNumerator = 1;
            sed.elemCoefDesc.pNatural = 100;

            for(int i = 0; i < 3; i++)
            {
                SimpleEquation se = Generator.getEquation('x', sed);

                Console.WriteLine(se.print());
                se.fixPolynomials();
                Console.WriteLine(se.print());
                Console.WriteLine(se.solution.print());

                Console.WriteLine();
            }            

            Console.Read();
        }

        
    }
}
