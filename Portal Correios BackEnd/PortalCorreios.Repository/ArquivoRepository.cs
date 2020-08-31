using Microsoft.AspNetCore.Http;
using PortalCorreios.Interface.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalCorreios.Repository
{
    public class ArquivoRepository : BaseArquivoRepository, IArquivoRepository
    {
        public ArquivoRepository() : base()
        {
        }

        public void ApagarArquivo(string filePath)
        {
            Delete(filePath);
        }

        public async Task CriarArquivo(IFormFile arquivo, string filePath)
        {
            await Save(arquivo, filePath);
        }

        public async Task<string[]> LerLinhasArquivo(string arquivoCaminho)
        {
            return await Read(arquivoCaminho);
        }

        public async Task<List<string>> LerLinhasArquivoMemoria(IFormFile arquivo)
        {
            return await ReadMemory(arquivo);
        }
    }
}