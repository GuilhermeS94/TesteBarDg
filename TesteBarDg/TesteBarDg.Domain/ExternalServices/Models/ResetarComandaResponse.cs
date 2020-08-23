using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class ResetarComandaResponse
    {
        public ResetarComandaResponse()
        {
        }

        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
    }
}
