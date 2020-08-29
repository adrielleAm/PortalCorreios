using System;
using System.Runtime.Serialization;

namespace PortalCorreios.Utils
{
    [Serializable]
    public class ArquivoException : Exception
    {
        public const string TamanhoExcedido = "Arquivo muito grande";
        public const string DiretorioNaoEncontrado = "A pasta informada não foi encontrada";

        public ArquivoException()
        : base() { }

        public ArquivoException(string message)
           : base(message) { }

        public ArquivoException(string format, params object[] args)
           : base(string.Format(format, args)) { }

        public ArquivoException(string message, Exception innerException)
            : base(message, innerException) { }

        public ArquivoException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        protected ArquivoException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}