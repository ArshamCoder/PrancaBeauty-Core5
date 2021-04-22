using System;
using System.Runtime.Serialization;

namespace PrancaBeauty.Application.Exceptions
{
    public class ArgumentInvalidException : Exception
    {
        //public override string Message { get; }
        public ArgumentInvalidException()
        {
            // Message = "";
        }

        public ArgumentInvalidException(string message) : base(message)
        {

        }

        public ArgumentInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
