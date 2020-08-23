using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;
using TesteBarDg.Infra.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class GerarExtratoExternalService : IGerarExtratoExternalService
    {
        private readonly BarDgContext _barDgContext;
        public GerarExtratoExternalService(BarDgContext barDgContext)
        {
            _barDgContext = barDgContext;
        }

        public async Task<GerarExtratoResponse> GerarExtrato(long idComanda)
        {
            ICollection<Compras> lista = _barDgContext.Compras.ToList();

            GerarExtratoResponse retorno = new GerarExtratoResponse();

            retorno.ValorTotal = lista.Sum(x => x.IdItemNavigation.Valor);

            retorno.ItensComprados = lista.Select(x => new ItemComprado
            {
                Id = x.IdItemNavigation.Id,
                Nome = x.IdItemNavigation.Nome,
                Valor = x.IdItemNavigation.Valor
            }).ToList();

            return retorno;
        }
    }
}
