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

        public ICollection<Item> ItensMenu { get; set; }
    }

    public class Item
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
