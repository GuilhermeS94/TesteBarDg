using System;
using MediatR;
using TesteBarDg.Domain.Models;

namespace TesteBarDg.Domain.Commands
{
    public class GerarExtratoCommand : IRequest<GerarExtratoResult>
    {
        public GerarExtratoCommand()
        {
        }

        public long IdComanda { get; set; }
    }
}
