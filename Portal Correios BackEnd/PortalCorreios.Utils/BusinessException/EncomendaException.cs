using System;
using System.Runtime.Serialization;

namespace PortalCorreios.Utils.BusinessException
{
    [Serializable]
    public class EncomendaException : BaseException
    {
        public const string DestinoNaoEncontrado = "O destisno infromado não foi encontrado";

        public EncomendaException()
            : base() { }

        public EncomendaException(string message)
            : base(message) { }

        public EncomendaException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public EncomendaException(string message, Exception innerException)
            : base(message, innerException) { }

        public EncomendaException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected EncomendaException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}