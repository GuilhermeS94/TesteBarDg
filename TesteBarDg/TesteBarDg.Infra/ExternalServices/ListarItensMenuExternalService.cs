using System;
using System.Linq;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;
using TesteBarDg.Infra.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ListarItensMenuExternalService : IListarItensMenuExternalService
    {
        private readonly BarDgContext _barDgContext;

        public ListarItensMenuExternalService(BarDgContext barDgContext)
        {
            _barDgContext = barDgContext;
        }

        public async Task<ListarItensMenuResponse> ListarItensMenu()
        {
            ListarItensMenuResponse retorno = new ListarItensMenuResponse();
            retorno.ItensMenu = _barDgContext.Itens.Select(x => new Item {
                Id = x.Id,
                Nome = x.Nome,
                Valor = x.Valor
            }).ToList();

            return retorno;
        }
    }
}
