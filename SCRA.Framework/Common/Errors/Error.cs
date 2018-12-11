using System;

namespace SCRA.Framework.Common.Errors
{
    [Serializable]
    public class Error
    {
        private readonly Exception _exception;

        internal Error(string identifier, Exception exception,
            string message, params object[] arguments)
        {
            Identifier = identifier;
            _exception = exception;
            Message = message;
            Arguments = arguments;
        }

        internal Error(string identifier,
            string message, params object[] arguments)
        {
            Identifier = identifier;
            Message = message;
            Arguments = arguments;
        }

        public string Identifier { get; private set; }
        public string Message { get; private set; }
        public object[] Arguments { get; private set; }

        public Exception GetException()
        {
            return _exception;
        }
    }
}