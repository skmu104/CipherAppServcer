using System.Text;
using CipherAppServer.Helpers;
using System.Text.RegularExpressions;


namespace CipherAppServer.Services
{
    public class VigenereService : ICipherService
    {
        public string encrypt(string message, string key)
        {
            var key_index = 0;
            if (!(Regex.IsMatch(key, @"^[A-Za-z]+$")))
            {
                throw new ArgumentException("Key for Vignere cipher must be made up of only alphabets");
            }
            key = key.ToLower();
            StringBuilder result = new StringBuilder(message.Length);
            foreach (char c in message)
            {
                if (char.IsAsciiLetter(c))
                {
                    var asciiFloor = CipherCommonHelper.GetAsciiFloor(c);
                    var asciiCeiling = CipherCommonHelper.GetAsciiCeiling(c);
                    var offset = key[key_index] - CipherCommonHelper.LowerAsciiFloor;
                    var encodedAscii = (int)c + offset;
                    if (encodedAscii >= asciiCeiling)
                    {
                        encodedAscii = asciiFloor + (encodedAscii - asciiCeiling);
                    }
                    result.Append((char)encodedAscii);
                    key_index++;
                    if (key_index == key.Length)
                    {
                        key_index = 0;
                    }
                }
                else
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }

        public string decrypt(string message, string key)
        {
            var key_index = 0;
            if (!(Regex.IsMatch(key, @"^[A-Za-z]+$")))
            {
                throw new ArgumentException("Key for Vignere cipher must be made up of only alphabets");
            }
            key = key.ToLower();
            StringBuilder result = new StringBuilder(message.Length);
            foreach (char c in message)
            {
                if (char.IsAsciiLetter(c))
                {
                    var asciiFloor = CipherCommonHelper.GetAsciiFloor(c);
                    var asciiCeiling = CipherCommonHelper.GetAsciiCeiling(c);
                    var offset = key[key_index] - CipherCommonHelper.LowerAsciiFloor;
                    var decodedAscii = (int)c - offset;
                    if (decodedAscii < asciiFloor)
                    {
                        decodedAscii = asciiCeiling - (asciiFloor - decodedAscii);
                    }
                    result.Append((char)decodedAscii);
                    key_index++;
                    if (key_index == key.Length)
                    {
                        key_index = 0;
                    }
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
