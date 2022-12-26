namespace Extra_Tablet2.Models
{
    /// <summary>
    /// Represents MapItem as Image
    /// </summary>
    public class MapItemImageModel : MapItemModel
    {
        /// <summary>
        /// Image source
        /// </summary>
        public string ImageSource { get; set; }

        /// <summary>
        /// Shape type
        /// </summary>
        public ShapeType ShapeType { get; set; }
    }
}
