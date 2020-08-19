using System;
namespace TesteBarDg.Models
{
    public class NotaFiscal
    {
        public NotaFiscal()
        {
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Total { get; set; }
    }
}
