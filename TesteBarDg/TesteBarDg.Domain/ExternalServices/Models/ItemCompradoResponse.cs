using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class ItemCompradoResponse
    {
        public ItemCompradoResponse()
        {
        }

        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        [JsonProperty("sucesso")]
        public bool Sucesso { get; set; }
    }
}
