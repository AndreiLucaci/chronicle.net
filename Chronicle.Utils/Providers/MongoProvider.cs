using MongoDB.Driver;

namespace Chronicle.Utils.Providers
{
    public class MongoProvider
    {
        public static void Initialize()
        {
            Client = new MongoClient(Constants.MongoConfig.ConnectionString);
        }

        public static MongoClient Client
        {
            get
            {
                if (Client == null)
                    throw new Exception("MongoClient is not initialized");
                return Client;
            }
            private set { }
        }
    }
}
