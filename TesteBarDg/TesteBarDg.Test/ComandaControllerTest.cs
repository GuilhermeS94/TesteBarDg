using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TesteBarDg;
using TesteBarDg.Domain.Commands;
using TesteBarDg.Domain.Models;
using Xunit;

namespace TesteBarDg.Test
{
    public class ComandaControllerTest
    {
        private readonly HttpClient _client;

        public ComandaControllerTest()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            IWebHostBuilder hb = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .UseConfiguration(config);

            TestServer _server = new TestServer(hb);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task DeveRetornarListaDeItensDoMenu()
        {
            //ARRANGE
            var response = await _client.GetAsync("menu/lista-itens");

            //ACT
            var result = JsonConvert.DeserializeObject<ListarItensMenuResult>(await response.Content.ReadAsStringAsync());

            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.ItensMenu.Count > 0);
        }

        [Theory]
        [InlineData(2)]
        public async Task DeveLimparUmaComanda(int idComanda)
        {
            //ARRANGE
            var response = await _client.GetAsync($"comanda/limpar/{idComanda}");

            //ACT
            var result = JsonConvert.DeserializeObject<ResetarComandaResult>(await response.Content.ReadAsStringAsync());


            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Sucesso);
        }

        [Fact]
        public async Task DeveRealizarUmCompra()
        {
            //ARRANGE
            var entrada = new ItemCompradoCommand
            {
                IdComanda = 1,
                IdItem = 1
            };


            //ACT
            var response = await _client.PostAsync("comanda/comprar", new StringContent(JsonConvert.SerializeObject(entrada), Encoding.Default, "application/json"));
            var result = JsonConvert.DeserializeObject<ItemCompradoResult>(await response.Content.ReadAsStringAsync());


            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Sucesso);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeveTrazerExtratoDaComanda(int idComanda)
        {
            //ARRANGE
            var response = await _client.GetAsync($"comanda/{idComanda}");

            //ACT
            var result = JsonConvert.DeserializeObject<GerarExtratoResult>(await response.Content.ReadAsStringAsync());

            //ASSERT
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.ItensComprados != null);
        }
    }
}
