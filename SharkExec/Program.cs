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
            Random rand = new Random(); //reuse this if you are generating many

            for (int i = 0; i < 20; i++)
            {
                int iRand = Generator.getIntCustom(1, 13);
                Console.Write(iRand + " ");
            }            

            Console.ReadLine();
        }        
    }
}
