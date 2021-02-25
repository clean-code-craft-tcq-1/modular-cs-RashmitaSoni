using System;
using System.Drawing;
using System.Diagnostics;
using TelCo.ColorCoderFunctions;
using TelCo.ColorCoderClasses;

namespace TelCo.ColorCoderTests
{
    public class ColorCoderTest
    {
        private static int pairNumber;
        private static ColorPair colorpair;
        private static Color majorcolor, minorcolor; 
        private static void Main(string[] args)
        {
            TestFetchColorFromPairNumber();
            TestFetchPairNumberFromColor();
            ColorCoderFunctions.ColorCoderFunctions.PrintReferenceManual();
        }
        public static void TestFetchColorFromPairNumber()
        {
            pairNumber = Convert.ToInt32(Console.ReadLine());
            ColorPair testPair1 = ColorCoderFunctions.ColorCoderFunctions.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            if(pairNumber == 4)
            {
                Debug.Assert(testPair1.majorColor == Color.White && testPair1.minorColor == Color.Brown);
            }
            if (pairNumber == 5)
            {
                Debug.Assert(testPair1.majorColor == Color.White && testPair1.minorColor == Color.SlateGray);
            }
            if (pairNumber == 23)
            {
                Debug.Assert(testPair1.majorColor == Color.Violet && testPair1.minorColor == Color.Green);
            }
        }
        public static void TestFetchPairNumberFromColor()
        {
            majorcolor = Color.Yellow;//Color.Red
            minorcolor = Color.Green;//Color.Blue
            colorpair = new ColorPair() { majorColor = majorcolor, minorColor = minorcolor };
            pairNumber = ColorCoderFunctions.ColorCoderFunctions.FetchPairNumberFromColor(colorpair);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", colorpair, pairNumber);
            Debug.Assert(pairNumber == 18 || pairNumber == 6);
        }
    }
}
