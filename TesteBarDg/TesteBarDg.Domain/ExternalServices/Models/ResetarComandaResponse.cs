using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class ResetarComandaResponse
    {
        public ResetarComandaResponse()
        {
        }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }
    }
}
