using System.Runtime.Serialization;

namespace Chronicle.Utils.Exceptions
{
    public class MongoDbConnectionUriNotSet : Exception
    {
        public MongoDbConnectionUriNotSet() { }

        public MongoDbConnectionUriNotSet(string? message)
            : base(message) { }

        public MongoDbConnectionUriNotSet(string? message, Exception? innerException)
            : base(message, innerException) { }

        protected MongoDbConnectionUriNotSet(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
