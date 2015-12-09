using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Основният клас за сложни изрази.
    /// </summary>
    public abstract class Node : IPrintable, ICopiable, ISimplifiable
    {
        /// <summary>
        /// Коефициентът
        /// </summary>
        public Number coef;

        public bool isNegative
        {
            get
            {
                return coef.isNegative;
            }
        }

        /// <summary>
        /// Принтира елемента
        /// </summary>
        /// <param name="attach">При true, винаги има знак и интервал. При false, има само долепен -, ако трябва</param>
        /// <param name="brackets">Дали да показва +1</param>
        /// <returns></returns>
        public abstract string print(bool attach, bool brackets);

        public Node()
        {
            coef = new Number(0);
        }

        public abstract object copy();

        public abstract void simplify();

        public void flipSign()
        {
            coef.numerator *= -1;
        }
    }
}
