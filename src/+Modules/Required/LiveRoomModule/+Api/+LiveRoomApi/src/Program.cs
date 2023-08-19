namespace LiveRoomApi;
public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var logger = host.Services.GetRequiredService<ILogger<Program>>();
            var services = scope.ServiceProvider;
            //var configuration = GetConfiguration(args);

            // Feel free to do cool stuff here
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environment == Environments.Development;

        return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddUserSecrets<Startup>(true);

                    if (isDevelopment)
                    {

                    }
                    else
                    {

                        //config.AddUserSecrets<Startup>(true);
                        /*config.AddSecretsManager(region: RegionEndpoint.USEast1,
                        configurator: options =>
                        {
                            options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}_");
                            options.KeyGenerator = (entry, s) => s
                                .Replace($"{env}_Database__", string.Empty)
                                .Replace("__", ":")
                            ;

                        }); */
                    }

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
}