﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class PowerNode : Node
    {
        Node powered; // това, което е на степен
        Node nodePower; // ако nodePower == null
        Number numPower; // се ползва numPower

        public PowerNode()
        {
            coef = new Number(0);
            numPower = new Number(1);
        }

        public PowerNode(PowerNode src)
        {
            powered = src.powered.copy() as Node;
            nodePower = src.nodePower;
            numPower = src.numPower == null ? null : new Number(src.numPower);
            coef = new Number(src.coef);
        }

        /// <summary>
        /// Дига елемент на степен
        /// </summary>
        /// <param name="arg">Това, което ще се вдига</param>
        /// <param name="pow">Степента</param>
        public PowerNode(Node arg, Number pow)
        {
            powered = arg.copy() as Node;
            numPower = new Number(pow);
            coef = new Number(1);
        }

        public override string print(bool attach, bool brackets)
        {
            if (nodePower == null) return printNum(attach, brackets);
            else return printNodePow(attach, brackets);
        }
        /// <summary>
        /// Принтира числена степен
        /// </summary>
        /// <param name="attach">Слепване(т.е. знак и интервал)</param>
        /// <param name="brackets">Дали да е в скоби. Игнорира се, но се предава нататък</param>
        /// <returns></returns>
        private string printNum(bool attach, bool brackets)
        {
            if (numPower.isPosOne)
            {
                if (coef.isPosOne) return powered.print(attach, brackets); // реално степен нямаме
                else return coef.print(attach, false) + powered.print(false, true); // [+/-]k(...)
            }
            else if(numPower.numerator == 1) // имаме само корен
            {
                string result = coef.print(attach, false);
                if (numPower.denominator == 2) result += "\\sqrt{" + powered.print(false, false) + "}";
                else result += "\\sqrt{" + numPower.denominator + "}{" + powered.print(false, false) + "}";
                return result;
            }

            return coef.print(attach, false) + "(" + powered.print(false, false) + ")^" + numPower.print(false, true);
        }

        /// <summary>
        /// Не се поддържа засега
        /// </summary>
        /// <param name="attach"></param>
        /// <param name="brackets"></param>
        /// <returns></returns>
        private string printNodePow(bool attach, bool brackets)
        {
            throw new System.NotImplementedException("Not supported yet!");
        }

        public override object copy()
        {
            return new PowerNode(this);
        }

        public override void simplify()
        {
            return; // няма нищо за опростяване
        }

        public override void doMath()
        {
            throw new NotImplementedException("PowerNode not available yet!!!");
        }
    }
}
