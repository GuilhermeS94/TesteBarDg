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
        private const double VALOR_PROMOCIONAL_CERVEJA = 3.0;
        private const double VALOR_PROMOCIONAL_AGUA = 0;
        public GerarExtratoExternalService(BarDgContext barDgContext)
        {
            _barDgContext = barDgContext;
        }

        public async Task<GerarExtratoResponse> GerarExtrato(long idComanda)
        {

            GerarExtratoResponse retorno = new GerarExtratoResponse();

            retorno.ItensComprados = _barDgContext.Compras.Where(x => x.IdComanda.Equals(idComanda)).Select(x => new ItemComprado
            {
                Id = x.IdItem,
                Nome = x.IdItemNavigation.Nome,
                Valor = x.IdItemNavigation.Valor,
                ItemPromocional = x.ItemPromocional
            }).ToList();

            retorno.ItensComprados.ForEach(x => {
                switch (x.Id)
                {
                    case 4:
                        x.Valor = (x.ItemPromocional.Equals(1)) ? VALOR_PROMOCIONAL_AGUA : x.Valor;
                        break;

                    case 1:
                        x.Valor = (x.ItemPromocional.Equals(1)) ? VALOR_PROMOCIONAL_CERVEJA : x.Valor;
                        break;

                    default:
                        break;
                }
            });

            retorno.ValorTotal = retorno.ItensComprados.Sum(x => x.Valor);

            return retorno;
        }
    }
}
