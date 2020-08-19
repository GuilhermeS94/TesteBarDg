using System;
using System.Collections.Generic;

namespace TesteBarDg.Models
{
    public partial class Itens
    {
        public Itens()
        {
            Compras = new HashSet<Compras>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
    }
}
