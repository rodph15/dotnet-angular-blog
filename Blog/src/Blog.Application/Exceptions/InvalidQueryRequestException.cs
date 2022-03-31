using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class InvalidQueryRequestException : Exception
    {
        public InvalidQueryRequestException()
        {
        }

        public InvalidQueryRequestException(string? message) : base(message)
        {
        }

        public InvalidQueryRequestException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidQueryRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
