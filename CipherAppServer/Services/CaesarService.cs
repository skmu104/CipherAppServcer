using CipherAppServer.Helpers;
using System.Text;

namespace CipherAppServer.Services
{
    public class CaesarService: ICipherService
    {
        private const int Polarity = 1;
        public string encrypt(string message, string key)
        {
            if (!int.TryParse(key, out var keyNumber))
            {
                throw new ArgumentException("Key for Caesar cipher must be just a number");
            }
            StringBuilder result = new StringBuilder(message.Length);
            foreach (char c in message)
            {
                if (char.IsAsciiLetter(c)) {
                    var asciiFloor = CipherCommonHelper.GetAsciiFloor(c);
                    var asciiCeiling = CipherCommonHelper.GetAsciiCeiling(c);
                    var encodedAscii = (int)c + (keyNumber * Polarity);
                    if (encodedAscii >= asciiCeiling)
                    {
                        encodedAscii = asciiFloor + (encodedAscii - asciiCeiling);
                    }
                    result.Append((char)encodedAscii);
                } else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        public string decrypt(string message, string key)
        {
            if (!int.TryParse(key, out var keyNumber))
            {
                throw new ArgumentException("Key for Caesar cipher must be just a number");
            }
            StringBuilder result = new StringBuilder(message.Length);
            keyNumber = keyNumber % CipherCommonHelper.AlphabetLength;
            foreach (char c in message)
            {
                if (char.IsAsciiLetter(c))
                {
                    var asciiFloor = CipherCommonHelper.GetAsciiFloor(c);
                    var asciiCeiling = CipherCommonHelper.GetAsciiCeiling(c);
                    var decodedAscii = (int)c + (keyNumber * -1 *Polarity);
                    if (decodedAscii < asciiFloor)
                    {
                        decodedAscii = asciiCeiling - (asciiFloor - decodedAscii);
                    }
                    result.Append((char)decodedAscii);
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
