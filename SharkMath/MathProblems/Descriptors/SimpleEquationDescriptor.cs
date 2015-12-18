using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    class SimpleEquationDescriptor
    {
        public CoefDescriptor rootDesc;
        public CoefDescriptor elemCoefDesc;
        public int power, maxVisualPower;
        public int minTransformations, maxTransformations;
    }
}
