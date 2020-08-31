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
        public void Delete(string arquivoCaminho)
        {
            System.IO.File.Delete(arquivoCaminho);
        }

        public async Task Save(IFormFile arquivo, string arquivoCaminho)
        {
            using var stream = System.IO.File.Create(arquivoCaminho);
            await arquivo.CopyToAsync(stream);
        }

        public async Task<string[]> Read(string arquivoCaminho)
        {
            return await System.IO.File.ReadAllLinesAsync(arquivoCaminho, Encoding.UTF8, CancellationToken.None);
        }

        public async Task<List<string>> ReadMemory(IFormFile arquivo)
        {
            var linhas = new List<string>();
            using (var reader = new StreamReader(arquivo.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    linhas.Add(reader.ReadLine().Trim());
            }

            return linhas;
        }
    }
}