using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ResetarComandaExternalService : IResetarComandaExternalService
    {
        public ResetarComandaExternalService()
        {
        }

        public async Task<ResetarComandaResponse> LimparComanda(long idComanda)
        {
            return new ResetarComandaResponse();
        }
    }
}
