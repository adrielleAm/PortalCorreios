using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalCorreios.Interface.Business;
using PortalCorreios.Utils;

namespace PortalCorreios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncomendasController : ControllerBase
    {
        private readonly IEncomendaBusiness _encomendaBusiness;

        public EncomendasController(IEncomendaBusiness encomendaBusiness)
        {
            _encomendaBusiness = encomendaBusiness;
        }

        [HttpPost("CalcularEncomenda")]
        public async Task<IActionResult> CalcularEncomenda(IFormFile arquivo)
        {
            try
            {
                var retorno = await _encomendaBusiness.CalcularEncomenda(arquivo);
                return Ok(retorno);
            }
            catch (ArquivoException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}