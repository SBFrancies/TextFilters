using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextFilters.Interface
{
    /// <summary>
    /// Represents interactions with the file system.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Read the text of the file.
        /// </summary>
        /// <param name="filePath">The file path of the file to read.</param>
        /// <returns></returns>
        Task<string> ReadFileTextAsync(string filePath);
    }
}
