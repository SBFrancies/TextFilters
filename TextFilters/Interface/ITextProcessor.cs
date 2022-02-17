using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TextFilters.Interface
{
    /// <summary>
    /// Processor for text files.
    /// </summary>
    public interface ITextProcessor
    {
        /// <summary>
        /// Process a text file.
        /// </summary>
        /// <param name="filePath">The path of the text file to process.</param>
        /// <returns>The processed text.</returns>
        Task<string> ProcessTextAsync(string filePath);
    }
}
