using System.Reflection;

namespace KnownAccountsApi.Secured.FunctionalTests;
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
{
    private ILogger<CustomWebApplicationFactory<TStartup>>? _logger;
    private IConfiguration? _configuration;

    private readonly List<Assembly> _assemblies = new List<Assembly>();
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = builder.Build();
        var serviceProvider = host.Services;

        using (var scope = serviceProvider.CreateScope())
        {
            _logger = serviceProvider.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

            var db = serviceProvider.GetRequiredService<KnownAccountsDbContext>();

            db.Database.EnsureCreated();
            _logger.LogInformation("Database is created");

            try
            {
                var runBaseSeedData = new RunBaseSeedData();
                runBaseSeedData.Initialize(serviceProvider).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred seeding the " +
                                    $"database with test messages. Error: {ex.Message}");
            }
        }

        host.Start();
        return host;
    }

    protected override IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHost((builder) =>
            {
                builder.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.SetMinimumLevel(LogLevel.Information);
            });
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        _configuration = GetConfiguration(new string[] { });

        var containerBuilder = new ContainerBuilder();

        var applicationAssembly = Assembly.GetAssembly(typeof(KnownAccountsApplicationModule));
        var primaryApiAssembly = Assembly.GetAssembly(typeof(KnownAccountsApiModule));

        _assemblies.Add(applicationAssembly!);
        _assemblies.Add(primaryApiAssembly!);

        containerBuilder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .As(typeof(IReadRepository<>))
            .InstancePerLifetimeScope();

        containerBuilder
            .RegisterType<Mediator>()
            .As<IMediator>()
            .InstancePerLifetimeScope();

        var mediatrOpenTypes = new[]
        {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            containerBuilder
                .RegisterAssemblyTypes(_assemblies.ToArray())
                .AsClosedTypesOf(mediatrOpenType)
                .AsImplementedInterfaces();
        }

        var services = new ServiceCollection();
        services.AddAutoMapper(typeof(BookMapper).GetTypeInfo().Assembly);
        containerBuilder.Populate(services);


        builder
            .ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<KnownAccountsDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(KnownAccountsDbContext));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                var appSettings = _configuration.Get<AppSettings>();
                services.AddSingleton<AppSettings>(appSettings!);
                services.AddEntityFrameworkInMemoryDatabase();

                services.AddKnownAccountsInMemoryDbContext("primary.db");

                var seedDataAssembly = Assembly.GetAssembly(typeof(RunBaseSeedData));
                foreach (var seedData in seedDataAssembly!
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(IKnownAccountsSeedScript)) && x.IsClass)
                    .OrderBy(rs => rs.Name))
                {
                    services.AddSingleton(seedData);
                }

                services.AddControllers()
                    .AddApplicationPart(typeof(Startup).Assembly);

            });
    }

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
