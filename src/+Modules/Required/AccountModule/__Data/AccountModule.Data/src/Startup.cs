using System.Reflection;
using Autofac;
using MediatR.Pipeline;
using AccountModuleCore;

namespace AccountModule.Data;
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
        string connectionString =
            Configuration.GetConnectionString("Active") ?? ""; //Configuration.GetConnectionString("DefaultConnection");

        services.AddAccountModuleDbContext(connectionString);

        foreach (var seedData in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(IAccountModuleSeedScript)) && x.IsClass)
                    .OrderBy(rs => rs.Name))
        {
            services.AddSingleton(seedData);
        }
    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder
            .RegisterModule(new AccountModuleDataModule(_env
                    .EnvironmentName ==
                "Development"));
        var assemblies = new List<Assembly>();

        var coreAssembly = Assembly.GetAssembly(typeof(AccountModuleCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(AccountModuleInfrastructureModule));
        //var applicationAssembly = Assembly.GetAssembly(typeof(AccountModuleApplicationModule));
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
