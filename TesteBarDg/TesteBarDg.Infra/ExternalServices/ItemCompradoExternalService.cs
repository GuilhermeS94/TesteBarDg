using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ItemCompradoExternalService : IItemCompradoExternalService
    {
        public ItemCompradoExternalService()
        {
        }

        public async Task<ItemCompradoResponse> ComprarItem(long idComanda, long idItem)
        {
            return new ItemCompradoResponse();
        }
    }
}
