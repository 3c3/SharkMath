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
    public abstract class Node : IPrintable, ICopiable, ISimplifiable, IEvaluable
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

        public abstract double eval();

        public Node()
        {
            coef = new Number(0);
        }

        /// <summary>
        /// Прави пълно копие
        /// </summary>
        /// <returns></returns>
        public abstract object copy();

        /// <summary>
        /// Изнася множител
        /// </summary>
        public abstract void simplify();

        /// <summary>
        /// Извършва пресмятания
        /// </summary>
        public abstract void doMath();

        /// <summary>
        /// Обръща знака
        /// </summary>
        public void flipSign()
        {
            coef.numerator *= -1;
        }

        /// <summary>
        /// Използва се за да преобразува от съствани към прости елементи
        /// </summary>
        /// <returns>Един елемент, ако текущия е сума/произведение само 1 елемент, иначе this</returns>
        public virtual Node ToNode()
        {
            return this;
        }

        /// <summary>
        /// Умножава два елемента(НЕ пресмята). Не променя аргументите
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="compact">Да се опитаме ли да избегнем създаването на нови елементи</param>
        /// <returns>Произведението като нов елемент</returns>
        public static Node Multiply2(Node arg1, Node arg2, bool compact = true)
        {
            if(!compact)
            { // най-лесното, просто правим произведение
                return new ProdNode(arg1.copy() as Node, arg2.copy() as Node);
            }

            // трябва резултата да е компактен
            // първо проверяваме дали единият аргумент е дроб

            if(arg2 is FracNode)
            { // винаги дробта е в arg1
                Node tmp = arg1;
                arg1 = arg2;
                arg2 = tmp;
            }

            if(arg1 is FracNode)
            {
                FracNode resultNode = arg1.copy() as FracNode;
                resultNode.Multiply(arg2);
                return resultNode;
            }

            // после дали е произведение

            if (arg2 is ProdNode)
            { // винаги arg1
                Node tmp = arg1;
                arg1 = arg2;
                arg2 = tmp;
            }

            if(arg1 is ProdNode)
            {
                ProdNode result = arg1.copy() as ProdNode;
                result.Multiply(arg2);
                return result;
            }

            // когато нямаме нито дроб, нито произведение, създаваме ново
            return new ProdNode(arg1.copy() as Node, arg2.copy() as Node);
        }

        /// <summary>
        /// Събира 2 елемента. Не пресмята. Не променя аргументи.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="compact">Да се опитаме ли да избегнем създаването на нови елементи</param>
        /// <returns>Сбора като нов елемент</returns>
        public static Node Add2(Node arg1, Node arg2, bool compact = true)
        {   // ако не искаме компактно просто връщаме нова сума
            if (!compact) return new SumNode(arg1.copy() as Node, arg2.copy() as Node);

            // първо проверяваме за дроби, защото се са специален случай
            if (arg2 is FracNode)
            { // винаги дробта е в arg1
                Node tmp = arg1;
                arg1 = arg2;
                arg2 = tmp;
            }

            if(arg1 is FracNode)
            {
                FracNode resultNode = arg1.copy() as FracNode;
                resultNode.Add(arg2);
                return resultNode;
            }

            // после за суми
            if (arg2 is SumNode)
            { // винаги arg1
                Node tmp = arg1;
                arg1 = arg2;
                arg2 = tmp;
            }

            if (arg1 is SumNode)
            {
                SumNode result = arg1.copy() as SumNode;
                result.Add(arg2);
                return result;
            }

            // и ако нито едно от двете не присъства, просто правим нова сума
            return new SumNode(arg1.copy() as Node, arg2.copy() as Node);
        }
    }
}
