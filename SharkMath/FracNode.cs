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
    class FracNode : Node
    {
        /// <summary>
        /// Числител
        /// </summary>
        Node numerator;
        /// <summary>
        /// Знаменател
        /// </summary>
        Node denominator;
        public override string print(bool attach, bool brackets)
        {
            string result = coef.print(attach, false);
            if(brackets) result += String.Format("(\\frac{{0}}{{1}})", numerator.print(false, false), denominator.print(false, false));
            else result += String.Format("\\frac{{0}}{{1}}", numerator.print(false, false), denominator.print(false, false));
            return result;
        }
    }
}
