using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    /// <summary>
    /// Клас за прост едночлен, буква и степен цяло число
    /// </summary>
    class Simple : IComparable
    {
        public char letter;
        public short power;

        public Simple(char letter, short power)
        {
            this.letter = letter;
            this.power = power;
        }

        public Simple(Simple src)
        {
            letter = src.letter;
            power = src.power;
        }

        public Int32 CompareTo(Object obj)
        {
            Simple s2 = obj as Simple;
            if (obj == null) throw new ArgumentException("Tried to compare Simple to other class.");
            //if (power != s2.power) return power < s2.power ? -1 : 1;
            if (letter != s2.letter) return letter < s2.letter ? -1 : 1;
            if (letter == s2.letter) throw new ArgumentException("Duplicate letters.");
            return 0;
        }   
 
        public string print()
        {
            string result = "";
            result += letter;
            if (power > 1) result += "^" + power.ToString();
            return result;
        }
    }
}
