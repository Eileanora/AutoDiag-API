
using IntelligentDiagnostics.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IntelligentDiagnostics.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json") 
             .Build();
            //add connectionString 
            builder.Services.AddDbContext<AppDbContext>(builder => builder.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
