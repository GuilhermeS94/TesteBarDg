using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace TesteBarDg.Test
{
    public class ComandaControllerTest
    {
        //private readonly TestServer _server;
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

            //_server = new TestServer(hb);
            //_client = _server.CreateClient();
        }
    }
}
