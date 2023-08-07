namespace AccountModuleApi;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AccountModuleDbContext>();

            // feel free to do cool stuff
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddUserSecrets<Startup>(true);
                if (args != null)
                {
                    config.AddCommandLine(args);
                }                
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder
                    .UseStartup<Startup>()                    
                    .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    // logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure
                });
            });
}