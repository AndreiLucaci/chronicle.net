using System.Text.Json.Serialization;

namespace Chronicle.Domain.Models
{
    public record CryptoKeyDto(
        [property: JsonPropertyName("key")] string PublicKey,
        [property: JsonPropertyName("secret")] string PrivateKey
    );
}
