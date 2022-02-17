using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TextFilters.Interface;

namespace TextFilters.Filters
{
    /// <inheritdoc/>
    public class VowelInMiddleFilter : ITextFilter
    {
        private const string Vowels = "[aeiouAEIOU]";

        /// <inheritdoc/>
        public bool FilterWord(string word)
        {
            if(word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            return Regex.IsMatch(GetMiddle(word), Vowels);
        }

        private string GetMiddle(string word)
        {
            var isEven = word.Length % 2 == 0;
            var centre = word.Length / 2;
            var startIndex = isEven ? centre-1 : centre;
            var endIndex = centre + 1;

            return word[startIndex..endIndex];
        }
    }
}
