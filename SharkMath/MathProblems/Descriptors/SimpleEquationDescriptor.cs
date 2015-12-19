using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class SimpleEquationDescriptor
    {
        public SimpleEquationDescriptor()
        {
            rootDesc = new CoefDescriptor();
            elemCoefDesc = new CoefDescriptor();
        }

        public CoefDescriptor rootDesc;
        public CoefDescriptor elemCoefDesc;
        public int power, maxVisualPower;
        public int minTransformations, maxTransformations;
        public byte pNoSolution, pNoRealSolutions;
    }
}
