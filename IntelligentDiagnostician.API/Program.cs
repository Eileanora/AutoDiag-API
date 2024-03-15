using System.Text.Json.Serialization;
using IntelligentDiagnostician.BL.Manager.CarSystemManager;
using IntelligentDiagnostician.BL.Manager.SensorsManager;
using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DAL.Repositories.SensorRepository;
using IntelligentDiagnostician.DAL.Repositories.SystemRepository;
using Microsoft.EntityFrameworkCore;

using MQTTnet;
using MQTTnet.Client;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Identity;
using IntelligentDiagnostician.DAL.Services.MqttServices;
using IntelligentDiagnostician.BL.AuthServices;

namespace IntelligentDiagnostician.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>(option => option
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));

        #region  JsonPatch 
        builder.Services.AddControllers(options =>
            { 
                options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions
                    .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        #endregion

        #region Jwt Options  And Identity
        
        builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        var JwtOptions =    builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

        builder.Services.AddSingleton(JwtOptions);

        builder.Services.AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, Options =>
            {
                Options.SaveToken = true;

                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,  
                    ValidIssuer = JwtOptions.Issuer , 
                    ValidateAudience = true,    
                    ValidAudience = JwtOptions.Audience ,   
                    ValidateLifetime = true , 
                    ValidateIssuerSigningKey = true ,   
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtOptions.SigningKey))
                };
            }); 
        #endregion


        #region MQTT Configuration

        builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        builder.Services.AddSingleton<IMqttService, MqttService>();
        builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

        #endregion

    
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        #region Services
        builder.Services.AddScoped<ISensorsManager, SensorsManager>();
        builder.Services.AddScoped<ISensorRepository, SensorRepository>();
        builder.Services.AddScoped<ICarSystemManager, CarSystemManager>();
        builder.Services.AddScoped<ICarSystemRepository, CarSystemRepository>();
        builder.Services.AddScoped<IAuthService , AuthService>();       
        #endregion
        var app = builder.Build();
        
        
        // var mqttService = app.Services.GetRequiredService<IMqttService>();
        // mqttService.ConnectAsync().GetAwaiter().GetResult();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

      //  app.UseAuthentication();    
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}