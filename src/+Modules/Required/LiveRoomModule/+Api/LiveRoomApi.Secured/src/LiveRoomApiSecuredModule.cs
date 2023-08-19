using System.Reflection;
using Module = Autofac.Module;

namespace LiveRoomApi.Secured;
public class LiveRoomApiSecuredModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public LiveRoomApiModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        var coreAssembly = Assembly.GetAssembly(typeof(LiveRoomCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(LiveRoomInfrastructureModule));
        var applicationAssembly = Assembly.GetAssembly(typeof(LiveRoomApplicationModule));
        //var primaryApiAssembly = Assembly.GetAssembly(typeof(LiveRoomApiModule));

        _assemblies.Add(coreAssembly!);
        _assemblies.Add(infrastructureAssembly!);
        _assemblies.Add(applicationAssembly!);
        //_assemblies.Add(primaryApiAssembly);

        if (callingAssembly != null)
        {
            _assemblies.Add(callingAssembly);
        }
    }

    protected override void Load(ContainerBuilder builder)
    {
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }
        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        var services = new ServiceCollection();
        services.AddAutoMapper(typeof(BookMapper).GetTypeInfo().Assembly);
        builder.Populate(services);

        // register misc
        /*
        builder.RegisterType<EmailSender>().As<IEmailSender>()
            .InstancePerLifetimeScope();
        */
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // TODO: Add development only services
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // TODO: Add production only services
    }

}
