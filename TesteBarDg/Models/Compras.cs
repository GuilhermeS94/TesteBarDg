﻿using System;
using System.Collections.Generic;

namespace TesteBarDg.Models
{
    public partial class Compras
    {
        public long Id { get; set; }
        public long IdComanda { get; set; }
        public long IdItem { get; set; }

        public virtual Comandas IdComandaNavigation { get; set; }
        public virtual Itens IdItemNavigation { get; set; }
    }
}
