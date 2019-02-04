using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Exceptions
{
    public class ApiErrorException : Exception
    {
        public ApiErrorException()
        {
        }

        public ApiErrorException(string message)
            : base(message)
        {
        }

        public ApiErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
