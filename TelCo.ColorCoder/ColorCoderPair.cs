using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoder;

namespace TelCo.ColorCoderPair
{
    public class ColorPair
    {
        internal Color majorColor;
        internal Color minorColor;
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
        public static ColorPair FetchColorFromPairNumber(int pairNumber)
        {

            int minorSize = ColorGroup.Minor.Length;
            int majorSize = ColorGroup.Major.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

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
                {
                    minorIndex = i;
                    break;
                }
            }

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", Colors.ToString()));
            }

            PairNumber = (majorIndex * ColorGroup.Minor.Length) + (minorIndex + 1);
            return PairNumber;
        }
    }
}
