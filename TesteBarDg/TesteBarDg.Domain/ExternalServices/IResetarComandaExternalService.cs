using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Domain.ExternalServices
{
    public interface IResetarComandaExternalService
    {
        Task<ResetarComandaResponse> LimparComanda(long idComanda);
    }
}
