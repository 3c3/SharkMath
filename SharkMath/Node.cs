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
    public class Node : IPrintable, ICopiable
    {
        /// <summary>
        /// Коефициентът
        /// </summary>
        public Number coef;

        /// <summary>
        /// Принтира число
        /// </summary>
        /// <param name="attach">При true, винаги има знак + интервал. При false, има само долепен -, ако трябва</param>
        /// <param name="showOne">Дали да показва +1</param>
        /// <returns></returns>
        public virtual string print(bool attach, bool showOne)
        {
            return coef.print(attach, showOne);
        }

        /// <summary>
        /// Нулира
        /// </summary>
        public Node()
        {
            coef = new Number(0);
        }

        /// <summary>
        /// Copy конструктор
        /// </summary>
        /// <param name="src">Това, което копираме</param>
        public Node(Node src)
        {
            coef = new Number(src.coef);
        }

        public virtual object copy()
        {
            return new Node(this);
        }
    }
}
