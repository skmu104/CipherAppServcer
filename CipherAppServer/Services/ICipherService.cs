namespace CipherAppServer.Services
{
    public interface ICipherService
    {
        public string encrypt(string message, string key);

        public string decrypt(string message, string key);
    }
}
