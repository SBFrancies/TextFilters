using System;
using System.Collections.Generic;
using System.Text;
using TextFilters.Filters;
using Xunit;

namespace TextFilters.Tests
{
    public class ContainsLetterFilterTests
    {
        [Theory]
        [InlineData("tT", "Thomas", true)]
        [InlineData("tT", "the", true)]
        [InlineData("Tt", "Tank", true)]
        [InlineData("tT", "Engine", false)]
        [InlineData("Hh", "Thomas", true)]
        [InlineData("hH", "the", true)]
        [InlineData("hH", "Tank", false)]
        [InlineData("hH", "Engine", false)]
        [InlineData("qzyw", "sdjsdnjsdntwwdnsndsmnd", true)]
        [InlineData("xlp", "sdjsdnjsdnwwdnsndsmnd", false)]
        public void ContainsLetterFilter_FilterWord_MatchesFilter(string toMatch, string word, bool filter)
        {
            var sut = GetSystemUnderTest(toMatch.ToCharArray());

            var result = sut.FilterWord(word);

            Assert.Equal(filter, result);
        }


        private ContainsLetterFilter GetSystemUnderTest(char[] c)
        {
            return new ContainsLetterFilter(c);
        }
    }
}
