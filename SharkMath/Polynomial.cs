using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class Polynomial : IPrintable
    {
        public List<Monomial> monos; /// състващите едночлени

        public Polynomial(List<Monomial> monos, bool isSorted)
        {
            this.monos = monos;
            if(!isSorted)monos.Sort();
        }

        public Polynomial()
        {
            monos = new List<Monomial>();
        }

        public Polynomial(char ltr, Number root)
	    {
            Monomial first = new Monomial(new Number(1), ltr);
            Monomial second = new Monomial(new Number(-root.numerator, root.denominator));

            monos = new List<Monomial>();
            monos.Add(first);
            monos.Add(second);
	    }
        /// <summary>
        /// Прави полином от низ
        /// </summary>
        /// <param name="s">Без дроби; степените се запизват директно след буквата без доп. знаци</param>
        public Polynomial(string s)
        {
            monos = new List<Monomial>();
            int idx = 0;

            bool sign=true; //true e +, false e -

            while(idx<s.Length)
            {
                char c = s[idx];
                if(c==' ')
                {
                    idx++;
                    continue;
                }
                if(c=='+')
                {
                    idx++;
                    sign=true;
                    continue;
                }
                if(c=='-')
                {
                    idx++;
                    sign=false;
                    continue;
                }

                Monomial m = new Monomial(s, ref idx);
                if(!sign) m.coef.numerator*=-1;
                monos.Add(m);
            }

            monos.Sort();
        }
        /// <summary>
        /// Принтира многочлен
        /// </summary>
        /// <param name="attach">Дали да се слепва</param>
        /// <param name="brackets">Дали да е в скоби. НЕ слага знак пред скобите!</param>
        /// <returns></returns>
        public string print(bool attach, bool brackets)
        {
            string result = "";

            if(brackets)
            {
                //if(attach) result += "+ ";
                result+="(";
                for (int i = 0; i < monos.Count; i++) result += monos[i].print(i > 0, false);
                result += ")";
            }
            else
            {
                if (attach) monos.ForEach(m => result+= m.print(true, false));
                else for (int i = 0; i < monos.Count; i++) result += monos[i].print(i > 0, false);
            }

            return result;
        }

        public void flipSigns()
        {
            monos.ForEach(m => m.coef.numerator *= -1);
        }

        public static Polynomial addPoly(Polynomial p1, Polynomial p2)
        {
            List<Monomial> newList = new List<Monomial>(p1.monos.Count + p2.monos.Count);

            int idx1 = 0;
            int idx2 = 0;
            int lim1 = p1.monos.Count;
            int lim2 = p2.monos.Count;

            while(idx1 < lim1 && idx2 < lim2) // сливане на 2 сортирани масива
            {
                Monomial m1 = p1.monos[idx1];
                Monomial m2 = p2.monos[idx2];

                int cmpResult = m1.CompareTo(m2);

                switch(cmpResult)
                {
                    case -1: // първия елемент е по-голям => добавяме го
                        newList.Add(new Monomial(m1));
                        idx1++;
                        break;
                    case 0: // равни са, събираме коефициентите
                        idx1++;
                        idx2++;
                        Number newCoef = m1.coef + m2.coef;
                        if (newCoef.isZero) continue; // ако се получи 0 нищо не добавяме                    
                        newList.Add(new Monomial(m1, newCoef));
                        break;
                    case 1: // втория е по-голям, добавяме
                         newList.Add(new Monomial(m2));
                         idx2++;
                         break;
                }
            }
            while (idx1 < lim1) newList.Add(new Monomial(p1.monos[idx1++])); // добавяме останалите едночлени
            while (idx2 < lim2) newList.Add(new Monomial(p2.monos[idx2++])); // само един от тези ще се изпълни

            if (newList.Count > 0) return new Polynomial(newList, true);
            return new Polynomial();
        }

        public static Polynomial operator+(Polynomial p1, Polynomial p2)
        {
            return addPoly(p1, p2);
        }

        public static Polynomial operator-(Polynomial p1, Polynomial p2)
        {
            p2.flipSigns();
            Polynomial result = addPoly(p1, p2);
            p2.flipSigns();
            return result;
        }

        public static Polynomial multPolyByMono(Polynomial p, Monomial m)
        {
            List<Monomial> newList = p.monos.Select(mc => mc*m).ToList<Monomial>();
            if(newList==null) throw new Exception("This was a bad idea.");
            return new Polynomial(newList, false);
        }

        public static Polynomial operator*(Polynomial p1, Polynomial p2)
        {
            if(p1.monos.Count < p2.monos.Count)
            {
                Polynomial tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            Console.WriteLine("p1: " + p1.print(false, false));
            Console.WriteLine("p2: " + p2.print(false, false));

            Polynomial result = multPolyByMono(p1, p2.monos[0]);
            Console.WriteLine("initial: " + result.print(false, false));
            for (int i = 1; i < p2.monos.Count; i++)
            {
                Polynomial tmp = multPolyByMono(p1, p2.monos[i]); ;
                Console.WriteLine("tmp: " + tmp.print(false, false));
                result += tmp;
                Console.WriteLine("result: " + result.print(false, false));
            }
            return result;
        }
    }
}
