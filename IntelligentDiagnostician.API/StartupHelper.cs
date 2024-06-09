using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Asp.Versioning;
using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.BL;
using IntelligentDiagnostician.BL.Services.MqttServices;
using IntelligentDiagnostician.DAL;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace IntelligentDiagnostician.API;

internal static class StartupHelper
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        #region Formatters options
        builder.Services.AddControllers(options =>
        {
            options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
            // options.ReturnHttpNotAcceptable = true;
        })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions
                    .NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals |
                                     JsonNumberHandling.AllowReadingFromString;
            });
        #endregion

        #region Jwt Options And Identity

        builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

        builder.Services.AddSingleton(jwtOptions);

        builder.Services.AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, Options =>
            {
                Options.SaveToken = true;

                Options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,  
                    ValidIssuer = jwtOptions.Issuer , 
                    ValidateAudience = true,    
                    ValidAudience = jwtOptions.Audience ,   
                    ValidateLifetime = true , 
                    ValidateIssuerSigningKey = true ,   
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"]))
                };
                // var x = builder.Configuration["SigningKey"]; 
            });
        #endregion

        #region Register layers services
        builder.Services.AddDalServices(builder.Configuration);
        builder.Services.AddBlServices();
        builder.Services.AddApiServices();
        #endregion

        #region API Versioning
        builder.Services.AddApiVersioning(setupAction =>
        {
            setupAction.AssumeDefaultVersionWhenUnspecified = true; // this line assumes the default api version when the client doesn't specify the api version
            setupAction.DefaultApiVersion = new ApiVersion(1, 0); // this line sets the default api version
            setupAction.ReportApiVersions = true; // this line adds the api version to the response header
        }).AddMvc();
        #endregion

        #region Swagger
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        #endregion
        
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination")
                        .AllowAnyMethod();
                });
        });

        #region MQTT Configuration

        #region MQTT Configuration
        // builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        // builder.Services.AddSingleton<IMqttService, MqttService>();
        // builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();
        // var mqttService = app.Services.GetRequiredService<IMqttService>();
        // mqttService.ConnectAsync().GetAwaiter().GetResult();
        #endregion

        // builder.Services.AddSwaggerGen(c =>
        // {
        //     c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        //     $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        // });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        var mqttService = app.Services.GetRequiredService<IMqttService>();
        mqttService.ConnectAsync().GetAwaiter().GetResult();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAnyOrigin");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.UseExceptionHandler();

        return app;
    }
}
