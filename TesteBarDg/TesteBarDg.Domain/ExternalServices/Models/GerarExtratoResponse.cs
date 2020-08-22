using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class GerarExtratoResponse
    {
        public GerarExtratoResponse()
        {
        }

        [JsonProperty("itens_comprados")]
        public ICollection<ItemComprado> ItensComprados { get; set; }

        [JsonProperty("valor_total")]
        public double ValorTotal { get; set; }
    }

    public class ItemComprado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
