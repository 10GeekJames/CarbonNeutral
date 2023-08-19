
using System.Reflection;

namespace LiveRoomApplication.Data;
public class Startup
{
    private readonly IWebHostEnvironment _env;
    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
        Configuration = config;
        _env = env;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        string dbConnectionStrategy = Configuration.GetValue<string>("LiveRoomDbUse") ?? "";
        string connectionString = Configuration.GetConnectionString(dbConnectionStrategy) ?? "";

        if (dbConnectionStrategy.Contains("Sqlite", StringComparison.OrdinalIgnoreCase))
        {
            services.AddLiveRoomSqliteDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Memory", StringComparison.OrdinalIgnoreCase))
        {
            services.AddLiveRoomInMemoryDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Sql", StringComparison.OrdinalIgnoreCase))
        {
            services.AddLiveRoomSqlDbContext(connectionString);
        }        

        foreach (var seedData in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(ILiveRoomSeedScript)) && x.IsClass)
                    .OrderBy(rs => rs.Name))
        {
            services.AddSingleton(seedData);
        }
    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder
            .RegisterModule(new LiveRoomApplicationDataModule(_env
                    .EnvironmentName ==
                "Development"));
        var assemblies = new List<Assembly>();

        var coreAssembly = Assembly.GetAssembly(typeof(LiveRoomCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(LiveRoomInfrastructureModule));
        //var applicationAssembly = Assembly.GetAssembly(typeof(LiveRoomApplicationModule));
        //var applicationTestAssembly = Assembly.GetAssembly(typeof(BaseApplicationTestFixture));

        assemblies.Add(coreAssembly!);
        assemblies.Add(infrastructureAssembly!);
        
        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .As(typeof(IReadRepository<>))
            .InstancePerLifetimeScope();

        builder
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
            builder
            .RegisterAssemblyTypes(assemblies.ToArray())
            .AsClosedTypesOf(mediatrOpenType)
            .AsImplementedInterfaces();
        }

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.EnvironmentName == "Development")
        {

        }
        else
        {
        }
    }
}
