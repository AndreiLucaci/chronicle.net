using System.Text.Json.Serialization;
using Chronicle.Utils;
using Chronicle.Utils.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace Chronicle.Domain.Entities
{
    [BsonCollection(MongoCollections.Users)]
    public class UserEntity : Microsoft.AspNetCore.Identity.IdentityUser
    // public class UserEntity : BaseEntity
    {
        public UserEntity(string email, string name)
        {
            Email = email;
            Name = name;
        }

        public UserEntity() { }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [BsonElement("email")]
        [JsonPropertyName("email")]
        public required string Email { get; set; }
    }
}
