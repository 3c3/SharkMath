using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems.Problems
{
    public class SimpleEquation
    {
        public Expression left, right;
        public Solution solution;
        public char letter;

        public SimpleEquation(char letter)
        {
            this.letter = letter;
            left = new Expression();
            right = new Expression();
            solution = new Solution(letter, Solution.Type.Equation);
        }

        #region Създаване

        private void createRational(SimpleEquationDescriptor sed)
        { // образуваме и пресмятаме (x-x1)(x-x2).... = 0
            Number root = Generator.getNumber(sed.rootDesc);
            Polynomial basePoly = new Polynomial(letter, root);
            solution.parts.Add(root);

            for(int i = 1; i < sed.power; i++)
            {
                root = Generator.getNumber(sed.rootDesc);
                Polynomial tmp = new Polynomial(letter, root);
                basePoly *= tmp;
                solution.parts.Add(root);
            }

            left.addNode(new PolyNode(basePoly));
        }

        private void createIrrational(SimpleEquationDescriptor sed)
        { // създаваме един множител с ирационални корени, а след това ако трябва - добавяме с рационални
            if (sed.power < 2) throw new Exception("Canno create an irrational with power < 2!");
            Number a, b, c;
            Generator.createNonSquareD(out a, out b, out c, sed.rootDesc);

            Node[] roots = Generator.getRoots(a, b, c);
            solution.parts.Add(roots[0]);
            solution.parts.Add(roots[1]);

            Polynomial basePoly = new Polynomial(letter, a, b, c);
            for(int i = 2; i < sed.power; i++)
            {
                Number root = Generator.getNumber(sed.rootDesc);
                Polynomial tmp = new Polynomial(letter, root);
                basePoly *= tmp;
                solution.parts.Add(root);
            }

            left.addNode(new PolyNode(basePoly));
        }

        private void createNoSolutionRational(SimpleEquationDescriptor sed)
        {
            left.addNode(new PolyNode(Generator.getNumber(sed.rootDesc))); // 0x = b, b!=0
        }

        private void createNoSolutionIrrational(SimpleEquationDescriptor sed)
        {
            Number a, b, c;
            Generator.createNegativeD(out a, out b, out c, sed.rootDesc);
            left.addNode(new PolyNode(new Polynomial(letter, a, b, c)));
        }

        public void create(SimpleEquationDescriptor sed)
        {
            int solutionBorder = 100 - sed.pNoRealSolutions - sed.pNoSolution;
            int solutionRoll = Generator.random.Next(100) + 1;

            // [solutions] [no solution] [no real solution]
            // в който интервал попадне Roll, такова е уравнението

            if (solutionRoll <= solutionBorder)
            {
                int typeRoll = Generator.random.Next(100) + 1;
                if (typeRoll <= sed.rootDesc.pNatural + sed.rootDesc.pRational) createRational(sed);
                else createIrrational(sed);
            }
            else if (solutionRoll <= sed.pNoSolution) createNoSolutionRational(sed);
            else createNoSolutionIrrational(sed);
        }

        #endregion

        public void fixPolynomials()
        {
            int idxLeft = -1;
            int idxRight = -1;
            for(int i = 0; i < left.nodes.Count; i++)
                if(left.nodes[i] is PolyNode)
                {
                    idxLeft = i;
                    break;
                }

            for (int i = 0; i < right.nodes.Count; i++)
                if (right.nodes[i] is PolyNode)
                {
                    idxRight = i;
                    break;
                }

            if (idxLeft != -1 && idxRight !=-1)
            {
                PolyNode leftPoly = left.nodes[idxLeft] as PolyNode;
                PolyNode rightPoly = right.nodes[idxRight] as PolyNode;
                leftPoly.exchange(rightPoly);
                if (leftPoly.poly.isZero) left.nodes.RemoveAt(idxLeft);
                if (rightPoly.poly.isZero) right.nodes.RemoveAt(idxRight);
            }
        }

        public string print()
        {
            return left.print() + " = " + right.print();
        }
    }
}
