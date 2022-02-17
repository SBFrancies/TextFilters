using System;
using System.Collections.Generic;
using System.Text;
using TextFilters.Interface;

namespace TextFilters.Filters
{
    /// <inheritdoc/>
    public class WordLengthFilter : ITextFilter
    {
        private int MinWordLength { get; }

        public WordLengthFilter(int minWordLength)
        {
            MinWordLength = minWordLength;
        }

        /// <inheritdoc/>
        public bool FilterWord(string word)
        {
            if(word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return word.Length < MinWordLength;
        }
    }
}
