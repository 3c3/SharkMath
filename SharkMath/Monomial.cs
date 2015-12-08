using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SharkMath
{
    public class Monomial : IComparable, IPrintable
    {
        public List<Simple> simples = new List<Simple>();
        public Number coef;
        public short power;

        public bool isNumber
        {
            get { return simples.Count == 0;  }
        }

        public bool isOne
        {
            get
            {
                return simples.Count == 1 && coef.numerator == 1 && coef.denominator == 1;
            }
        }

        public char sign
        {
            get { return coef.isNegative ? '-' : '+'; }
        }
        public Monomial()
        {
            coef = new Number();
            power = 0;
        }

        public Monomial(Number n)
        {
            coef = new Number(n);
            power = 0;
        }
           
        /// <summary>
        /// Строи едночлен
        /// </summary>
        /// <param name="c">числото</param>
        /// <param name="v">НЕсортиран списък с прости едночлени</param>
        public Monomial(Number c, List<Simple> v)
        {
            coef = new Number(c);
            simples = v;
            power = 0;
            v.ForEach(s => power += s.power);
            v.Sort();
        }

        public Monomial(Number c, char letter)
        {
            coef = new Number(c);
            simples.Add(new Simple(letter, 1));
            power = 1;
        }

        public Monomial(Number c, char letter, short pow)
        {
            coef = new Number(c);
            simples.Add(new Simple(letter, pow));
            power = pow;
        }
        /// <summary>
        /// Прави едночлен
        /// </summary>
        /// <param name="coef">число</param>
        /// <param name="simples">простите едночлени: ТРЯБВА да са сортирани!</param>
        /// <param name="power">степента</param>
        public Monomial(Number coef, List<Simple> simples, int power)
        {
            this.coef = new Number(coef);
            this.simples = simples;
            this.power = (short)power;
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="src"></param>
        public Monomial(Monomial src)
        {
            simples = new List<Simple>(src.simples.Count);
            src.simples.ForEach(s => simples.Add(s));
            coef = new Number(src.coef);
            power = src.power;
        }

        /// <summary>
        /// Копира едночлена с различен коефициент
        /// </summary>
        /// <param name="m">Едночлена източник</param>
        /// <param name="newCoef">Новото число</param>
        public Monomial(Monomial m, Number newCoef)
        {
            simples = new List<Simple>(m.simples.Count);
            m.simples.ForEach(s => simples.Add(s));
            coef = new Number(newCoef);
            power = m.power;
        }

        public Monomial(string s, ref int idx) //Конструктор със string
        {
            //Във финалната версия няма да се ползва много, но сега
            coef = new Number(1);               //ще е полезен за тестване, а може и да му се намери някоя
            if(s[idx] >= '0' && s[idx] <= '9')           //употреба за домашно по математика
            {
                int n = 0;

                while(idx < s.Length && s[idx] >= '0' && s[idx] <= '9')
                {
                    n*=10;
                    n+=s[idx++]-'0';
                }
                this.coef.numerator = n;
            }

            power = 0;
            if(idx>=s.Length)
            {
                return;
            }

            while(idx<s.Length && s[idx]!=' ') //Вече е сигурно, че първия символ е буква
            {
                Simple si = new Simple(s, ref idx);   //Затова правим прости едночлени докато можем
                simples.Add(si);//Ето тук влиза пойнтъра към индекс в оня конструктор
                power+=si.power;
            }
            simples.Sort();
        }

        public Int32 CompareTo(Object obj)
        {
            Monomial m = obj as Monomial;
            if (m == null) throw new ArgumentException("Tried to compare Monomial to something else.");

            if (power > m.power) return -1;
            if (m.power > power) return 1;

            if (simples.Count > m.simples.Count) return -1;
            if (m.simples.Count > simples.Count) return 1;

            int lim = Math.Min(simples.Count, m.simples.Count);

            for (int i = 0; i < lim; i++)
            {
                if (simples[i].letter < m.simples[i].letter) return -1;
                if (m.simples[i].letter < simples[i].letter) return 1;

                if (simples[i].power < m.simples[i].power) return -1;
                if (m.simples[i].power < simples[i].power) return 1;
            }

            return 0;
        }

        public static bool operator>(Monomial m1, Monomial m2)
        {
            return m1.CompareTo(m2) == 1;
        }

        public static bool operator<(Monomial m1, Monomial m2)
        {
            return m1.CompareTo(m2) == -1;
        }

        public static Monomial operator*(Monomial m1, Monomial m2)
        {
            if (m1.coef.isZero || m2.coef.isZero) return new Monomial();
            Number newCoef = m1.coef * m2.coef;

            SortedDictionary<char, short> powers = new System.Collections.Generic.SortedDictionary<char,short>();
            foreach(Simple s in m1.simples)
            {
                if (powers.ContainsKey(s.letter)) powers[s.letter] += s.power;
                else powers.Add(s.letter, s.power);
            }
            foreach (Simple s in m2.simples)
            {
                if (powers.ContainsKey(s.letter)) powers[s.letter] += s.power;
                else powers.Add(s.letter, s.power);
            }

            List<Simple> newList = new List<Simple>();
            foreach (KeyValuePair<char, short> kvp in powers) newList.Add(new Simple(kvp.Key, kvp.Value));

            return new Monomial(newCoef, newList, m1.power + m2.power);
        }
        /// <summary>
        /// Принтира едночлена
        /// </summary>
        /// <param name="attach">Слепване: дали да има разстояние м/у знака и числото/буквите</param>
        /// <param name="brackets">игнорира се</param>
        /// <returns>LaTeX</returns>
        public string print(bool attach, bool ignored)
        {
            string result = coef.print(attach, simples.Count==0);
            simples.ForEach(s => result += s.print());
            return result;
        }
    }
}

