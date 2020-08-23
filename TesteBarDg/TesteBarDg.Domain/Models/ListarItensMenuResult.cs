using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.Models
{
    public class ListarItensMenuResult
    {
        public ListarItensMenuResult()
        {
        }

        [JsonProperty("itens_menu")]
        public ICollection<Item> ItensMenu { get; set; }
    }

    [Serializable]
    public class Item
    {
        [JsonProperty("id_item")]
        public long Id { get; set; }
        [JsonProperty("nome_item")]
        public string Nome { get; set; }
        [JsonProperty("valor_item")]
        public double Valor { get; set; }
    }
}