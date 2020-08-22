using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TesteBarDg.Domain.Commands;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBarDg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComandaController : Controller
    {
        private readonly ILogger<ComandaController> _logger;
        private readonly IMediator _mediator;

        public ComandaController(ILogger<ComandaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public IActionResult GetItensComprados(int id)
        {
            /*var lista = _barDgContext.NotaFiscal
            .FromSqlRaw("select i.id, i.nome, count(i.id) as quantidade, sum(i.valor) as total from itens i inner join compras c on i.id = c.idItem where c.idComanda = 1 group by i.id;", id)
            .ToList();
            return Json(lista);*/

            return Json("OK");
        }

        [HttpPost("comprar")]
        public async Task<IActionResult> RegistrarCompra([FromBody] ItemCompradoCommand compra)
        {
            /*_barDgContext.Compras.Add(compra);
            _barDgContext.SaveChanges();
            return Json(new { compra_efetuada = true }); */

            var retorno = await _mediator.Send(compra);

            return Json(retorno);
        }

        [HttpDelete("limpar/{id}")]
        public IActionResult LimparComanda(int id)
        {
            /*var lista = _barDgContext.Compras.Where(x => x.IdComanda == id).ToList();
            _barDgContext.Compras.RemoveRange(lista);
            _barDgContext.SaveChanges();
            return Json(new { comanda_resetada = true }); */

            return Json("OK");
        }
    }
}
