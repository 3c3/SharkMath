using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath.MathProblems;
using SharkMath.MathProblems.Problems;

namespace SharkMath
{
    public abstract class UiConnection
    {
        public static UiData[] getEquations(int n, ReducedSEquationDescriptor desc)
        {
            UiData[] result = new UiData[n];

            for (int i = 0; i < n; i++)
            {
                SimpleEquation se = MathProblems.Generator.getEquation(desc.letter, desc.toSEquationDescriptor());
                result[i] = new UiData(se.print(), se.solution.print());
            }

            return result;
        }
    }
}
