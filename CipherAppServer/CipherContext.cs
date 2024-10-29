using CipherAppServer.Enums;
using CipherAppServer.Services;

namespace CipherAppServer
{
    public class CipherContext
    {
        private readonly CipherServiceFactory _cipherServiceFactory;
        private ICipherService _cipherService;

        public CipherContext(CipherServiceFactory cipherServiceFactory)
        {
            _cipherServiceFactory = cipherServiceFactory;
        }
        public void SetCipherService(CipherType cipherType)
        {
            _cipherService = _cipherServiceFactory.GetCipherService(cipherType);
        }

        public string encrypt(string message, string key)
        {
            return _cipherService.encrypt(message, key);
        }

        public string decrypt(string message, string key)
        {
            return _cipherService.decrypt(message, key);
        }
    }
}
