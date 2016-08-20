using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems.Problems
{
    public class SimpleInequation
    {
        public DoubleExpression sides;
        public Solution solution;
        public char letter;
        public string sign;

        public SimpleInequation(char letter)
        {
            this.letter = letter;
            sides = new DoubleExpression();
            solution = new Solution(letter, Solution.Type.Equation);
        }

        public void create(SimpleEquationDescriptor sed)
        {
            bool isClosed = Generator.getBool();
            char simpleSign = Generator.getBool() ? '<' : '>';

            if (isClosed) sign = simpleSign == '>' ? "\\geq" : "\\leq";
            else sign = simpleSign.ToString();

            int solutionTypeRoll = Generator.random.Next(100) + 1;
            int solutionAvailableRoll = Generator.random.Next(100) + 1;

            bool hasIrrational = solutionTypeRoll >= 100 - sed.rootDesc.pIrrational;
            bool hasSolution = solutionAvailableRoll >= sed.pNoSolution;

            if(hasSolution)
            {
                if (hasIrrational) createIrrational(sed, isClosed, simpleSign);
                else createRational(sed, isClosed, simpleSign);
            }
            else
            {
                if (hasIrrational) createIrrationalNoSolution(sed, isClosed, simpleSign);
                else createRationalNoSolution(sed, isClosed, simpleSign);
            }
        }

        private void createRational(SimpleEquationDescriptor sed, bool isClosed, char simpleSign)
        {
            IntervalPoint[] points = new IntervalPoint[sed.power];

            Polynomial basePoly = new Polynomial("1");

            for(int i = 0; i < sed.power; i++)
            {
                Number root = Generator.getNumber(sed.rootDesc);
                points[i] = new IntervalPoint(root, false);

                basePoly *= new Polynomial(letter, root);
            }

            sides.left.addNode(new PolyNode(basePoly));
            solution = new Solution(letter, Solution.Type.Inequation);
            solution.parts = Interval.constructIntervals(isClosed, simpleSign, points).ToList<IPrintable>();
        }

        private void createIrrational(SimpleEquationDescriptor sed, bool isClosed, char simpleSign)
        {
            if (sed.power < 2) throw new Exception("Canno create an irrational inequation with power < 2!");
            Number a, b, c;
            Generator.createNonSquareDPosA(out a, out b, out c, sed.rootDesc);

            Node[] roots = Generator.getRoots(a, b, c);

            IntervalPoint[] points = new IntervalPoint[sed.power];
            points[0] = new IntervalPoint(roots[0], false);
            points[1] = new IntervalPoint(roots[1], false);

            Polynomial basePoly = new Polynomial(letter, a, b, c);
            for (int i = 2; i < sed.power; i++)
            {
                Number root = Generator.getNumber(sed.rootDesc);
                points[i] = new IntervalPoint(root, false);

                basePoly *= new Polynomial(letter, root);
            }

            sides.left.addNode(new PolyNode(basePoly));
            solution = new Solution(letter, Solution.Type.Inequation);
            solution.parts = Interval.constructIntervals(isClosed, simpleSign, points).ToList<IPrintable>();

        }

        private void createRationalNoSolution(SimpleEquationDescriptor sed, bool isClosed, char simpleSign)
        {
            Number k = Generator.getNumber(sed.rootDesc);
            sides.left.addNode(new PolyNode(new Polynomial(k)));
            if (simpleSign == '>') k.numerator += Generator.random.Next(10);
            else k.numerator -= Generator.random.Next(10);
            sides.right.addNode(new PolyNode(new Polynomial(k)));
        }

        private void createIrrationalNoSolution(SimpleEquationDescriptor sed, bool isClosed, char simpleSign)
        {
            Number a, b, c;
            Generator.createNegativeDPosA(out a, out b, out c, sed.rootDesc);

            if(simpleSign == '>')
            { // ако условието е за положителност, правим израза да е винаги отрицателен
                a.flipSign();
                b.flipSign();
                c.flipSign();
            }

            sides.left.addNode(new PolyNode(new Polynomial(letter, a, b, c)));
        }

        public string print()
        {
            return sides.left.print() + ' ' + sign + ' ' + sides.right.print();
        }
    }
}
