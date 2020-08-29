using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalCorreios.Interface.Business;
using PortalCorreios.Utils;

namespace PortalCorreios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrechosController : ControllerBase
    {
        private readonly ITrechosBusiness _trechosBusiness;

        public TrechosController(ITrechosBusiness trechoBusiness)
        {
            _trechosBusiness = trechoBusiness;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync(IFormFile arquivo)
        {
            try
            {
                await _trechosBusiness.UploadArquivo(arquivo);
                return Ok();
            }
            catch (ArquivoException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}