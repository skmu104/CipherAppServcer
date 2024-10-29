using System.ComponentModel.DataAnnotations;
using CipherAppServer.Enums;

namespace CipherAppServer.Models
{
    public class CipherRequest
    {
        [Required(ErrorMessage = "Cipher strategy type is required")]
        public required CipherType cipherType { get; set; }

        [Required(ErrorMessage = "Cipher key type is required")]
        public required string cipherKey { get; set; }

        [Required(ErrorMessage = "Cipher message type is required")]
        public required string data { get; set; }
    }
}
