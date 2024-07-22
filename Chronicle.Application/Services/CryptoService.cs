using Chronicle.Domain.Models;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;

namespace Chronicle.Application.Services
{
    public interface ICryptoService
    {
        public Task<CryptoKeyDto> GenerateKeyPairAsync();
    }

    public class CryptoService : ICryptoService
    {
        public Task<CryptoKeyDto> GenerateKeyPairAsync()
        {
            RsaKeyPairGenerator rsaGenerator = new();
            rsaGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));

            AsymmetricCipherKeyPair pair = rsaGenerator.GenerateKeyPair();

            return null;
        }
    }
}
