namespace Chronicle.Utils
{
    public class Constants
    {
        public class MongoConfig
        {
            public static readonly string DatabaseName =
                Environment.GetEnvironmentVariable("MONGO_DB") ?? "Chronicle";
            public static readonly string ConnectionString =
                Environment.GetEnvironmentVariable("MONGO_URI") ?? "mongodb://localhost:27017";
        }

        public class SqliteConfig
        {
            public static readonly string ConnectionString =
                Environment.GetEnvironmentVariable("SQLITE_URI") ?? "Data Source=chronicle.db";
        }

        public class JwtConfig
        {
            public const string Issuer = "Chronicle.Identity";
            public const string Audience = "Chronicle.Client";
            public const string SigningKey = "super_secret_keysuper_secret_key";
        }
    }
}
