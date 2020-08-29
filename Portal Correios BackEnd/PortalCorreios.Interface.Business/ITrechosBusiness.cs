using Microsoft.AspNetCore.Http;
using PortalCorreios.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCorreios.Interface.Business
{
    public interface ITrechosBusiness
    {
        Task UploadArquivo(IFormFile arquivo);

        Task<List<TrechoDto>> RecuperarTrechos();
    }
}