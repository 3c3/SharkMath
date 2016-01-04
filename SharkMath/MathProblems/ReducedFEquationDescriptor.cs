using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharkMath.MathProblems.Descriptors;

namespace SharkMath.MathProblems
{
    public class ReducedFEquationDescriptor
    {
        public char letter;
        public byte pFractions;
        public byte pIrrational;
        public byte minTransformations, maxTransformations;
        public byte power, maxVisualPower;
        public byte minDenominators;
        public byte maxDenominators;

        public FracEquationDescriptor toFEquationDescriptor()
        {
            FracEquationDescriptor fed = new FracEquationDescriptor();
            CoefDescriptor elemCd = fed.elemDesc;

            elemCd.pRational = pFractions;
            elemCd.pNatural = (byte)(100 - pFractions);
            elemCd.pIrrational = pIrrational;
            elemCd.minDenominator = 1;
            elemCd.maxDenominator = 7;
            elemCd.minNumerator = 1;
            elemCd.maxDenominator = 13;

            CoefDescriptor rootCd = fed.rootDesc;
            rootCd.pIrrational = pIrrational;
            rootCd.pRational = pFractions;
            rootCd.pNatural = (byte)(100 - pFractions);
            rootCd.minDenominator = 1;
            rootCd.maxDenominator = 7;
            rootCd.minNumerator = 1;
            rootCd.maxDenominator = 13;

            fed.maxTransformations = maxTransformations;
            fed.minTransformations = minTransformations;
            fed.pNoRealSolution = 30;
            fed.pNoSolution = 5;
            fed.power = power;
            fed.maxVisualPower = maxVisualPower;

            return fed;
        }
    }
}
