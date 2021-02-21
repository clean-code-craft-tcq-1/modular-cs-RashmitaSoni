using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoderClasses;
using TelCo.ColorCoderExecptions;
namespace TelCo.ColorCoderFunctions
{ /// <summary>
  /// This class provides the color coding and mapping of Colors number to color and color to Colors number.
  /// </summary>
    public class FetchColorOrPairNumber
    {
        public static ColorPair FetchColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorGroup.Minor.Length;
            int majorSize = ColorGroup.Major.Length;
            AnyExceptions.getArgumentOutOfRangeException(pairNumber, minorSize, majorSize);
            int majorIndex = (pairNumber - 1) / minorSize;
            int minorIndex = (pairNumber - 1) % minorSize;
            ColorPair Colors = new ColorPair()
            {
                majorColor = ColorGroup.Major[majorIndex],
                minorColor = ColorGroup.Minor[minorIndex]
            };
            return Colors;
        }
        public static int FetchPairNumberFromColor(ColorPair Colors)
        {
            int majorIndex = -1, minorIndex = -1;
            int PairNumber;
            for (int i = 0; i < ColorGroup.Major.Length; i++)
            {
                if (ColorGroup.Major[i] == Colors.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            for (int i = 0; i < ColorGroup.Minor.Length; i++)
            {
                if (ColorGroup.Minor[i] == Colors.minorColor)
                {   minorIndex = i;
                    break;
                }
            }
            AnyExceptions.getArgumentException(minorIndex, majorIndex, Colors);
            PairNumber = (majorIndex * ColorGroup.Minor.Length) + (minorIndex + 1);
            return PairNumber;
        }
    }
}
