using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharkMath.MathProblems
{
    public class ReducedSEquationDescriptor
    {
        public char letter;
        public byte pFractions;
        public byte pIrrational;
        public byte minTransformations, maxTransformations;
        public byte power, maxVisualPower;

        public SimpleEquationDescriptor toSEquationDescriptor()
        {
            SimpleEquationDescriptor sed = new SimpleEquationDescriptor();
            CoefDescriptor elemCd = sed.elemCoefDesc;

            elemCd.pRational = pFractions;
            elemCd.pNatural = (byte)(100 - pFractions);
            elemCd.minDenominator = 1;
            elemCd.maxDenominator = 7;
            elemCd.minNumerator = 1;
            elemCd.maxNumerator = 13;

            CoefDescriptor rootCd = sed.rootDesc;
            rootCd.pIrrational = pIrrational;
            rootCd.pRational = pFractions;
            rootCd.pNatural = (byte)(100 - pFractions);
            rootCd.minDenominator = 1;
            rootCd.maxDenominator = 7;
            rootCd.minNumerator = 1;
            rootCd.maxDenominator = 13;

            sed.maxTransformations = maxTransformations;
            sed.minTransformations = minTransformations;
            sed.pNoRealSolutions = 30;
            sed.pNoSolution = 5;
            sed.power = power;
            sed.maxVisualPower = maxVisualPower;

            return sed;
        }
    }
}
