using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoderClasses
{ /// <summary>
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
    }
    public class ColorPair
    {
        internal Color majorColor, minorColor;
        public override string ToString()
        {
            return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
        }
    }
       
}
