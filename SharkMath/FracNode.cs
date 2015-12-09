using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Клас за дроб
    /// </summary>
    public class FracNode : Node
    {
        /// <summary>
        /// Числител
        /// </summary>
        Node numerator;
        /// <summary>
        /// Знаменател
        /// </summary>
        Node denominator;

        /// <summary>
        /// Прави празна дроб 0/1
        /// </summary>
        public FracNode()
        {
            numerator = new PolyNode();
            denominator = new PolyNode(new Polynomial(new Number(1))); // не искаме 0/0!
        }

        /// <summary>
        /// Copy конструктор
        /// </summary>
        /// <param name="src">Оригинала</param>
        public FracNode(FracNode src)
        {
            numerator = src.numerator.copy() as Node;
            denominator = src.denominator.copy() as Node;
            coef = new Number(src.coef);
        }

        /// <summary>
        /// Прави дроб по 2 елемента
        /// </summary>
        /// <param name="num">Числителя</param>
        /// <param name="denom">Знаменателя</param>
        public FracNode(Node num, Node denom)
        {
            numerator = num.copy() as Node;
            denominator = denom.copy() as Node;
            coef = new Number(1);
        }

        public override string print(bool attach, bool brackets)
        {
            string result = coef.print(attach, false);

            bool numNeg = numerator.isNegative;
            bool denNeg = numerator.isNegative;

            if (numNeg) numerator.flipSign();
            if (denNeg) denominator.flipSign();

            if(brackets) result += String.Format("(\\frac{{{0}}}{{{1}}})", numerator.print(false, false), denominator.print(false, false));
            else result += String.Format("\\frac{{{0}}}{{{1}}}", numerator.print(false, false), denominator.print(false, false));

            if (numNeg) numerator.flipSign();
            if (denNeg) denominator.flipSign();

            return result;
        }

        public override object copy()
        {
            return new FracNode(this);
        }

        public override void simplify()
        {
            numerator.simplify();
            denominator.simplify();

            coef *= numerator.coef;
            coef /= denominator.coef;

            numerator.coef.makeOne();
            denominator.coef.makeOne();
        }
    }
}
