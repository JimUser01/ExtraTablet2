using Extra_Tablet2.ViewModels;
using System.Collections.Generic;

namespace Extra_Tablet2.Services
{
    public interface IMediaService
    {
        /// <summary>
        /// Save image
        /// </summary>
        /// <param name="mapItems">Images with coordinates</param>
        /// <param name="fileName">File name</param>
        /// <param name="overlayData">Overlay image</param>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
       // ολδ  void SaveImage(List<MapItemViewModel> mapItems, string fileName, byte[] overlayData, int width, int height);
        byte[] SaveImage(List<MapItemViewModel> mapItems, string fileName, byte[] overlayData, int width, int height);


    }
}
