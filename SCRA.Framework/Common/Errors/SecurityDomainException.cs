using System;

namespace SCRA.Framework.Common.Errors
{
    [Serializable]
    public class SecurityDomainException : Exception
    {
        public SecurityDomainException() : base() { }
        public SecurityDomainException(string message) : base(message) { }
        public SecurityDomainException(string message, System.Exception inner) : base(message, inner) { }

        protected SecurityDomainException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
