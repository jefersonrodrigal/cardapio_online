using LanchoneteAPI.Configurations;
using LanchoneteAPI.DataContext;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<ApiDataContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite")));

            builder.Services.AddCors(x => x.AddPolicy(ConfigurationCors.CorsPolicyName, policy => policy
                              .WithOrigins([ConfigurationCors.FrontEndUrl])
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                              .AllowCredentials()
                          ));

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors(ConfigurationCors.CorsPolicyName);
            app.UseRouting();
            app.MapControllers();


            app.Run();
        }
    }
}
