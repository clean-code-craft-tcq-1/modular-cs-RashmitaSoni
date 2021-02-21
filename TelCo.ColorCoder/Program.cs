using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoderPair;
namespace TelCo.ColorCoder
{   /// <summary>
    /// This class provides the color coding and mapping of Colors number to color and color to Colors number.
    /// </summary>
    public class ColorGroup
    {
        public static Color[] Major;
        public static Color[] Minor;
        ColorPair colorPair = new ColorPair();
        static ColorGroup()
        {
            Major = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            Minor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        private static void Main(string[] args)
        {
            int pairNumber = 4;
            ColorPair testPair1 = ColorCoderPair.ColorPair.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = ColorCoderPair.ColorPair.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = ColorCoderPair.ColorPair.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = ColorCoderPair.ColorPair.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = ColorCoderPair.ColorPair.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}
