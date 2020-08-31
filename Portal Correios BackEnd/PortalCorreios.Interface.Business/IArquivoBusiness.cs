using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCorreios.Interface.Business
{
    public interface IArquivoBusiness
    {
        string GetTxtPath();

        Task UploadArquivo(IFormFile arquivo, string filePath);

        Task<string[]> LerLinhasArquivo(string arquivoCaminho);

        Task<List<string>> LerLinhasArquivo(IFormFile arquivo);
    };
}