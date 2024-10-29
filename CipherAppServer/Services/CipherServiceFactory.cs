using CipherAppServer.Enums;

namespace CipherAppServer.Services
{
    public class CipherServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CipherServiceFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public ICipherService GetCipherService(CipherType cipherType)
        {
            return cipherType switch
            {
                CipherType.vigenere => _serviceProvider.GetRequiredService<VigenereService>(),
                CipherType.caesar => _serviceProvider.GetRequiredService<CaesarService>(),
                _ => throw new ArgumentException("Cipher type invalid")
            };
        }
    }
}
