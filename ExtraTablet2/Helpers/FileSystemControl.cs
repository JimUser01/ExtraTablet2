using System;
using System.IO;

namespace Extra_Tablet2.Helpers
{
    /// <summary>
    /// Helps to access file system
    /// </summary>
    public static class FileSystemControl
    {
        public const string ShapesFolder = "Shapes";

        /// <summary>
        /// Writes shape file
        /// </summary>
        /// <param name="stream">Shape stream</param>
        /// <param name="fileName">Shape filename</param>
        public static void WriteShapeFileFromStream(Stream stream, string fileName)
        {
            using (Stream sw = File.Create(ShapeFilePath(fileName)))
            {
                stream.CopyTo(sw);
            }
        }

        /// <summary>
        /// Creates shape path
        /// </summary>
        /// <param name="fileName">Shape filename</param>
        /// <returns></returns>
        public static string ShapeFilePath(string fileName)
        {
            return Path.Combine(ShapesFolderPath(), fileName);
        }

        /// <summary>
        /// Gets shapes folder
        /// </summary>
        /// <returns></returns>
        public static string ShapesFolderPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ShapesFolder);
        }
    }
}
