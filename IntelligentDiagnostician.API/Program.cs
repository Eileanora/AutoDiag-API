using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.Manager.UsersManager;
using IntelligentDiagnostician.DAL.Repositories.UserRepository;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.SensorRepository;
using IntelligentDiagnostician.DAL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MQTTnet;
using MQTTnet.Client;

namespace IntelligentDiagnostician.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>(option => option
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));
        builder.Services.AddControllers();


        #region MQTT Configuration

        builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        builder.Services.AddSingleton<IMqttService, MqttService>();
        builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

        #endregion


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        #region Services
        builder.Services.AddScoped<IUsersManager, UsersManager>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISensorsManager, SensorsManager>();
        builder.Services.AddScoped<ISensorRepository, SensorRepository>();
        #endregion
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