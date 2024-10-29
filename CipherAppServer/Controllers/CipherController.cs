using CipherAppServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CipherAppServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CipherController : Controller
    {
        private readonly ILogger<CipherController> _logger;
        private readonly CipherContext _cipherContext;


        public CipherController(ILogger<CipherController> logger, CipherContext cipherContext)
        {
            _logger = logger;
            _cipherContext = cipherContext;
        }

        [HttpPost("encrypt")]
        public IActionResult EncryptMessage([FromBody] CipherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _cipherContext.SetCipherService(request.cipherType);
                var response = _cipherContext.encrypt    (request.data, request.cipherKey);
                return Ok(new { response });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("decrypt")]
        public IActionResult DecryptMessage([FromBody] CipherRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _cipherContext.SetCipherService(request.cipherType);
                var response = _cipherContext.decrypt(request.data, request.cipherKey);
                return Ok(new {response});
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
