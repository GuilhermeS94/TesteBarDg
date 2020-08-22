using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Domain.ExternalServices
{
    public interface IItemCompradoExternalService
    {
        Task<ItemCompradoResponse> ComprarItem(long idComanda, long idItem);
    }
}
