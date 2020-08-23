using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.Models
{
    public class ItemCompradoResult
    {
        public ItemCompradoResult()
        {
        }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }
        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }
    }
}
