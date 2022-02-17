using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilters.Interface
{
    /// <summary>
    /// Read from a given source.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Read a line from a given source.
        /// </summary>
        /// <returns>The line read.</returns>
        public string ReadLine();
    }
}
