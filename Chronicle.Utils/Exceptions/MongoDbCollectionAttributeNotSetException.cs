using System.Runtime.Serialization;

namespace Chronicle.Utils.Exceptions
{
    public class MongoDbCollectionAttributeNotSetException : Exception
    {
        public MongoDbCollectionAttributeNotSetException() { }

        public MongoDbCollectionAttributeNotSetException(string? message)
            : base(message) { }

        public MongoDbCollectionAttributeNotSetException(string? message, Exception? innerException)
            : base(message, innerException) { }

        protected MongoDbCollectionAttributeNotSetException(
            SerializationInfo info,
            StreamingContext context
        )
            : base(info, context) { }
    }
}
