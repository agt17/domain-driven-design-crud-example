using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Domain.Impl.Services.Exceptions
{
    [Serializable]
    public class VuelingDomainException : Exception
    {
        public VuelingDomainException()
        {

        }

        public VuelingDomainException(string message) : base(message)
        {

        }

        public VuelingDomainException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected VuelingDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
