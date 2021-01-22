using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ConcessionariaAPI.ConcessionariaInfra.Context;
using ConcessionariaInfra.Repositorios;
using ConcessionariaDominio.Repositorio.Interfaces;
using ConcessionariaDominio.Servicos.Interface;
using ConcessionariaServicos;

namespace ConcessionariaAPI.Concessionaria.API
{
#pragma warning disable 1591
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

            services.AddDbContext<DataContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddControllers();

            AddSwagger(services);
            
            //Fazendo injeção de dependência.
            services.AddTransient<IConcessionariaRepositrio, ConcessionariaRepository>();
            services.AddTransient<IConcessionariaServicos, ConcessionariaServico>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Adicionando o uso do swagger.
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CONCESSIONARIAAPI", Version = "V1" });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

    }
}
