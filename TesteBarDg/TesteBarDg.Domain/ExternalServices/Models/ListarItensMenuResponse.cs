using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class ListarItensMenuResponse
    {
        public ListarItensMenuResponse()
        {
        }

        [JsonPropertyName("itens_menu")]
        public ICollection<Item> ItensMenu { get; set; }
    }

    [Serializable]
    public class Item
    {
        [JsonPropertyName("id_item")]
        public long Id { get; set; }
        [JsonPropertyName("nome_item")]
        public string Nome { get; set; }
        [JsonPropertyName("valor_item")]
        public double Valor { get; set; }
    }
}
