using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortalCorreios.Domain.Dto;
using PortalCorreios.Utils;

namespace PortalCorreios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrechosController : ControllerBase
    {
        [HttpGet("Trechos")]
        public async Task<IEnumerable<TrechoDto>> Trechos()
        {
            try
            {
                var retorno = await _trechoBussiness.ObterTrechosCadastrados();
                return Ok(retorno);
            }
            catch (TrechoException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}