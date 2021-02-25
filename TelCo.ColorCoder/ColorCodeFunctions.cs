using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoderClasses;
using TelCo.ColorCoderExecptions;
namespace TelCo.ColorCoderFunctions
{ /// <summary>
  /// This class provides the color coding and mapping of Colors number to color and color to Colors number.
  /// </summary>
    public static class ColorCoderFunctions
    {
        public static ColorPair FetchColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorGroup.Minor.Length;
            int majorSize = ColorGroup.Major.Length;
            Exceptions.getArgumentOutOfRangeException(pairNumber, minorSize, majorSize);
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
            int majorIndex = ColorPair.GetMajorColorGroupIndex(Colors); 
            int minorIndex = ColorPair.GetMinorColorGroupIndex(Colors);
            int PairNumber;
            Exceptions.getArgumentException(minorIndex, majorIndex, Colors);
            PairNumber = (majorIndex * ColorGroup.Minor.Length) + (minorIndex + 1);
            return PairNumber;
        }
        public static void PrintReferenceManual()
        {
            for (int i = 1; i <= 25; i++)
            {
                ColorPair colorNames = FetchColorFromPairNumber(i);
                Console.WriteLine("Color Pair Number: {0},Color Name: {1}\n", i, colorNames);
            }
        }
    }
}
