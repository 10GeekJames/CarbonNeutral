namespace LiveRoomApplication.Data;
public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var services = scope.ServiceProvider;
            var configuration = GetConfiguration(args);
            //var appSettings = configuration.Get<AppSettings>();    
             
            try
            {                    
                var context = services.GetRequiredService<LiveRoomDbContext>();
                context.Database.EnsureCreated();

                await context.Database.MigrateAsync();
                await context.Database.EnsureCreatedAsync();
                logger.LogInformation("Seeding database...");
                var runBaseSeedData = new RunBaseSeedData();
                await runBaseSeedData.Initialize(services);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
            logger.LogError("Run Complete");
        }
        
        return;
        //host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                });
    });

    private static IConfiguration GetConfiguration(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

        if (isDevelopment)
        {
            configurationBuilder.AddUserSecrets<Startup>(true);
        }

        var configuration = configurationBuilder.Build();

        //configuration.AddAzureKeyVaultConfiguration(configurationBuilder);

        configurationBuilder.AddCommandLine(args);
        configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder.Build();
    }
}
