using System;
using Newtonsoft.Json;

namespace TesteBarDg.Domain.ExternalServices.Models
{
    public class ItemCompradoResponse
    {
        public ItemCompradoResponse()
        {
        }

        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
    }
}
