using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextFilters.Interface;

namespace TextFilters.Filters
{
    /// <inheritdoc/>
    public class ContainsLetterFilter : ITextFilter
    {
        private char[] ToMatch { get; }

        public ContainsLetterFilter(char[] toMatch)
        {
            ToMatch = toMatch;
        }

        /// <inheritdoc/>
        public bool FilterWord(string word)
        {
            return word.Intersect(ToMatch).Any();
        }
    }
}
