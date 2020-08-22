using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mapster;
using TesteBarDg.Domain.Commands;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.Models;

namespace TesteBarDg.Domain.Handlers
{
    public class ResetarComandaHandler : IRequestHandler<ResetarComandaCommand, ResetarComandaResult>
    {
        private readonly IResetarComandaExternalService _resetarComandaExternalService;
        public ResetarComandaHandler(IResetarComandaExternalService resetarComandaExternalService)
        {
            _resetarComandaExternalService = resetarComandaExternalService;
        }

        public async Task<ResetarComandaResult> Handle(ResetarComandaCommand request, CancellationToken cancellationToken)
        {
            var response = await _resetarComandaExternalService.LimparComanda(request.IdComanda);

            return response.Adapt<ResetarComandaResult>();
        }
    }
}
