using System;
using Xamarin.Forms;

namespace Extra_Tablet2.Models
{
    /// <summary>
    /// MapItem model
    /// </summary>
    public class MapItemModel
    {
        /// <summary>
        /// X-coordinate
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Y-coordinate
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Width
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Angle
        /// </summary>
        public double Angle { get; set; }
        /// <summary>
        /// Color
        /// </summary>
        public Color? Color { get; set; }
        /// <summary>
        /// Vertical padding
        /// </summary>
        public double VerticalPadding
        {
            get
            {
                double maxSize = Math.Max(Width, Height);
                return (maxSize - Height) / 2 + Constants.FramePadding;
            }
        }
        /// <summary>
        /// Horizontal padding
        /// </summary>
        public double HorizontalPadding
        {
            get
            {
                double maxSize = Math.Max(Width, Height);
                return (maxSize - Width) / 2 + Constants.FramePadding;
            }
        }
    }
}
