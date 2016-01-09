using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class Polynomial : IPrintable, IEvaluable
    {
        public List<Monomial> monos; /// състващите едночлени
        
        #region Конструктори

        /// <summary>
        /// Copy конструктор
        /// </summary>
        public Polynomial(Polynomial src)
        {
            monos = new List<Monomial>(src.monos.Count);
            src.monos.ForEach(m => monos.Add(new Monomial(m)));
        }

        /// <summary>
        /// Многочлен по списък от едночлени
        /// </summary>
        /// <param name="monos">Списъкът едночлени</param>
        /// <param name="isSorted">Дали списъкът е сортиран. Ако не е - се сортира.</param>
        public Polynomial(List<Monomial> monos, bool isSorted)
        {
            this.monos = monos;
            if(!isSorted)monos.Sort();
        }

        /// <summary>
        /// Нулиращ конструктор
        /// </summary>
        public Polynomial()
        {
            monos = new List<Monomial>();
        }

        /// <summary>
        /// Многочлен, който е просто число
        /// </summary>
        /// <param name="num"></param>
        public Polynomial(Number num)
        {
            monos = new List<Monomial>();
            monos.Add(new Monomial(num));
        }

        /// <summary>
        /// Многочлен-корен, т.е. при буквата равна на корена, е 0
        /// </summary>
        /// <param name="ltr">буквата на променливата</param>
        /// <param name="root">числото корен</param>
        public Polynomial(char ltr, Number root)
        {
            Monomial first = new Monomial(new Number(1), ltr);
            Monomial second = new Monomial(new Number(-root.numerator, root.denominator));

            monos = new List<Monomial>();
            monos.Add(first);
            monos.Add(second);
        }

        /// <summary>
        /// Прави квадратен тричлен
        /// </summary>
        /// <param name="ltr"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Polynomial(char ltr, Number a, Number b, Number c)
        {
            Monomial first = new Monomial(a, ltr, 2);
            Monomial second = new Monomial(b, ltr);
            Monomial third = new Monomial(c);

            monos = new List<Monomial>(3);

            monos.Add(first);
            monos.Add(second);
            monos.Add(third);
        }

        /// <summary>
        /// Прави полином от низ, напр. 2x2 - 3x + 3
        /// </summary>
        /// <param name="s">Без дроби; степените се запизват директно след буквата без доп. знаци</param>
        public Polynomial(string s)
        {
            monos = new List<Monomial>();
            int idx = 0;

            bool sign = true; //true e +, false e -

            while (idx < s.Length)
            {
                char c = s[idx];
                if (c == ' ')
                {
                    idx++;
                    continue;
                }
                if (c == '+')
                {
                    idx++;
                    sign = true;
                    continue;
                }
                if (c == '-')
                {
                    idx++;
                    sign = false;
                    continue;
                }

                Monomial m = new Monomial(s, ref idx);
                if (!sign) m.coef.numerator *= -1;
                monos.Add(m);
            }

            monos.Sort();
        }

        #endregion

        /// <summary>
        /// Дали коефициентът пред най-високата степен е отрицателен
        /// </summary>
        public bool isNegative
        {
            get
            {
                return monos.Count > 0 ? monos[0].coef.isNegative : false;
            }
        }

        public int maxPower
        {
            get
            {
                return monos.Count > 0 ? monos[0].power : 0;
            }
        }

        public bool isZero
        {
            get
            {
                return monos.Count == 0;
            }
        }

        public bool isOne
        {
            get
            {
                if (monos.Count != 1) return false;
                return monos[0].power == 0 && monos[0].coef.isPosOne;
            }
        }
       
        /// <summary>
        /// Принтира многочлен
        /// </summary>
        /// <param name="attach">Дали да се слепва</param>
        /// <param name="brackets">Дали да е в скоби. НЕ слага знак пред скобите!</param>
        /// <returns></returns>
        public string print(bool attach = false, bool brackets = false)
        {
            string result = "";

            if(monos.Count == 0)
            {
                if (attach) return " + 0";
                else return "0";
            }

            if(brackets)
            {
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

        /// <summary>
        /// Обръща знаците
        /// </summary>
        public void flipSigns()
        {
            monos.ForEach(m => m.coef.numerator *= -1);
        }
        
        /// <summary>
        /// Намира най-големия общ числов множител
        /// </summary>
        /// <returns></returns>
        public Number findGcd()
        {
            int g_num = monos[0].coef.numerator;
            int g_den = monos[0].coef.denominator;

            for(int i = 1; i < monos.Count; i++)
            {
                g_num = Number.gcd(g_num, monos[i].coef.numerator);
                g_den = Number.gcd(g_den, monos[i].coef.denominator);
            }

            return new Number(g_num, g_den);
        }

        /// <summary>
        /// Премахва дробните коефициенти, като умножава по НОК
        /// </summary>
        public void removeFracCoefs()
        {
            int g_den = monos[0].coef.denominator;
            int product = monos[0].coef.denominator;

            for(int i = 0; i < monos.Count; i++)
            {
                g_den = Number.gcd(g_den, monos[i].coef.denominator);
                product *= monos[i].coef.denominator;
            }

            int mult = product / g_den;
            if (mult == 1) return;
            monos.ForEach(m => m.coef.MultiplyBy(mult));
        }

        /// <summary>
        /// Намира числовия НОД и дели всичко коефициенти на него
        /// </summary>
        /// <returns></returns>
        public Number findAndExtractGcd()
        {
            Number numGcd = findGcd();
            if (numGcd.isPosOne) return numGcd;

            monos.ForEach(m => m.coef.DivideBy(numGcd));

            return numGcd;
        }

        #region Математически функции/оператори

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

        public static Polynomial subtractPoly(Polynomial p1, Polynomial p2)
        {
            List<Monomial> newList = new List<Monomial>(p1.monos.Count + p2.monos.Count);

            int idx1 = 0;
            int idx2 = 0;
            int lim1 = p1.monos.Count;
            int lim2 = p2.monos.Count;

            while (idx1 < lim1 && idx2 < lim2) // сливане на 2 сортирани масива
            {
                Monomial m1 = p1.monos[idx1];
                Monomial m2 = p2.monos[idx2];

                int cmpResult = m1.CompareTo(m2);

                switch (cmpResult)
                {
                    case -1: // първия елемент е по-голям => добавяме го
                        newList.Add(new Monomial(m1));
                        idx1++;
                        break;
                    case 0: // равни са, изваждаме коефициентите
                        idx1++;
                        idx2++;
                        Number newCoef = m1.coef - m2.coef;
                        if (newCoef.isZero) continue; // ако се получи 0 нищо не добавяме                    
                        newList.Add(new Monomial(m1, newCoef));
                        break;
                    case 1: // втория е по-голям, добавяме
                        newList.Add(new Monomial(m2, true));
                        idx2++;
                        break;
                }
            }
            while (idx1 < lim1) newList.Add(new Monomial(p1.monos[idx1++])); // добавяме останалите едночлени
            while (idx2 < lim2) newList.Add(new Monomial(p2.monos[idx2++], true)); // само един от тези ще се изпълни

            if (newList.Count > 0) return new Polynomial(newList, true);
            return new Polynomial();
        }

        public static Polynomial operator+(Polynomial p1, Polynomial p2)
        {
            return addPoly(p1, p2);
        }

        public static Polynomial operator-(Polynomial p1, Polynomial p2)
        {
            return subtractPoly(p1, p2);
        }

        public void MultiplyByNumber(Number num)
        {
            monos.ForEach(m => m.coef.MultiplyBy(num));
        }

        public static Polynomial multPolyByMono(Polynomial p, Monomial m)
        {
            List<Monomial> newList = p.monos.Select(mc => mc*m).ToList<Monomial>();
            if(newList==null) throw new Exception("This was a bad idea.");
            return new Polynomial(newList, false);
        }

        public static Polynomial operator*(Polynomial p1, Polynomial p2)
        {
            if(p1.monos.Count < p2.monos.Count) // винаги умножаваме по-голямо по по-малко
            {                                   // така имаме по-малко извиквания
                Polynomial tmp = p1;            // на multPolyByMono и събиране
                p1 = p2;
                p2 = tmp;
            }

            Polynomial result = multPolyByMono(p1, p2.monos[0]); // използва се стандартния метод за умножение
            for (int i = 1; i < p2.monos.Count; i++) // по-оптимизирани биха били практични при толкова висок брой едночлени,
            {                                        // че обработването от човек би било невъзможно
                result += multPolyByMono(p1, p2.monos[i]);
            }
            return result;
        }

        #endregion

        public Polynomial getExtract()
        {
            Polynomial result = new Polynomial();
            Random r = new Random();
            for(int i = 0; i < monos.Count; i++)
            {
                Monomial current = new Monomial(monos[i]);
                if (monos[i].coef.isNegative)
                {
                    current.coef.numerator = r.Next(monos[i].coef.numerator, 0);
                }
                else current.coef.numerator = r.Next(monos[i].coef.numerator) + 1;
                result.monos.Add(current);
            }
            return result;
        }

        public double eval()
        {
            if (monos.Count > 1) throw new Exception("Polynomial cannot be evaluated because it has letters.");
            if (monos.Count == 0) return 0.0;
            if (monos[0].power == 0) return monos[0].coef.eval();
            throw new Exception("Polynomial cannot be evaluated because it is a letter.");
        }

        public Number[] getQuadraticCoefs()
        {
            Number[] coefs = new Number[3];
            for (int i = 0; i < 3; i++) coefs[i] = new Number(0);
            foreach(Monomial mono in monos)
            {
                if (mono.power > 2) return null;
                coefs[mono.power].set(mono.coef);
            }

            return coefs;
        }
    }
}
