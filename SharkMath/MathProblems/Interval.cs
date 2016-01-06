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

            result += "; ";

            if ((object)right == null) result += "+\\infty";
            else result += right.print(false, right is Number);

            if (rightClosed) result += ']';
            else result += ')';

            return result;
        }

        public static Interval[] constructIntervals(bool closed, char sign, IntervalPoint[] points)
        {
            if (sign != '>' && sign != '<') throw new ArgumentException("Invalid inequation sign!");
            Array.Sort(points);
            if (sign == '>') return constructIntervalsGreater(closed, points);
            else return constructIntervalsLess(closed, points);
        }

        private static Interval[] constructIntervalsGreater(bool closed, IntervalPoint[] points)
        {
            int nIntervals = points.Length / 2 + 1;
            Interval[] result = new Interval[nIntervals];
            int last = nIntervals - 1;
            
            IntervalPoint current = points[points.Length - 1];

            result[last] = new Interval(current.value as IPrintable, null, closed && !current.isExcluded, false);
            int pIdx = points.Length - 2;

            for(int i = last - 1; i >= 0; i--)
            {
                IntervalPoint right = points[pIdx--];
                IntervalPoint left = pIdx >= 0 ? points[pIdx--] : null;
                if (left == null) result[i] = new Interval(null, right.value as IPrintable, false, closed && !right.isExcluded);
                else result[i] = new Interval(left.value as IPrintable, right.value as IPrintable, closed && !left.isExcluded, closed && !right.isExcluded);
            }

            return result;
        }

        private static Interval[] constructIntervalsLess(bool closed, IntervalPoint[] points)
        {
            int nIntervals = points.Length / 2 + points.Length % 2;
            Interval[] result = new Interval[nIntervals];
            int last = nIntervals - 1;

            int pIdx = points.Length - 1;
            for(int i = last; i >= 0; i --)
            {
                IntervalPoint right = points[pIdx--];
                IntervalPoint left = pIdx >= 0 ? points[pIdx--] : null;
                if(left == null) result[i] = new Interval(null, right.value as IPrintable, false, closed && !right.isExcluded);
                else result[i] = new Interval(left.value as IPrintable, right.value as IPrintable, closed && !left.isExcluded, closed && !right.isExcluded);
            }

            return result;
        }
    }
}
