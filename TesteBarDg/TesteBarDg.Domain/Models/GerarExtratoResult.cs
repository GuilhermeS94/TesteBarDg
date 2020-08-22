using System;
using System.Collections.Generic;

namespace TesteBarDg.Domain.Models
{
    public class GerarExtratoResult
    {
        public GerarExtratoResult()
        {
        }

        public ICollection<ItemComprado> ItensComprados { get; set; }
        public double ValorTotal { get; set; }
    }


    public class ItemComprado
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}
