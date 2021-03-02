using System;
using System.Drawing;
using System.Diagnostics;
using TelCo.ColorCodeMappers;
using TelCo.ColorCoderClasses;

namespace TelCo.ColorCoderTests
{
    public class ColorCoderTest
    {
        private static int pairNumber;
        private static void Main(string[] args)
        {
            TestFetchColorFromPairNumber();
            TestFetchPairNumberFromColor();
            ColorCodeMappers.ColorCodeMappers.PrintReferenceManual();
        }
        public static void TestFetchColorFromPairNumber()
        {
            pairNumber = 4;
            ColorPair testPair1 = ColorCodeMappers.ColorCodeMappers.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White && testPair1.minorColor == Color.Brown);
            pairNumber = 5;
            testPair1 = ColorCodeMappers.ColorCodeMappers.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White && testPair1.minorColor == Color.SlateGray);
            pairNumber = 23;
            testPair1 = ColorCodeMappers.ColorCodeMappers.FetchColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet && testPair1.minorColor == Color.Green);
        }
        public static void TestFetchPairNumberFromColor()
        {
            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = ColorCodeMappers.ColorCodeMappers.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);
            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = ColorCodeMappers.ColorCodeMappers.FetchPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}
