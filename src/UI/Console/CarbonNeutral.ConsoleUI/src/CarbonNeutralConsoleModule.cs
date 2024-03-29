using System.Reflection;
using Module = Autofac.Module;

namespace CarbonNeutral.ConsoleUI;
public class CarbonNeutralConsoleModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public CarbonNeutralConsoleModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        var coreAssembly = Assembly.GetAssembly(typeof(WskCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(WskInfrastructureModule));
        var applicationAssembly = Assembly.GetAssembly(typeof(WskApplicationModule));
        var consoleAssembly = Assembly.GetAssembly(typeof(CarbonNeutralConsoleModule));

        _assemblies.Add(coreAssembly!);
        _assemblies.Add(infrastructureAssembly!);
        _assemblies.Add(applicationAssembly!);
        _assemblies.Add(consoleAssembly);

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
