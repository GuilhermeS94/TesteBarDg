using System;
using MediatR;
using TesteBarDg.Domain.Models;

namespace TesteBarDg.Domain.Commands
{
    public class ResetarComandaCommand : IRequest<ResetarComandaResult>
    {
        public ResetarComandaCommand()
        {
        }

        public long IdComanda { get; set; }
    }
}
