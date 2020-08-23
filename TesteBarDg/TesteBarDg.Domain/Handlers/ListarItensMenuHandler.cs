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
    public class ListarItensMenuHandler : IRequestHandler<ListarItensMenuCommand, ListarItensMenuResult>
    {
        private readonly IListarItensMenuExternalService _listarItensMenuExternalService;

        public ListarItensMenuHandler(IListarItensMenuExternalService listarItensMenuExternalService)
        {
            _listarItensMenuExternalService = listarItensMenuExternalService;
        }

        public async Task<ListarItensMenuResult> Handle(ListarItensMenuCommand request, CancellationToken cancellationToken)
        {
            var response = await _listarItensMenuExternalService.ListarItensMenu();

            return response.Adapt<ListarItensMenuResult>();
        }
    }
}
