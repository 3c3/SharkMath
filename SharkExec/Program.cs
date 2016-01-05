using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath;
using SharkMath.MathProblems;
using SharkMath.MathProblems.Problems;

namespace SharkExec
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Number[] nums = new Number[n];
            for (int i = 0; i < n; i++) nums[i] = new Number(i);

            IntervalPoint[] points = new IntervalPoint[n];
            for (int i = 0; i < n; i++) points[i] = new IntervalPoint(nums[i], false);

            points[2].isExcluded = true;

            Interval[] intervals = Interval.constructIntervals(true, '<', points);

            foreach (Interval i in intervals) Console.WriteLine(i.print(false, false));

            Console.ReadLine();
        }        
    }
}
