using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vns_trips_backend.Aplications;
using vns_trips_backend.Aplications.Contratos;
using vns_trips_backend.Data;
using vns_trips_backend.Persistence;
using vns_trips_backend.Persistence.Contratos;

namespace vns_trips_backend
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
            services.AddDbContext<DataContext>(
                    //CONECTAMOS NO BANCO DE DADOS SEJA ELE QUAL FOR la no appsetings json
                   context => context.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllers();

            //ADD O SCOPO DO SERVICE
            services.AddScoped<IMarketService, MarketService>();
            services.AddScoped<IMarketItemService, MarketItemService>();

            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<IMarketPersistence, MarketPersistence>();
            services.AddScoped<IMarketItemPersistence, MarketItemPersistence>();

            services.AddSwaggerGen(c =>
            {
                //troca a versao nome swagger
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vns_trips_backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vns_trips_backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
