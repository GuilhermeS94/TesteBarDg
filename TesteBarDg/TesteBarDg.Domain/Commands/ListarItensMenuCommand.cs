using System;
using MediatR;
using TesteBarDg.Domain.Models;

namespace TesteBarDg.Domain.Commands
{
    public class ListarItensMenuCommand : IRequest<ListarItensMenuResult>
    {
        public ListarItensMenuCommand()
        {
        }
    }
}
