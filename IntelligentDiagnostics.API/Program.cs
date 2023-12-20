using IntelligentDiagnostics.DAL;
using IntelligentDiagnostics.DAL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;

namespace IntelligentDiagnostics.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(option => option
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));
            builder.Services.AddControllers();

            builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
            builder.Services.AddSingleton<IMqttService, MqttService>();
            builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var mqttService = app.Services.GetRequiredService<IMqttService>();
            mqttService.ConnectAsync().GetAwaiter().GetResult();

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