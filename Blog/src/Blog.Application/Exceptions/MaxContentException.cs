using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Exceptions
{
    public class MaxContentException : Exception
    {
        public MaxContentException()
        {
        }

        public MaxContentException(string? message) : base(message)
        {
        }

        public MaxContentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MaxContentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
