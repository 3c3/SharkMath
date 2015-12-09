using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class Number : IPrintable, IComparable
    {
        public int numerator;
        public int denominator;

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
            numerator = 1;
            denominator = 1;
        }

        public Number(int num, int denom)
        {
            if (denom == 0) throw new DivideByZeroException("Tried to create a number with denominator 0!");
            if(denom<0)
            {
                num *= -1;
                denom *= -1;
            }
            int g = gcd(num, denom);
            if(g==1)
            {
                numerator = num;
                denominator = denom;
            }
            else
            {
                numerator = num / g;
                denominator = denom / g;
            }
        }

        static int gcd(int a, int b)
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

        public Int32 CompareTo(Object obj)
        {
            Number n2 = obj as Number;
            if (n2 == null) throw new ArgumentException("Tried to compare Number with another class.");

            int eval = numerator * n2.denominator - n2.numerator * denominator;
            if (eval < 0) return -1;
            if (eval > 0) return 1;
            return 0;
        }

        public static bool operator<(Number n1, Number n2)
        {
            int eval = n1.numerator * n2.denominator - n2.numerator * n1.denominator;
            return eval < 0;
        }

        public static bool operator >(Number n1, Number n2)
        {
            int eval = n1.numerator * n2.denominator - n2.numerator * n1.denominator;
            return eval > 0;
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
                if (isNegative && isOne) return "-";
                if (!showOne && isOne) return "";
                if (isInteger) return numerator.ToString();
                else
                {
                    if (isNegative) result = "-\\frac{" + (-numerator).ToString() + "}{" + denominator + "}"; // при дроб минуса трябва да е отпред
                    else result = "\\frac{" + numerator.ToString() + "}{" + denominator + "}";
                    return result;
                }
            }       
        }
    }
}
