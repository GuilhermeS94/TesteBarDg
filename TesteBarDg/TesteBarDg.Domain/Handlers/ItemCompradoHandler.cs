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
    public class ItemCompradoHandler : IRequestHandler<ItemCompradoCommand, ItemCompradoResult>
    {
        private readonly IItemCompradoExternalService _itemCompradoExternalService;

        public ItemCompradoHandler(IItemCompradoExternalService itemCompradoExternalService)
        {
            _itemCompradoExternalService = itemCompradoExternalService;
        }

        public async Task<ItemCompradoResult> Handle(ItemCompradoCommand request, CancellationToken cancellationToken)
        {
            var response = await _itemCompradoExternalService.ComprarItem(request.IdComanda, request.IdItem);

            return response.Adapt<ItemCompradoResult>();
        }
    }
}
