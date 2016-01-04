using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class Number : IPrintable, IComparable, IEvaluable
    {
        public int numerator; // числител
        public int denominator; // знаменател

        #region Свойства

        public bool isZero
        {
            get
            {
                return numerator==0;
            } 
        }

        /// <summary>
        /// Дали е +/-1
        /// </summary>
        public bool isOne
        {
            get
            {
                return (numerator == 1 || numerator==-1) && denominator == 1;
            }
        }

        /// <summary>
        /// Дали е +1
        /// </summary>
        public bool isPosOne
        {
            get
            {
                return numerator == 1 && denominator == 1;
            }
        }

        public bool isInteger
        {
            get
            {
                return denominator == 1;
            }
        }

        public bool isNegative
        {
            get
            {
                return numerator<0;
            }
        }

        public char sign
        {
            get
            {
                return numerator < 0 ? '-' : '+';
            }
        }

        #endregion

        #region Конструктори
        public Number()
        {
            numerator = 0;
            denominator = 1;
        }

        public Number(Number n)
        {
            numerator = n.numerator;
            denominator = n.denominator;
        }

        public Number(int k)
        {
            numerator = k;
            denominator = 1;
        }

        /// <summary>
        /// Създава дроб по числител и знаменател
        /// </summary>
        /// <param name="num">числител</param>
        /// <param name="denom">знаменател</param>
        public Number(int num, int denom)
        {
            if (denom == 0) throw new DivideByZeroException("Tried to create a number with denominator 0!");
            if(denom<0)
            {
                num *= -1;
                denom *= -1;
            }

            numerator = num;
            denominator = denom;
            checkGcd();
        }

        #endregion

        /// <summary>
        /// Намира НОД на две числа. Винаги положителен резултат
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int gcd(int a, int b)
        {
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;

            int c;
            while (a != 0)
            {
                c = a;
                a = b % a;
                b = c;
            }
            return b;
        }

        public static Number gcd(Number a, Number b)
        {
            return new Number(gcd(a.numerator, b.numerator), gcd(a.denominator, b.denominator));
        }

        #region Оператори

        public static Number operator+(Number n1, Number n2)
        {
            if (n1.isZero) return n2;
            if (n2.isZero) return n1;

            int newNumerator = n1.numerator * n2.denominator + n2.numerator * n1.denominator;
            int newDenominator = n1.denominator * n2.denominator;
            return new Number(newNumerator, newDenominator);
        }

        public static Number operator-(Number n1, Number n2)
        {
            if (n1.isZero)
            {
                return new Number(-n2.numerator, n2.denominator);
            }
            if (n2.isZero) return n1;

            int newNumerator = n1.numerator * n2.denominator - n2.numerator * n1.denominator;
            int newDenominator = n1.denominator * n2.denominator;
            return new Number(newNumerator, newDenominator);
        }

        public static Number operator*(Number n1, Number n2)
        {
            return new Number(n1.numerator * n2.numerator, n1.denominator * n2.denominator);
        }

        public static Number operator/(Number n1, Number n2)
        {
            return new Number(n1.numerator * n2.denominator, n1.denominator * n2.numerator);
        }

        public static bool operator==(Number n1, Number n2)
        {
            return n1.denominator == n2.denominator && n1.numerator == n2.numerator;
        }

        public static bool operator !=(Number n1, Number n2)
        {
            return n1.denominator != n2.denominator || n1.numerator != n2.numerator;
        }

        public static bool operator <(Number n1, Number n2)
        {
            int eval = n1.numerator * n2.denominator - n2.numerator * n1.denominator;
            return eval < 0;
        }

        public static bool operator >(Number n1, Number n2)
        {
            int eval = n1.numerator * n2.denominator - n2.numerator * n1.denominator;
            return eval > 0;
        }


        #endregion

        #region Модифициращи функции

        /// <summary>
        /// За случаи когато трябват много стойности на 1 число
        /// </summary>
        /// <param name="num"></param>
        /// <param name="denom"></param>
        public void set(int num, int denom = 1)
        {
            numerator = num;
            denominator = denom;
            checkGcd();
        }

        /// <summary>
        /// Съкращава дробта, ако е възможно
        /// </summary>
        public void checkGcd()
        {
            int g = gcd(numerator, denominator);
            if (g == 1) return;
            numerator /= g;
            denominator /= g;
        }

        /// <summary>
        /// Умножава самото число
        /// </summary>
        /// <param name="arg"></param>
        public void MultiplyBy(Number arg)
        {
            if (arg.isPosOne) return;
            numerator *= arg.numerator;
            denominator *= arg.denominator;
            checkGcd();
        }

        public void MultiplyBy(int arg)
        {
            if (arg == 1) return;
            numerator *= arg;
            checkGcd();
        }

        /// <summary>
        /// Дели самото число
        /// </summary>
        /// <param name="arg"></param>
        public void DivideBy(Number arg)
        {
            if (arg.isPosOne) return;
            numerator *= arg.denominator;
            denominator *= arg.numerator;
            checkGcd();
        }

        public void DivideBy(int arg)
        {
            if (arg == 1) return;
            denominator *= arg;
            checkGcd();
        }

        public void makeOne()
        {
            numerator = 1;
            denominator = 1;
        }

        /// <summary>
        /// Сменя числител и знаменател
        /// </summary>
        public void flip()
        {
            int tmp = denominator;
            denominator = numerator;
            numerator = tmp;
            if (denominator < 0)
            {
                denominator *= -1;
                numerator *= -1;
            }
        }

        public void flipSign()
        {
            numerator *= -1;
        }

        #endregion

        public static bool isSquare(int k)
        {
            if (k < 0) return false;
            if (k == 1) return true;
            int low = 1;
            int high = 1;

            while(high*high < k)
            {
                low = high;
                high <<= 1;
            }

            while(high - low > 1)
            {
                int mid = (high + low) / 2;
                int square = mid * mid;
                if (k == square) return true;
                if (k > square) low = mid;
                else high = mid;
            }

            return low * low == k || high * high == k;
        }

        private static List<int> primes = new List<int>();
        private static bool primesCalculated = false;

        private static void calculatePrimes()
        {
            if (primesCalculated) return;
            primesCalculated = true;

            bool[] isNotPrime = new bool[4096];
            for(int i = 2; i < 4096; i++)
            {
                if(isNotPrime[i] == false)
                {
                    primes.Add(i);
                    for (int j = 2 * i; j < 4096; j += i) isNotPrime[j] = true;
                }
            }

        }

        public static int extractSquare(int num)
        {
            calculatePrimes();
            int result = 1;

            int idx = 0;
            while(primes[idx]*primes[idx] <= num)
            {
                int cnt = 0;
                while(num%primes[idx] == 0)
                {
                    cnt++;
                    if(cnt==2)
                    {
                        result *= primes[idx];
                        cnt = 0;
                    }
                    num/=primes[idx];
                }
                idx++;
            }

            return result;
        }

        public Number extractSquare()
        {
            calculatePrimes();
            return new Number(extractSquare(numerator), extractSquare(denominator));
        }

        public bool isSquare()
        {
            if (numerator == 0) return true;
            return isSquare(numerator) && isSquare(denominator);
            return false;
        }

        public Int32 CompareTo(Object obj)
        {
            Number n2 = obj as Number;
            if (n2 == null) throw new ArgumentException("Tried to compare Number with another class.");

            int eval = numerator * n2.denominator - n2.numerator * denominator;
            if (eval < 0) return -1;
            if (eval > 0) return 1;
            return 0;
        }
                
        public string print(bool attach, bool showOne)
        {
            string result;
            if(attach)
            { // при слепване се оставя интервал
                if (isNegative)
                {
                    result = " - ";
                    if(isOne && !showOne) return result;
                    if (isInteger) result += (-numerator).ToString(); //затова трябва да се обърне знака на горното
                    else result += "\\frac{" + (-numerator).ToString() + "}{" + denominator.ToString() + "}";
                    return result;
                }
                else
                {
                    result = " + ";
                    if (isOne && !showOne) return result; 
                    if (isInteger) result += numerator.ToString();
                    else result += "\\frac{" + numerator.ToString() + "}{" + denominator.ToString() + "}";
                    return result;
                }                
            }
            else
            {
                if(isInteger)
                {
                    if(showOne) return numerator.ToString();
                    if (numerator == -1) return "-";
                    if (numerator == 1) return "";
                    return numerator.ToString();
                }
                else
                {
                    if (isNegative) result = "-\\frac{" + (-numerator).ToString() + "}{" + denominator + "}"; // при дроб минуса трябва да е отпред
                    else result = "\\frac{" + numerator.ToString() + "}{" + denominator + "}";
                    return result;
                }
            }       
        }


        public double eval()
        {
            return (double)numerator / (double)denominator; 
        }
    }
}
