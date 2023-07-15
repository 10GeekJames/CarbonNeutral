using System.Reflection;

namespace AccountModuleApplication.FeatureTests.Data;
public class BaseApplicationTestFixture
{
    private readonly List<Assembly> _assemblies = new List<Assembly>();
    private IContainer? _autofacContainer = null;
    protected IContainer AutofacContainer
    {
        get
        {
            if (_autofacContainer == null)
            {
                var builder = new ContainerBuilder();

                var coreAssembly = Assembly.GetAssembly(typeof(AccountModuleCoreModule));
                var infrastructureAssembly = Assembly.GetAssembly(typeof(AccountModuleInfrastructureModule));
                var applicationAssembly = Assembly.GetAssembly(typeof(AccountModuleApplicationModule));
                var applicationTestAssembly = Assembly.GetAssembly(typeof(BaseApplicationTestFixture));

                _assemblies.Add(coreAssembly!);
                _assemblies.Add(infrastructureAssembly!);
                _assemblies.Add(applicationAssembly!);
                _assemblies.Add(applicationTestAssembly!);

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
                    .RegisterAssemblyTypes(_assemblies.ToArray())
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
                }

                var services = new ServiceCollection();

                services.AddAutoMapper(typeof(KnownAccountMap).GetTypeInfo().Assembly);
                services.AddSingleton<IAccountModuleDataService, AccountModuleDirectDataService>();
                services.AddEntityFrameworkInMemoryDatabase();
                services.AddDbContext<AccountModuleDbContext>(context => context.UseInMemoryDatabase("AccountModuleApplication.FeatureTests")
                    .UseApplicationServiceProvider(services.BuildServiceProvider()));

                builder.Populate(services);

                var container = builder.Build();
                _autofacContainer = container;
            }

            return _autofacContainer;
        }
    }
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;
    protected readonly IAccountModuleDataService _dataService;
    
    public BaseApplicationTestFixture()
    {
        _autofacContainer = AutofacContainer;
        _mediator = _autofacContainer.Resolve<IMediator>();
        _mapper = _autofacContainer.Resolve<IMapper>();
        _dataService = _autofacContainer.Resolve<IAccountModuleDataService>();
    }
}
