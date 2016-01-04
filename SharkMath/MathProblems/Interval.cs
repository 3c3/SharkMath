using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems
{
    public class Interval : IPrintable
    {
        byte type;

        IPrintable left, right;

        bool leftClosed
        {
            get
            {
                return (type & 2) != 0;
            }
            set
            {
                if (value) type |= (byte)2;
                else type ^= (byte)(type & 2);
            }
        }

        bool rightClosed
        {
            get 
            {
                return (type & 1) != 0;
            }
            set
            {
                if (value) type |= (byte)1;
                else type ^= (byte)(type & 1);
            }
        }

        public Interval(IPrintable left, IPrintable right, bool leftClosed, bool rightClosed)
        {
            this.left = left;
            this.right = right;
            this.leftClosed = leftClosed && ((object)left!=null);
            this.rightClosed = rightClosed && ((object)right!=null);
        }

        public string print(bool ignored1, bool ignored2)
        {
            string result = "";
            if (leftClosed) result += '[';
            else result += '(';

            if ((object)left == null) result += "-\\infty";
            else result += left.print(false, left is Number);

            result += " ; ";

            if ((object)right == null) result += "+\\infty";
            else result += right.print(false, right is Number);

            if (rightClosed) result += ']';
            else result += ')';

            return result;
        }
    }
}
