using System;
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
            int majorIndex = getIndex(ColorGroup.Major, Colors.majorColor); 
            int minorIndex = getIndex(ColorGroup.Minor, Colors.minorColor);
            int PairNumber;
            AnyExceptions.getArgumentException(minorIndex, majorIndex, Colors);
            PairNumber = (majorIndex * ColorGroup.Minor.Length) + (minorIndex + 1);
            return PairNumber;
        }
        public static int getIndex(ColorGroup [] Group, ColorPair Colors)
        {
            int index = -1;
            for (int i = 0; i < Group.Length; i++)
            {
                if (Group[i] == Colors.majorColor)
                {
                    index = i;
                    break;
                }
            }
            return index; 
        }
    }
}
