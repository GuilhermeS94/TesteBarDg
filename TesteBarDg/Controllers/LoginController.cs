using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteBarDg.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteBarDg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly BarDgContext _barDgContext;

        public LoginController(ILogger<LoginController> logger, BarDgContext barDgContext)
        {
            _logger = logger;
            _barDgContext = barDgContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Json(new { bem_vindo = "Olá Funcionário do Bar do DG!" });
        }

        [HttpGet("lista-itens")]
        public IEnumerable<Itens> ListaItens()
        {
            return _barDgContext.Itens.ToList();
        }
    }
}
