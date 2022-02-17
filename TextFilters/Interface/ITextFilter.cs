using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilters.Interface
{
    /// <summary>
    /// Filter text.
    /// </summary>
    public interface ITextFilter
    {
        /// <summary>
        /// Check whether a piece of text should be filtered.
        /// </summary>
        /// <param name="word">The text to be filtered.</param>
        /// <returns>Should the text be filtered.</returns>
        bool FilterWord(string word);
    }
}
