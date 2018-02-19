using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Body.Exceptions
{
    [Serializable]
    internal class VersionNotSupportedException : Exception
    {
        public VersionNotSupportedException(string desiredVersion, IEnumerable<string> availableVersions)
            : this($"The version {desiredVersion} is not supported. Available versions: {availableVersions.ToString()}")
        {
        }

        public VersionNotSupportedException(string message) : base(message)
        {

        }

        public VersionNotSupportedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VersionNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}