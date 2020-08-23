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

        public List<ItemComprado> ItensComprados { get; set; }
        public double ValorTotal { get; set; }
    }

    public class ItemComprado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public long ItemPromocional { get; set; }
    }
}
