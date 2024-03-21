using System.Text.Json.Serialization;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.BL.Manager.UsersManager;
using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.BL.DTOs.SensorDTOs;
using IntelligentDiagnostician.BL.Utils.Mapper.Converter;
using IntelligentDiagnostician.BL.Utils.Mapper.ConverterFactory;
using IntelligentDiagnostician.DAL.Repositories.UserRepository;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.SensorRepository;
using IntelligentDiagnostician.DAL.Repositories.SystemRepository;
using IntelligentDiagnostician.DAL.Services;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

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
        builder.Services.AddControllers(options =>
            { 
                options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions
                    .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        #region MQTT Configuration

        builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        builder.Services.AddSingleton<IMqttService, MqttService>();
        builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

        #endregion

    
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // #region AutoMapper
        // builder.Services.AddScoped<IConverterFactory, ConverterFactory>();
        // builder.Services.AddSingleton<IConverter<Sensor, SensorDto>, SensorConvertor>();
        // #endregion
        
        #region Services
        builder.Services.AddScoped<IUsersManager, UsersManager>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ISensorsManager, SensorsManager>();
        builder.Services.AddScoped<ISensorRepository, SensorRepository>();
        builder.Services.AddScoped<ICarSystemManager, CarSystemManager>();
        builder.Services.AddScoped<ICarSystemRepository, CarSystemRepository>();
        #endregion



        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        var app = builder.Build();
        

        // var mqttService = app.Services.GetRequiredService<IMqttService>();
        // mqttService.ConnectAsync().GetAwaiter().GetResult();

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