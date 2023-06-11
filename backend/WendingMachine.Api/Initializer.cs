using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WendingMachine.Application.Services;
using WendingMachine.Application.Services.Interfaces;
using WendingMachine.Infrastructure;
using WendingMachine.Infrastructure.Interfaces;
using WendingMachine.Infrastructure.Repositories;

namespace WendingMachine.Api
{
    public static class Initializer
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.AttachDBFilename = "";
            Assembly[] assemblies = { Assembly.Load("WendingMachine.Application"), typeof(Program).Assembly };
            services.AddDbContext<WendingDbContext>(opt => opt.UseSqlServer("Data Source=BKV-PC;Initial Catalog=WendingDB;TrustServerCertificate=True;Integrated Security=True;Pooling=False"));
            services.AddValidatorsFromAssemblies(assemblies);
            services.AddAutoMapper(assemblies);
            services.AddScoped<ICoinService, CoinService>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IMachineService, MachineService>();
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Wending", Version = "v1" });
            });
        }
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICoinRepository, CoinRepository>();
            services.AddScoped<IDrinkRepository, DrinkRepository>();
            services.AddScoped<IMachineRepository, MachineRepository>();
        }
    }
}
