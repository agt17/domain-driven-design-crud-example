using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VuelingExam.Infrastructure.Impl.Repository.Exceptions
{
    [Serializable]
    public class VuelingInfrastructureException : Exception
    {
        public VuelingInfrastructureException()
        {

        }

        public VuelingInfrastructureException(string message) : base(message)
        {

        }

        public VuelingInfrastructureException(string message, Exception innerException) : base(message, innerException)
        {

        }

        protected VuelingInfrastructureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

    }
}
