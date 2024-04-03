using System.Text.Json.Serialization;
using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.API.Helpers.Facades.CarSystemControllerFacade;
using IntelligentDiagnostician.API.Helpers.Facades.SensorControllerFacade;
using IntelligentDiagnostician.BL;
using IntelligentDiagnostician.DAL;

namespace IntelligentDiagnostician.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // builder.Services.AddDbContext<AppDbContext>(option => option
        //     .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));
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

        // builder.Services.AddSingleton<IMqttClient>(sp => new MqttFactory().CreateMqttClient());
        // builder.Services.AddSingleton<IMqttService, MqttService>();
        // builder.Services.AddSingleton<IMessageProcessor, MessageProcessor>();

        #endregion

        // register services of the DAL and BL
        builder.Services.AddDalServices(builder.Configuration);
        builder.Services.AddBlServices();
        builder.Services.AddScoped<ICarSystemControllerFacade, CarSystemControllerControllerFacade>();
        builder.Services.AddScoped<ISensorControllerFacade, SensorControllerFacade>();
        // builder.Services.AddValidatorsFromAssemblyContaining<Program>();

        // TODO: CLEAN THIS MESS
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // #region AutoMapper
        // builder.Services.AddScoped<IConverterFactory, ConverterFactory>();
        // builder.Services.AddSingleton<IConverter<Sensor, SensorDto>, SensorConvertor>();
        // #endregion
        

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