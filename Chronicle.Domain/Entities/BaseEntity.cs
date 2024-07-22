using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Chronicle.Domain.Entities
{
    public class BaseEntity
    {
        [JsonPropertyName("_id")]
        [BsonElement("_id")]
        [BsonId]
        [BsonGuidRepresentation(MongoDB.Bson.GuidRepresentation.Standard)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [JsonPropertyName("createdAt")]
        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
