using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath.MathProblems.Problems;

namespace SharkMath.MathProblems
{
    public class Generator
    {
        public static Random random = new Random();

        /// <summary>
        /// Връша рационално число
        /// </summary>
        /// <param name="cd">описателя за числото. pIrational се игнорира</param>
        /// <returns></returns>
        public static Number getNumber(CoefDescriptor cd)
        {
            int typeRoll = random.Next(1, 101); // 1-100

            if (typeRoll <= cd.pNatural) return new Number(random.Next(cd.minNumerator, cd.maxNumerator + 1));
            return new Number(random.Next(cd.minNumerator, cd.maxNumerator + 1), random.Next(cd.minDenominator, cd.maxDenominator + 1));
        }

        public static void setNumber(Number num, CoefDescriptor cd)
        {
            int typeRoll = random.Next(1, 101); // 1-100

            if (typeRoll <= cd.pNatural) num.set(random.Next(cd.minNumerator, cd.maxNumerator + 1));
            else num.set(random.Next(cd.minNumerator, cd.maxNumerator + 1), random.Next(cd.minDenominator, cd.maxDenominator + 1));
        }

        public static Number getD(Number a, Number b, Number c)
        {
            Number part = a * c;
            part.MultiplyBy(4);
            return b * b - part;
        }

        public static void createNonSquareD(out Number a, out Number b, out Number c, CoefDescriptor cd)
        {
            a = new Number();
            b = new Number();
            c = new Number();

            while(true)
            {
                setNumber(a, cd);
                setNumber(b, cd);
                setNumber(c, cd);
                Number d = getD(a, b, c);
                if (!d.isNegative && d.isSquare() == false) return;
            }
        }

        public static void createNegativeD(out Number a, out Number b, out Number c, CoefDescriptor cd)
        {
            a = new Number();
            b = new Number();
            c = new Number();

            while (true)
            {
                setNumber(a, cd);
                setNumber(b, cd);
                setNumber(c, cd);
                Number d = getD(a, b, c);
                if (d.isNegative) return;
            }
        }

        public static Node[] getRoots(Number a, Number b, Number c)
        {
            a = new Number(a);
            b = new Number(b);
            c = new Number(c);

            Number d = getD(a, b, c); // намираме дискриминантата

            b.flipSign(); // правим -b

            PowerNode sqRoot = new PowerNode(new PolyNode(d), new Number(1, 2)); // правим корен от дискриминантата
            sqRoot.simplify(); // извеждаме коефициент

            a.MultiplyBy(2);
            Number g = Number.gcd(Number.gcd(sqRoot.coef, b), a); // търсим НОД на -b, sqrt(d) и 2*a

            if(!g.isOne)
            {
                a.DivideBy(g);
                b.DivideBy(g);
                sqRoot.coef.DivideBy(g);

                if(a.isOne) // съкращава се напълно
                {
                    Node[] result = new Node[2];
                    result[1] = new SumNode(new PolyNode(b), sqRoot);

                    sqRoot.flipSign();
                    result[0] = new SumNode(new PolyNode(b), sqRoot);
                    return result;
                }
            }

            PolyNode denom = new PolyNode(new Polynomial(a)); // не се е съкратило, трябва знаменател

            SumNode sum1 = new SumNode(new PolyNode(b), sqRoot); // -b + sqrt(d)
            sqRoot.flipSign();
            SumNode sum2 = new SumNode(new PolyNode(b), sqRoot); // -b - sqrt(d)

            Node[] _result = new Node[2];
            _result[1] = new FracNode(sum1, denom);
            _result[0] = new FracNode(sum2, denom);

            return _result;
        }

        public static SimpleEquation getEquation(char letter, SimpleEquationDescriptor sed)
        {
            SimpleEquation se = new SimpleEquation(letter);
            se.create(sed);
            return se;
        }
    }
}
