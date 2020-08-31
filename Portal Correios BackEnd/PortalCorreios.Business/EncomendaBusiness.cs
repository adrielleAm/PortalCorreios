using Microsoft.AspNetCore.Http;
using PortalCorreios.Domain.Dto;
using PortalCorreios.Interface.Business;
using PortalCorreios.Utils.BusinessException;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalCorreios.Business
{
    public class EncomendaBusiness : IEncomendaBusiness
    {
        private readonly IArquivoBusiness _arquivoBusiness;
        private readonly ITrechosBusiness _trechosBusiness;

        public EncomendaBusiness(IArquivoBusiness arquivoBusiness, ITrechosBusiness trechosBusiness)
        {
            _arquivoBusiness = arquivoBusiness;
            _trechosBusiness = trechosBusiness;
        }

        public async Task<List<string>> CalcularEncomenda(IFormFile arquivo)
        {
            var trechos = await _trechosBusiness.RecuperarTrechos();
            var encomendasString = await _arquivoBusiness.LerLinhasArquivo(arquivo);

            var encomendasDto = ConvertToDto(encomendasString);
            List<string> caminhoEncomendas = new List<string>();

            foreach (var dto in encomendasDto)
                caminhoEncomendas.Add(RecuperarMenorRecurso(dto, trechos));

            return caminhoEncomendas;
        }

        private string RecuperarMenorRecurso(EncomendaDto encomenda, List<TrechoDto> trechos)
        {
            var menorRecurso = new StringBuilder();
            int soma = 0;
            menorRecurso.Append($"{encomenda.Origem} ");

            var origem = trechos.Where(c => c.Origem == encomenda.Origem).ToList();
            var destinos = trechos.Where(c => c.Destino == encomenda.Destino).ToList();
            var linha = origem.FirstOrDefault(o => o.Destino == encomenda.Destino);

            if (linha != null)
                menorRecurso.Append($"{encomenda.Destino}  {linha.TempoViagem}");
            else
            {
                var listaFinal = origem.Concat(destinos).ToList();
                foreach (var item in listaFinal)
                {
                    if (item.Destino == encomenda.Destino)
                    {
                        menorRecurso.Append($"{item.Origem} ");
                        soma += item.TempoViagem + origem.FirstOrDefault(c => c.Destino == item.Origem).TempoViagem;
                    }
                };
            }
            menorRecurso.Append($"{encomenda.Destino} {soma.ToString()} ");
            return menorRecurso.ToString();
        }

        private List<EncomendaDto> ConvertToDto(List<string> encomendas)
        {
            var encomndasList = new List<EncomendaDto>();
            foreach (var encomenda in encomendas)
            {
                string[] values = encomenda.Split(' ').Select(sValue => sValue.Trim()).ToArray();
                if (values.Length >= 2)
                    encomndasList.Add(new EncomendaDto { Origem = values[0], Destino = values[1] });
            }
            return encomndasList;
        }
    }
}