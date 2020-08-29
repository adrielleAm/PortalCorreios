using System;
using System.Runtime.Serialization;

namespace PortalCorreios.Utils
{
    [Serializable]
    public class TrechoException : Exception
    {
        public TrechoException()
        : base() { }

        public TrechoException(string message)
           : base(message) { }

        public TrechoException(string format, params object[] args)
           : base(string.Format(format, args)) { }

        public TrechoException(string message, Exception innerException)
            : base(message, innerException) { }

        public TrechoException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected TrechoException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}