using System.Collections.Generic;
using Xamarin.Forms;

namespace Extra_Tablet2
{
    public static class Constants
    {
        public static Color BorderColor = Color.Gray;
        public static Color DefaultTextColor = Color.Black;

        public const int FramePadding = 20;
        public const int PaletteButtonSize = 30;
        public const int TextBottomPadding = 5;
        public const string FontFamily = "arial";
        public const double FontSize = 16;
        public const double FreeDrawThickness = 3;
        public const string ProjectName = "Extra_Tablet2";         // is it ok ?         Yep
        public const string DefaultImageColor = "beige";
        public const string DifferentColorImagePattern = "{0}_{1}.png";

        /// <summary>
        /// To control shapes sizes
        /// </summary>
        public static readonly Dictionary<string, Size> ShapesSize = new Dictionary<string, Size>
        {
            { "Man.png", new Size(31, 45) },
            { "StopSign.png", new Size(30, 25) },
            { "bus_beige.png", new Size(100, 100) },
            { "man_beige.png", new Size(25, 25) },
            { "golf_beige.png", new Size(70, 70) },
            { "truck_beige.png", new Size(100, 100) },
            { "motorcycle_beige.png", new Size(70, 70) },
            { "TrafficLight.png", new Size(11, 25) },
            { "tl_blank.png", new Size(55, 55) },
            { "tl_green.png", new Size(55, 55) },
            { "tl_yellow.png", new Size(55, 55) },
            { "tl_red.png", new Size(55, 55) },
            { "Arrow.png", new Size(35, 35) },

            { "deadend.png", new Size(35, 35) },
            { "noentry.png", new Size(35, 35) },
            { "noleft.png", new Size(35, 35) },
            { "noright.png", new Size(35, 35) },
            { "nouturn.png", new Size(35, 35) },
            { "priority.png", new Size(35, 35) },
            { "sign.png", new Size(35, 35) },
            { "uturnleft.png", new Size(35, 35) },
            { "uturnright.png", new Size(35, 35) } ,

            { "turn_left.png", new Size(35, 35) },
            { "turn_right.png", new Size(35, 35) } 



        };

        /// <summary>
        /// Shapes with ability to change color with code (should be in one color)
        /// </summary>
        public static readonly HashSet<string> ColorChangeImageSet = new HashSet<string>
        {
            "Arrow.png",
            "Man.png"
        };

        /// <summary>
        /// Shapes with ability to change color with different images according to DifferentColorImagePattern constant
        /// </summary>
        public static readonly HashSet<string> ColorChangeDifferentImageSet = new HashSet<string>
        {
            "bus_beige.png",
            "man_beige.png",
            "golf_beige.png",
            "truck_beige.png",
            "motorcycle_beige.png"
        };

        /// <summary>
        /// Possible colors for shapes with different images
        /// </summary>
        public static readonly Dictionary<Color, string> ColorsForImageSource = new Dictionary<Color, string>
        {
            { Color.Black, "black" },
            { Color.Green, "green" },
            { Color.Red, "red" },
            { Color.Blue, "blue" }
        };
    }
}
