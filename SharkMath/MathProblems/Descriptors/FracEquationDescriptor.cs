using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath
{
    public class FracEquationDescriptor
    {
        // WIP/NYI
        public CoefDescriptor elemDesc;
        public CoefDescriptor rootDesc;
        public byte minTransformations, maxTransformations;
        public byte power, maxVisualPower;
        public byte minDenominators;
        public byte maxDenominators;
        public byte pNoSolution, pNoRealSolution;
    }
}
