using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Application.Business.Impl.ServiceLibrary.Exceptions
{
    [Serializable]
    public class VuelingApplicationException : Exception
    {
        public VuelingApplicationException()
        {

        }

        public VuelingApplicationException(string message) : base(message)
        {

        }

        public VuelingApplicationException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected VuelingApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
