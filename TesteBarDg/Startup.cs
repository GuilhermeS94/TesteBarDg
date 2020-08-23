using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TesteBarDg.Domain.Commands;
using FluentValidation.AspNetCore;
using System.Reflection;
using MediatR;
using Microsoft.OpenApi.Models;
using TesteBarDg.Infra.Models;

namespace TesteBarDg
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BarDgContext>(options =>
                 options.UseSqlite(Configuration.GetConnectionString("BarDgDb")));

            services.AddControllers();
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Bardo do DG",
                        Version = "v1",
                        Description = "Teste ClearSale - Bar do DG",
                        Contact = new OpenApiContact
                        {
                            Name = "Guilherme Silva",
                            Url = new Uri("https://github.com/GuilhermeS94/TesteBarDg")
                        }
                    });
            });

            var assemblyLimc = typeof(ListarItensMenuCommand).Assembly;
            var assemblyGec = typeof(GerarExtratoCommand).Assembly;
            var assemblyIcc = typeof(ItemCompradoCommand).Assembly;
            var assemblyRcc = typeof(ResetarComandaCommand).Assembly;
            var lista = new List<Assembly>();
            lista.Add(assemblyLimc);
            lista.Add(assemblyGec);
            lista.Add(assemblyIcc);
            lista.Add(assemblyRcc);

            services
                .AddMvcCore()
                .AddApiExplorer()
                .AddFluentValidation(setup => setup.RegisterValidatorsFromAssemblies(lista))
                .AddNewtonsoftJson();

            services
                .AddMediatR(new Assembly[] {assemblyLimc, assemblyGec, assemblyIcc, assemblyRcc })
                .AddServices(Configuration, Env)
                .AddHealthChecks();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bar do DG");
            });

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
