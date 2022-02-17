using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TextFilters.Interface;

namespace TextFilters.Service
{
    /// <inheritdoc/>
    public class TextProcessorService : ITextProcessor
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string MidWordSymbols = "'-";

        private IEnumerable<ITextFilter> TextFilters { get; }
        private IFileSystem FileSystem { get; }

        public TextProcessorService(IFileSystem fileSystem, IEnumerable<ITextFilter> textFilters)
        {
            FileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            TextFilters = textFilters ?? throw new ArgumentNullException(nameof(textFilters));
        }

        /// <inheritdoc/>
        public async Task<string> ProcessTextAsync(string filePath)
        {
            var text = await FileSystem.ReadFileTextAsync(filePath);
            var sb = new StringBuilder();
            var position = 0;
            var word = string.Empty;

            while(position < text.Length)
            {
                var current = text[position];

                if(Alphabet.Contains(current))
                {
                    word += current;
                }

                else if(word.Length > 0 && MidWordSymbols.Contains(current) && !MidWordSymbols.Contains(word[^1]))
                {
                    word += current;
                }

                else
                {
                    if (word.Length > 0)
                    {
                        if (MidWordSymbols.Contains(word[^1]))
                        {
                            AppendWord(word[0..^1], sb);
                            sb.Append(word[^1]);
                        }

                        else
                        {
                            AppendWord(word, sb);
                        }
                    }

                    sb.Append(current);
                    word = string.Empty;
                }
                 
                position++;
            }

            return sb.ToString();
        }

        private void AppendWord(string word, StringBuilder stringBuidler)
        {
            var filterWord = false;

            foreach (var filter in TextFilters)
            {
                if (filter.FilterWord(word))
                {
                    filterWord = true;
                    break;
                }
            }

            if (!filterWord)
            {
                stringBuidler.Append(word);
            }
        }
    }
}

