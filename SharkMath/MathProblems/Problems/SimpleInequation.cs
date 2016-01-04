using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems.Problems
{
    public class SimpleInequation
    {
        public Expression left, right;
        public Solution solution;
        public char letter;

        public SimpleInequation(char letter)
        {
            this.letter = letter;
            left = new Expression();
            right = new Expression();
            solution = new Solution(letter, Solution.Type.Equation);
        }
    }
}
