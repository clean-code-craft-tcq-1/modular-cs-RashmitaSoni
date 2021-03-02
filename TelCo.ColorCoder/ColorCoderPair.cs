using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoderClasses
{ 
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
    }
    public class ColorPair
    {
        internal Color majorColor, minorColor;
        public static int GetMajorColorGroupIndex(ColorPair Colors, int majorIndex = -1)
        {
            for (int i = 0; i < ColorGroup.Major.Length; i++)
            {
                if (ColorGroup.Major[i] == Colors.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            return majorIndex;
        }
        public static int GetMinorColorGroupIndex(ColorPair Colors, int minorIndex = -1)
        {
            for (int i = 0; i < ColorGroup.Minor.Length; i++)
            {
                if (ColorGroup.Minor[i] == Colors.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            return minorIndex;
        }
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
    }
}
