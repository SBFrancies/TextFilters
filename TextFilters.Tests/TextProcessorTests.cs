using Moq;
using System;
using System.Threading.Tasks;
using TextFilters.Filters;
using TextFilters.Interface;
using TextFilters.Service;
using Xunit;

namespace TextFilters.Tests
{
    public class TextProcessorTests
    {
        private const string TestString = @"Alice was beginning to get very tired of sitting by her sister on the bank, and of having nothing to do: once or twice
she had peeped into the book her sister was reading, but it had no pictures or conversations in it, 'and what is the
use of a book,' thought Alice 'without pictures or conversation?'So she was considering in her own mind (as well
as she could, for the hot day made her feel very sleepy and stupid), whether the pleasure of making a daisy chain
would be worth the trouble of getting up and picking the daisies, when suddenly a White Rabbit with pink eyes
ran close by her.There was nothing so very remarkable in that; nor did Alice cross think it so very much out of the
way to hear the Rabbit say to itself, 'Oh dear! Oh dear! I shall be late!' (when she thought it over afterwards, it
occurred to her that she ought to have wondered at this, but at the time it all seemed quite natural); but when
the Rabbit actually took a watchout of its waistcoat pocket, and looked at it, and then hurried on, Alice started
to her feet, for it flashed across her mind that she had never before seen a rabbit with either a waistcoat pocket,
or a watch to take out of it, and burning with curiosity, she ran across the field after it, and fortunately was just in
time to see it pop down a large rabbit hole under the hedge.In another moment down went Alice after it, never
med once considering how in the world self she was to get out again.The rabbit hole went straight on like a tunnel
for some way, and then dipped suddenly down, so suddenly that Alice had not a moment to think about stopping
herself before she found herself falling down a very deep well.Either the well was very deep, or she fell very slowly,
for she had plenty of time as she went down to look about her and to wonder what was going to happen next.
First, she tried to look down and make out what she was coming to, but it was too dark to see anything; then she
looked at the sides of the well, and noticed that they were filled with cupboards and book shelves; here and there
she saw maps and pictures hung upon pegs. She took down a jar from one of the shelves as she passed; it was
labelled `ORANGE MARMALADE', but to her great disappointment it was empty: she did not like to drop the jar
for fear of killing somebody, so managed to put it into one of the cupboards as she fell past it.";

        private const string ExpectedResult =
            @"  beginning            , and     : once  
she         reading,         , 'and   
use   ,'   '   ?' she  considering   own  ( 
 she ,          and ),        
        and picking  daisies,        
   .     remarkable  ;            
       , ' !  !    !' ( she    , 
    she      ,      all   );  
         , and   , and  hurried ,  
  ,   flashed     she  never         ,
       , and burning  , she      , and    
       large   under  hedge.       , never
 once considering    world  she     .        
  , and  dipped  ,            
herself  she  herself falling     .     ,  she   ,
 she      she       and  wonder     happen .
, she     and    she   ,        ;  she
   sides   , and     filled   and  shelves;  and 
she   and    . She      one   shelves  she passed;  
 ` ',        : she       
   killing ,       one     she   .";

        private readonly Mock<IFileSystem> _mockFileSystem = new Mock<IFileSystem>();
        private readonly ITextFilter _filter1 = new ContainsLetterFilter(new[] { 't', 'T' });
        private readonly ITextFilter _filter2 = new VowelInMiddleFilter();
        private readonly ITextFilter _filter3 = new WordLengthFilter(3);

        [Fact]
        public async Task TextProcessorService_ProcessTextAsync_GivenTestCase()
        {
            var filePath = "C:/test/test.txt";
            _mockFileSystem.Setup(a => a.ReadFileTextAsync(filePath)).ReturnsAsync(TestString);

            var sut = GetSystemUnderTest();

            var result = await sut.ProcessTextAsync(filePath);

            _mockFileSystem.Verify(a => a.ReadFileTextAsync(filePath), Times.Once);
            Assert.Equal(ExpectedResult, result);
        }

        [Theory]
        [InlineData("TEST", "")]
        [InlineData("'TEST' you're", "'' ")]
        [InlineData("'TEST' you're once as a", "''  once  ")]
        public async Task TextProcessorService_ProcessTextAsync_FurtherTestCases(string input, string output)
        {
            var filePath = "C:/test/test.txt";
            _mockFileSystem.Setup(a => a.ReadFileTextAsync(filePath)).ReturnsAsync(input);

            var sut = GetSystemUnderTest();

            var result = await sut.ProcessTextAsync(filePath);

            _mockFileSystem.Verify(a => a.ReadFileTextAsync(filePath), Times.Once);
            Assert.Equal(output, result);
        }

        private TextProcessorService GetSystemUnderTest()
        {
            return new TextProcessorService(_mockFileSystem.Object, new [] {_filter1, _filter2, _filter3});
        }
    }
}
