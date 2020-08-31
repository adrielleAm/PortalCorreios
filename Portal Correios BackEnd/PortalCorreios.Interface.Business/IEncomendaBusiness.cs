using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCorreios.Interface.Business
{
    public interface IEncomendaBusiness
    {
        Task<List<string>> CalcularEncomenda(IFormFile arquivo);
    }
}