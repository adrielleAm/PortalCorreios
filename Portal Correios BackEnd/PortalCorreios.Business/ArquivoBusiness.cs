using Microsoft.AspNetCore.Http;
using PortalCorreios.Interface.Business;
using PortalCorreios.Interface.Repository;
using PortalCorreios.Utils;
using PortalCorreios.Utils.Helpers;
using System.IO;
using System.Threading.Tasks;

namespace PortalCorreios.Business
{
    public class ArquivoBusiness : IArquivoBusiness
    {
        private readonly IArquivoRepository _arquivoRepository;

        public ArquivoBusiness(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public string GetTxtPath()
        {
            var startDirectory =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            return startDirectory + @"\arquivos\";
        }

        public async Task<string[]> LerLinhasArquivo(string arquivoCaminho)
        {
            try
            {
                return await _arquivoRepository.LerLinhasArquivo(arquivoCaminho);
            }
            catch (FileNotFoundException ex)
            {
                throw new ArquivoException(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new ArquivoException(($"{ArquivoException.DiretorioNaoEncontrado}: '{ex.Message}')"));
            }
            catch (IOException ex)
            {
                throw new ArquivoException(ex.Message);
            }
        }

        public async Task UploadArquivo(IFormFile arquivo, string filePath)
        {
            try
            {
                if (arquivo?.Length > 0)
                {
                    if (ArquivoHelpers.ConvertBytesToMegabytes(arquivo.Length) > 2)
                        throw new ArquivoException(ArquivoException.TamanhoExcedido);

                    if (File.Exists(filePath))
                        _arquivoRepository.ApagarArquivo(filePath);

                    await _arquivoRepository.CriarArquivo(arquivo, filePath);
                }
            }
            catch (IOException ex)
            {
                throw new ArquivoException(ex.Message);
            }
            catch (ArquivoException ex)
            {
                throw new ArquivoException(ex.Message);
            }
        }
    }
}