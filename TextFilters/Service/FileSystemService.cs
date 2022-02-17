using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TextFilters.Interface;

namespace TextFilters.Service
{
    /// <inheritdoc/>
    public class FileSystemService : IFileSystem
    {
        /// <inheritdoc/>
        public async Task<string> ReadFileTextAsync(string filePath)
        {
            if(filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            return await File.ReadAllTextAsync(filePath);
        }
    }
}
