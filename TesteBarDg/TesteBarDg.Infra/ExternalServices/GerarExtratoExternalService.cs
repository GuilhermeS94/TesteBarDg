﻿using System;
using System.Threading.Tasks;
using TesteBarDg.Domain.ExternalServices;
using TesteBarDg.Domain.ExternalServices.Models;

namespace TesteBarDg.Infra.ExternalServices
{
    public class GerarExtratoExternalService : IGerarExtratoExternalService
    {
        public GerarExtratoExternalService()
        {
        }

        public async Task<GerarExtratoResponse> GerarExtrato(long idComanda)
        {
            return new GerarExtratoResponse();
        }
    }
}
