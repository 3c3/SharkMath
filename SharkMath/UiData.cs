using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class UiData
    {
        string problem;

        public string Problem
        {
            get { return problem; }
            set { problem = value; }
        }
        string solution;

        public string Solution
        {
            get { return solution; }
            set { solution = value; }
        }
        public UiData(string p, string s) { this.problem = p; this.solution = s; }
    }
}
