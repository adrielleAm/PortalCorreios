using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCorreios.Interface.Repository
{
    public interface IArquivoRepository
    {
        void ApagarArquivo(string filePath);

        Task CriarArquivo(IFormFile arquivo, string filePath);

        Task<string[]> LerLinhasArquivo(string arquivoCaminho);

        Task<List<string>> LerLinhasArquivoMemoria(IFormFile arquivo);
    }
}