using System;
using System.Collections.Generic;
using System.Text;
using TextFilters.Filters;
using Xunit;

namespace TextFilters.Tests
{
    public class WordLengthFilterTests
    {
        [Theory]
        [InlineData(3, "Thomas", false)]
        [InlineData(3, "the", false)]
        [InlineData(4, "Tank", false)]
        [InlineData(4, "Engine", false)]
        [InlineData(5, "Thomas", false)]
        [InlineData(5, "the", true)]
        [InlineData(6, "Tank", true)]
        [InlineData(6, "Engine", false)]
        public void ContainsLetterFilter_FilterWord_MatchesFilter(int length, string word, bool filter)
        {
            var sut = GetSystemUnderTest(length);

            var result = sut.FilterWord(word);

            Assert.Equal(filter, result);
        }


        private WordLengthFilter GetSystemUnderTest(int i)
        {
            return new WordLengthFilter(i);
        }
    }
}
