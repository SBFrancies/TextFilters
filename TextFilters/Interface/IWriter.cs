using System;
using System.Collections.Generic;
using System.Text;

namespace TextFilters.Interface
{
    /// <summary>
    /// Writes to a given source.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Write a line to a given source.
        /// </summary>
        /// <param name="value">The line to write.</param>
        public void WriteLine(string value);
    }
}
