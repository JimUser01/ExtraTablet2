using System.IO;

namespace Extra_Tablet2.Models
{
    /// <summary>
    /// Selected file model
    /// </summary>
    public class SelectedFileModel
    {
        /// <summary>
        /// Filename
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Mime type
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// Filestream
        /// </summary>
        public Stream FileStream { get; set; }
        /// <summary>
        /// Filename with extension
        /// </summary>
        public string FileNameWithExtension
        {
            get
            {
                if (!string.IsNullOrEmpty(FileName) && !string.IsNullOrEmpty(MimeType))
                {
                    string[] mimeSplit = MimeType.Split('/');
                    if (mimeSplit.Length > 1)
                    {
                        return string.Format("{0}.{1}", FileName, mimeSplit[1]);
                    }
                }
                return null;
            }
        }
    }
}
