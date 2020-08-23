using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ListarItensMenuExternalService : IListarItensMenuExternalService
    {
        public ListarItensMenuExternalService()
        {
        }

        public async Task<ListarItensMenuResponse> ListarItensMenu()
        {
            return new ListarItensMenuResponse();
        }
    }
}
