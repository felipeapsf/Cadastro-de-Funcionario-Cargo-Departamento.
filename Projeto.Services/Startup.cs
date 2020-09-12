using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Projeto.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //injeção de dependência para o repositorio
            services.AddDbContext<DataContext>(
                options => options.UseSqlServer
                (Configuration.GetConnectionString("exercicio04"))
                );

            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();

            //configurando injeção de dependência para o AutoMapper
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "API de controle de Funcionários",
                            Version = "v1",
                            Description = "Sistema criado em .NET CORE com EntityFramework"
                        });
                }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(
                swagger =>
                {
                    swagger.SwaggerEndpoint
                    ("/swagger/v1/swagger.json", "Projeto");
                }
                );

            app.UseMvc();
        }
    }
}
