using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems
{
    public class IntervalPoint : IComparable
    {
        public IEvaluable value;
        public bool isExcluded;

        public IntervalPoint(IEvaluable val, bool excluded)
        {
            value = val;
            isExcluded = excluded;
        }

        public Int32 CompareTo(Object obj)
        {
            if (obj is IntervalPoint) return value.eval().CompareTo((obj as IntervalPoint).value.eval());
            throw new Exception("Tried to compare IntervalPoint to something else.");
        }
    }
}
