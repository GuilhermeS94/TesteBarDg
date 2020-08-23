using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.Models
{
    public class GerarExtratoResult
    {
        public GerarExtratoResult()
        {
        }

        [JsonProperty("itens_comprados")]
        public ICollection<ItemComprado> ItensComprados { get; set; }
        [JsonProperty("valor_total")]
        public double ValorTotal { get; set; }
    }

    [Serializable]
    public class ItemComprado
    {
        [JsonProperty("id_item")]
        public long Id { get; set; }
        [JsonProperty("nome_item")]
        public string Nome { get; set; }
        [JsonProperty("valor_item")]
        public double Valor { get; set; }
    }
}
