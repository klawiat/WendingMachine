using Microsoft.EntityFrameworkCore;
using WendingMachine.Infrastructure;
using WendingMachine.Api.Middlewares;

namespace WendingMachine.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WendingDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.InitializeRepositories();
            builder.Services.InitializeServices();
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseCustomExceptionHandler();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(@"v1/swagger.json", "Wending"));
            app.UseCors(build => build.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod());
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Wending}/{action=Index}/{id?}"
                    );
            });

            app.Run();
        }
    }
}