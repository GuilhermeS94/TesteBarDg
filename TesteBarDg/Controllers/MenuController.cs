using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteBarDg.Domain.Commands;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBarDg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IMediator _mediator;

        public MenuController(ILogger<MenuController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("lista-itens")]
        public async Task<IActionResult> ListarItensDoMenu()
        {
            var retorno = await _mediator.Send(new ListarItensMenuCommand());

            return Json(retorno);
        }
    }
}
