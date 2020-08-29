using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PortalCorreios.Interface.Business
{
    public interface ITrechosBusiness
    {
        Task UploadArquivo(IFormFile arquivo);
    }
}