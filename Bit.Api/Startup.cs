using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Bit.Api.Domain.Entities;
using Bit.Api.Services;
using Bit.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using Bit.Api.Database;
using FluentValidation;
using FluentValidation.AspNetCore;
using Bit.Api.Middleware;

namespace Bit
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

            services.AddDbContext<BitContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MicrosoftSQLServerConnection")));

            services.AddControllers();

            services.AddScoped<IRepository<Player>, PlayerRepository>();
            services.AddScoped<IRepository<Team>, TeamRepository>();

            services.AddMvc(options => { options.EnableEndpointRouting = false; })
                .AddFluentValidation();

            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
