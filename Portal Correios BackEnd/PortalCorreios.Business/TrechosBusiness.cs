using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PortalCorreios.Domain.Dto;
using PortalCorreios.Interface.Business;
using PortalCorreios.Utils.Types;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<TrechoDto> RecuperarTrechos()
        {
            var filePath = Path.Combine(_arquivoBusiness.GetTxtPath(), TrechoTypes.NomeArquivo);

            return new List<TrechoDto>();
        }
    }
}