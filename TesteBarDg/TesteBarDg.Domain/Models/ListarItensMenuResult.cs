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


    public class Item
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}