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
        public string sign;

        public SimpleInequation(char letter)
        {
            this.letter = letter;
            left = new Expression();
            right = new Expression();
            solution = new Solution(letter, Solution.Type.Equation);
        }

        public void createRational(SimpleEquationDescriptor sed)
        {
            IntervalPoint[] points = new IntervalPoint[sed.power];

            bool isClosed = Generator.random.Next() % 2 == 0;
            char simpleSign = Generator.random.Next() % 2 == 0 ? '>' : '<';

            if (isClosed) sign = simpleSign == '>' ? "//geq" : "//leq";
            else sign = simpleSign.ToString();

            Polynomial basePoly = new Polynomial("1");

            for(int i = 0; i < sed.power; i++)
            {
                Number root = Generator.getNumber(sed.rootDesc);
                points[i] = new IntervalPoint(root, false);

                basePoly *= new Polynomial(letter, root);
            }

            left.addNode(new PolyNode(basePoly));
            solution = new Solution(letter, Solution.Type.Inequation);
            solution.parts = Interval.constructIntervals(isClosed, simpleSign, points).ToList<IPrintable>();
        }

        public string print()
        {
            return left.print() + ' ' + sign + ' ' + right.print();
        }
    }
}
