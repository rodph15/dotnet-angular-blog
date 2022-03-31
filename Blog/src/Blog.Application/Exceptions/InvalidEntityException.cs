using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException()
        {
        }

        public InvalidEntityException(string? message) : base(message)
        {
        }

        public InvalidEntityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
