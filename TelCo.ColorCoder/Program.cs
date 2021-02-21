using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    /// <summary>
    /// The 25-colorName color code, originally known as even-count color code, 
    /// is a color code used to identify individual conductors in twisted-colorName 
    /// wiring for telecommunications.
    /// This class provides the color coding and 
    /// mapping of colorName number to color and color to colorName number.
    /// </summary>
    public class ColorGroup
    {
        private static Color[] Major;
        private static Color[] Minor;
     
        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        static ColorGroup()
        {
            Major = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            Minor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        private static ColorPair FetchColorFromPairNumber(int pairNumber)
        {

            int minorSize = Minor.Length;
            int majorSize = Major.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
           
            int majorIndex = (pairNumber - 1) / minorSize;
            int minorIndex = (pairNumber - 1) % minorSize;

            ColorPair Colors = new ColorPair()
            {
                majorColor = Major[majorIndex],
                minorColor = Minor[minorIndex]
            };

            return Colors;
        }
        private static int FetchPairNumberFromColor(ColorPair colorName)
        {

            int majorIndex = -1, minorIndex = -1;
            int PairNumber;

            for (int i = 0; i < Major.Length; i++)
            {
                if (Major[i] == colorName.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            
            for (int i = 0; i < Minor.Length; i++)
            {
                if (Minor[i] == colorName.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown colorName: {0}", colorName.ToString()));
            }

            PairNumber = (majorIndex * Minor.Length) + (minorIndex + 1);
            return PairNumber;
        }
        private static void Main(string[] args)
        {
            int pairNumber = 4;
            ColorPair testPair1 = ColorGroup.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] colorName: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = ColorGroup.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] colorName: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = ColorGroup.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] colorName: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = ColorGroup.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]colorName: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = ColorGroup.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]colorName: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}
