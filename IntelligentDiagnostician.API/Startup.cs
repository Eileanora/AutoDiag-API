using System.Text.Json.Serialization;
using IntelligentDiagnostician.API.Helpers;
using IntelligentDiagnostician.BL;
using IntelligentDiagnostician.DAL;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.API;

public static class Startup
{
    // public IConfiguration Configuration { get; }
    //
    // public Startup(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }
    //
    // public void ConfigureServices(IServiceCollection services)
    // {
    //     services.AddControllers(options =>
    //         { 
    //             options.InputFormatters.Insert(0, JsonPatchInputFormatter.GetJsonPatchInputFormatter());
    //         })
    //         .AddJsonOptions(options =>
    //         {
    //             options.JsonSerializerOptions
    //                 .DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    //         });
    //     services.AddDalServices(Configuration);
    //     services.AddBlServices();
    // }
    //
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetService<DbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        } 
    }
}