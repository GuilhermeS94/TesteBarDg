using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.Models
{
    public class ResetarComandaResult
    {
        public ResetarComandaResult()
        {
        }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }
    }
}
