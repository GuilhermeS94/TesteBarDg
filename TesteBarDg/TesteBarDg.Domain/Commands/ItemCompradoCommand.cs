using System;
using MediatR;
using TesteBarDg.Domain.Models;

namespace TesteBarDg.Domain.Commands
{
    public class ItemCompradoCommand : IRequest<ItemCompradoResult>
    {
        public ItemCompradoCommand()
        {
        }
        public long IdItem { get; set; }
        public long IdComanda { get; set; }
    }
}
