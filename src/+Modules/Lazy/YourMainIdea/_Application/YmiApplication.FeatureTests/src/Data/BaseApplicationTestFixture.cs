using System.Reflection;

namespace YmiApplication.FeatureTests.Data;
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

                var coreAssembly = Assembly.GetAssembly(typeof(YmiCoreModule));
                var infrastructureAssembly = Assembly.GetAssembly(typeof(YmiInfrastructureModule));
                var applicationAssembly = Assembly.GetAssembly(typeof(YmiApplicationModule));
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

                services.AddAutoMapper(typeof(BookMapper).GetTypeInfo().Assembly);
                services.AddSingleton<IYmiDataService, YmiDirectDataService>();
                services.AddEntityFrameworkInMemoryDatabase();
                services.AddDbContext<YmiDbContext>(context => context.UseInMemoryDatabase("YmiApplication.FeatureTests")
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
    protected readonly IYmiDataService _dataService;
    
    public BaseApplicationTestFixture()
    {
        _autofacContainer = AutofacContainer;
        _mediator = _autofacContainer.Resolve<IMediator>();
        _mapper = _autofacContainer.Resolve<IMapper>();
        _dataService = _autofacContainer.Resolve<IYmiDataService>();
    }
}
