using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class PolyNode : Node
    {
        public Polynomial poly;

        public PolyNode()
        {
            coef = new Number(0);
            poly = new Polynomial();
        }

        public PolyNode(Polynomial srcPoly)
        {
            coef = new Number(1);
            poly = new Polynomial(srcPoly);
        }

        public PolyNode(PolyNode src)
        {
            coef = new Number(src.coef);
            poly = new Polynomial(src.poly);
        }

        /// <summary>
        /// Принтира многочленно звено
        /// </summary>
        /// <param name="attach">Дали да се слепва(т.е. да има знак)</param>
        /// <param name="brackets">Дали да е в скоби</param>
        /// <returns></returns>
        public override string print(bool attach, bool brackets)
        {
            string result = "";
            
            if(attach)
            {
                if(coef.isPosOne) // при коефициент +1 не го принтираме
                {
                    if(brackets)
                    {
                        result += " + " + poly.print(true, true);
                    }
                    else result += poly.print(true, false);
                }
                else
                {
                    result += coef.print(true, false);
                    result += poly.print(true, true);
                }                
            }
            else
            {
                if (coef.isPosOne) result = poly.print(false, false);
                else result = coef.print(false, false) + poly.print(false, true);
            }

            return result;
        }

        public override object copy()
        {
            return new PolyNode(this);
        }
    }
}
