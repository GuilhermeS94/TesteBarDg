using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;
using TesteBarDg.Infra.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class ResetarComandaExternalService : IResetarComandaExternalService
    {
        private readonly BarDgContext _barDgContext;

        public ResetarComandaExternalService(BarDgContext barDgContext)
        {
            _barDgContext = barDgContext;
        }

        public async Task<ResetarComandaResponse> LimparComanda(long idComanda)
        {
            _barDgContext.Compras.Remove(_barDgContext.Compras.Find(idComanda));

            return new ResetarComandaResponse
            {
                Sucesso = true,
                Mensagem = "Compra registrada com sucesso."
            };
        }
    }
}
