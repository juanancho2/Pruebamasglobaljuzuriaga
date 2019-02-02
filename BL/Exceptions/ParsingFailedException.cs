using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Exceptions
{
    public class ParsingFailedException : Exception
    {
        public ParsingFailedException()
        {
        }

        public ParsingFailedException(string message)
            : base(message)
        {
        }

        public ParsingFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
