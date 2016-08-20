using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems.Problems
{
    public class FracEquation
    {
        public DoubleExpression sides;
        public Solution solution;

        public void create(char letter, FracEquationDescriptor fed)
        {
            FracNode fn1 = new FracNode(Generator.getNode(letter, 1, fed.rootDesc), Generator.getNode(letter, 1, fed.rootDesc));
        }
    }
}
