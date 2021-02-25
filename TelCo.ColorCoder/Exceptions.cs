using System;
using TelCo.ColorCoderClasses;

namespace TelCo.ColorCoderExecptions
{
    /// <summary>
    /// This class contains different exception conditions and throw respective exceptions.
    /// </summary>
    public static class Exceptions
    {
        public static void getArgumentOutOfRangeException(int pairNumber, int minorSize, int majorSize)
        {
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
        }
        public static void getArgumentException(int minorIndex, int majorIndex, ColorPair Colors)
        {
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", Colors.ToString()));
            }
        }

    }
}
