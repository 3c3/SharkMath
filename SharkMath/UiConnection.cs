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

        public static UiData[] getFracEquations(int n, ReducedFEquationDescriptor desc)
        {
            throw new NotImplementedException();
            UiData[] result = new UiData[n];

           /* for (int i = 0; i < n; i++)
            {
                SimpleEquation se = MathProblems.Generator.getEquation(desc.letter, desc.toFEquationDescriptor());
                result[i] = new UiData(se.print(), se.solution.print());
            }*/

            return result;
        }

        public static UiData[] getInequations(int n, ReducedSEquationDescriptor desc)
        {
            UiData[] result = new UiData[n];

            for (int i = 0; i < n; i++)
            {
                SimpleInequation se = MathProblems.Generator.getInequation(desc.letter, desc.toSEquationDescriptor());
                result[i] = new UiData(se.print(), se.solution.print());
            }

            return result;
        }
    }
}
