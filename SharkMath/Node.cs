using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Основният клас за сложни изрази. Просто число
    /// </summary>
    public abstract class Node : IPrintable
    {
        /// <summary>
        /// Коефициентът
        /// </summary>
        public Number coef;
        public abstract string print(bool attach, bool brackets);
    }
}
