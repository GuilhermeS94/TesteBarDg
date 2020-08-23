using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TesteBarDg.Domain.Commands;
using TesteBarDg.Infra.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBarDg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComandaController : Controller
    {
        private readonly BarDgContext _barDgContext;
        private readonly IMediator _mediator;

        public ComandaController(BarDgContext barDgContext, IMediator mediator)
        {
            _barDgContext = barDgContext;
            _mediator = mediator;
        }

        [HttpGet("{IdComanda}")]
        public async Task<IActionResult> GerarExtrato([FromRoute] GerarExtratoCommand comanda)
        {
            var retorno = await _mediator.Send(comanda);

            return Json(retorno);
        }

        [HttpPost("comprar")]
        public async Task<IActionResult> RegistrarCompra([FromBody] ItemCompradoCommand compra)
        {
            var retorno = await _mediator.Send(compra);

            return Json(retorno);
        }

        [HttpDelete("limpar/{IdComanda}")]
        public async Task<IActionResult> LimparComanda([FromRoute] ResetarComandaCommand comanda)
        {
            var retorno = await _mediator.Send(comanda);

            return Json(retorno);
        }
    }
}
