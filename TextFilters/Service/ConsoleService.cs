using System;
using System.Collections.Generic;
using System.Text;
using TextFilters.Interface;

namespace TextFilters.Service
{
    /// <summary>
    /// Service to interact with the Console.
    /// </summary>
    public class ConsoleService : IReader, IWriter
    {
        /// <inheritdoc/>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <inheritdoc/>
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
