namespace YmiApplication.Data;
public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<YmiDbContext>();
                context.Database.EnsureCreated();

                logger.LogInformation("Seeding database...");
                var runBaseSeedData = new RunBaseSeedData();
                runBaseSeedData.Initialize(services).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }

        host.Run();
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
}
