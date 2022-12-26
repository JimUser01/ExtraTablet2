using Extra_Tablet2.Models;
using System.Threading.Tasks;

namespace Extra_Tablet2.Services
{
    public interface IImagePickerService
    {
        /// <summary>
        /// Get chosen image
        /// </summary>
        /// <returns>Selected file object</returns>
        Task<SelectedFileModel> GetImageStreamAsync();
    }
}
