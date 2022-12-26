using System.Collections.Generic;

namespace Extra_Tablet2.Models
{
    /// <summary>
    /// Represents MapItem as Path
    /// </summary>
    public class MapItemPathModel : MapItemModel
    {
        /// <summary>
        /// Path data
        /// </summary>
        public List<string> PathData { get; set; }
    }
}
