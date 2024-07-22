namespace Chronicle.Utils
{
    public static class MongoCollections
    {
        public const string Users = nameof(Users);
    }

    public class KnownMongoCollections
    {
        private string Value { get; }

        private KnownMongoCollections(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public static explicit operator string(KnownMongoCollections collection)
        {
            return collection.Value;
        }

        public static explicit operator KnownMongoCollections(string value)
        {
            return new KnownMongoCollections(value);
        }

        public override bool Equals(object? obj)
        {
            return obj is KnownMongoCollections collection && Value == collection.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(KnownMongoCollections left, KnownMongoCollections right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KnownMongoCollections left, KnownMongoCollections right)
        {
            return !left.Equals(right);
        }

        public static KnownMongoCollections Users { get; } =
            new KnownMongoCollections(nameof(Users));
    }
}
