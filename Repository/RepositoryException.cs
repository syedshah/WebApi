using System;
using System.Runtime.Serialization;

namespace Repository
{
    [Serializable]
    public class RepositoryException : Exception
    {
        public RepositoryException()
        {
        }

        public RepositoryException(String message)
            : base(message)
        {
        }

        public RepositoryException(String message, Exception inner)
            : base(message, inner)
        {
        }

        protected RepositoryException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}