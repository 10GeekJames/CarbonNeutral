namespace CarbonNeutral.ConsoleUI;
using System.Reflection;
public class Startup
{
    public AutofacServiceProvider ServiceProvider { get; set; }
    public Startup()
    {
        IServiceCollection services = new ServiceCollection();
        string environment = "development";
        IConfigurationRoot configuration =
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",
                optional: false,
                reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        
        bool useSqlite = configuration.GetValue<bool>(nameof(useSqlite));
       

        // WordSearchKingdom
        string wskConnectionString =
            configuration.GetConnectionString("ActiveWsk") ?? "";

        var appSettings = configuration.Get<AppSettings>();

        services
            .AddSingleton<AppSettings>(appSettings!);

        services
            .AddWskDbContext(wskConnectionString);

        services.AddSingleton<IWskDataService, WskDirectDataService>();
        // \WordSearchKingdom

        services.AddLogging().BuildServiceProvider();

        services.AddSingleton<App>();

        
        var containerBuilder = new ContainerBuilder();
        containerBuilder.Populate(services);

        //containerBuilder.RegisterModule(new SpyderFootScansCoreModule());
        //containerBuilder.RegisterModule(new SpyderFootScansInfrastructureModule(true));

        //containerBuilder.RegisterModule(new ScanModulesCoreModule());
        //containerBuilder.RegisterModule(new ScanModulesInfrastructureModule(true));


        var container = containerBuilder;
        var isInDevelopment = true; //_env.EnvironmentName == "Development";
        container.RegisterModule(new WskCoreModule());
        container.RegisterModule(new WskInfrastructureModule(isInDevelopment));
        container.RegisterModule(new WskApplicationModule(isInDevelopment));
        container.RegisterModule(new CarbonNeutralConsoleModule(isInDevelopment, typeof(App).GetTypeInfo().Assembly));
        var builtContainer = container.Build();
        ServiceProvider = new AutofacServiceProvider(builtContainer);
    }

    /* public void ConfigureContainer(ContainerBuilder builder)
    {
        var isInDevelopment = true; //_env.EnvironmentName == "Development";
        builder.RegisterModule(new WskCoreModule());
        builder.RegisterModule(new WskInfrastructureModule(isInDevelopment));
        builder.RegisterModule(new WskApplicationModule(isInDevelopment));
        builder.RegisterModule(new CarbonNeutralConsoleModule(isInDevelopment, typeof(App).GetTypeInfo().Assembly));
    } */
}
