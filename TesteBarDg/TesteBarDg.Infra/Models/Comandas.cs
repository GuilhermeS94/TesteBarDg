using System;
using System.Collections.Generic;

namespace TesteBarDg.Infra.Models
{
    public partial class Comandas
    {
        public Comandas()
        {
            Compras = new HashSet<Compras>();
        }

        public long Id { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
    }
}
