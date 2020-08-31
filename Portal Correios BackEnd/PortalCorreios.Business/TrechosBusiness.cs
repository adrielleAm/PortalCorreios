using Microsoft.AspNetCore.Http;
using PortalCorreios.Domain.Dto;
using PortalCorreios.Interface.Business;
using PortalCorreios.Utils.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PortalCorreios.Business
{
    public class TrechosBusiness : ITrechosBusiness
    {
        private readonly IArquivoBusiness _arquivoBusiness;

        public TrechosBusiness(IArquivoBusiness arquivoBusiness)
        {
            _arquivoBusiness = arquivoBusiness;
        }

        public async Task UploadArquivo(IFormFile arquivo)
        {
            var filePath = Path.Combine(_arquivoBusiness.GetTxtPath(), TrechoTypes.NomeArquivo);

            await _arquivoBusiness.UploadArquivo(arquivo, filePath);
        }

        public async Task<List<TrechoDto>> RecuperarTrechos()
        {
            var filePath = Path.Combine(_arquivoBusiness.GetTxtPath(), TrechoTypes.NomeArquivo);
            var linhas = await _arquivoBusiness.LerLinhasArquivo(filePath);
            List<TrechoDto> trechos = new List<TrechoDto>();

            foreach (var linha in linhas)
            {
                string[] values = linha.Split(' ').Select(sValue => sValue.Trim()).ToArray();
                if (values.Length >= 3)
                    trechos.Add(new TrechoDto { Origem = values[0], Destino = values[1], TempoViagem = Convert.ToInt32(values[2]) });
            }

            return trechos;
        }
    }
}