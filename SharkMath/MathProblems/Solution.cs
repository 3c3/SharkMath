using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems
{
    public class Solution
    {
        public enum Type { Equation, Inequation };
        Type type;
        public List<IPrintable> parts;
        char letter;

        public Solution(char letter, Type type)
        {
            this.letter = letter;
            this.type = type;
            parts = new List<IPrintable>();
        }

        public string print()
        {
            if(type == Type.Equation)
            {
                if (parts.Count == 0) return String.Format("{0} \\in \\varnothing", letter);
                string result = letter + " = ";
                for (int i = 0; i < parts.Count - 1; i++) result += parts[i].print(false, parts[i] is Number) + "; ";
                result += parts[parts.Count - 1].print(false, parts[parts.Count - 1] is Number);
                return result;
            }
            else if(type == Type.Inequation)
            {
                if (parts.Count == 0) return String.Format("{0} \\in \\varnothing", letter);
                string result = letter + " \\in ";
                for (int i = 0; i < parts.Count - 1; i++) result += parts[i].print(false, parts[i] is Number) + " \\cup ";
                result += parts[parts.Count - 1].print(false, parts[parts.Count - 1] is Number);
                return result;
            }
            return "error";
        }
    }
}
