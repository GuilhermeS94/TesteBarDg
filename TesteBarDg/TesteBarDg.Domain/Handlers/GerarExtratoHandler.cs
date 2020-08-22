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
    public class GerarExtratoHandler : IRequestHandler<GerarExtratoCommand, GerarExtratoResult>
    {
        private readonly IGerarExtratoExternalService _gerarExtratoExternalService;

        public GerarExtratoHandler(IGerarExtratoExternalService gerarExtratoExternalService)
        {
            _gerarExtratoExternalService = gerarExtratoExternalService;
        }

        public async Task<GerarExtratoResult> Handle(GerarExtratoCommand request, CancellationToken cancellationToken)
        {
            var response = await _gerarExtratoExternalService.GerarExtrato(request.IdComanda);

            return response.Adapt<GerarExtratoResult>();
        }
    }
}
