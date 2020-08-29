using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortalCorreios.Repository
{
    public class BaseArquivoRepository
    {
        public void ApagarArquivo(string arquivoCaminho)
        {
            System.IO.File.Delete(arquivoCaminho);
        }

        public async Task CriarArquivo(IFormFile arquivo, string arquivoCaminho)
        {
            using var stream = System.IO.File.Create(arquivoCaminho);
            await arquivo.CopyToAsync(stream);
        }

        public async Task<string[]> LerLinhasArquivo(string arquivoCaminho)
        {
            return await System.IO.File.ReadAllLinesAsync(arquivoCaminho, Encoding.UTF8, CancellationToken.None);
        }

        public async Task<List<string>> LerLinhasArquivoMemoria(IFormFile arquivo)
        {
            List<string> linhas = new List<string>();
            string linha;
            using var sr = new StreamReader(arquivo.ContentType);
            while ((linha = await sr.ReadLineAsync()) != null)
            {
                linhas.Add(linha);
            }

            return linhas;
        }
    }
}