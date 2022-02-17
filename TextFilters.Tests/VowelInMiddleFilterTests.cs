using System;
using System.Collections.Generic;
using System.Text;
using TextFilters.Filters;
using Xunit;

namespace TextFilters.Tests
{
    public class VowelInMiddleFilterTests
    {
        [Theory]
        [InlineData("test", true)]
        [InlineData("testing", false)]
        [InlineData("test-a-test", true)]
        [InlineData("you're", true)]
        [InlineData("the", false)]
        [InlineData("currently", true)]
        public void ContainsLetterFilter_FilterWord_MatchesFilter(string word, bool filter)
        {
            var sut = CreateSystemUnderTest();

            var result = sut.FilterWord(word);

            Assert.Equal(filter, result);
        }

        private VowelInMiddleFilter CreateSystemUnderTest()
        {
            return new VowelInMiddleFilter();
        }
    }
}
