using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath;
using SharkMath.MathProblems;

namespace TestGUI
{
    public enum ProblemType { Equation, Inequation }
    public class ProblemGroup
    {
        public ReducedSEquationDescriptor desc;
        public int count;
        public ProblemType type;

        public ProblemGroup(ReducedSEquationDescriptor rsed, int n, ProblemType pt)
        {
            desc = rsed;
            count = n;
            type = pt;
        }

    }
}
