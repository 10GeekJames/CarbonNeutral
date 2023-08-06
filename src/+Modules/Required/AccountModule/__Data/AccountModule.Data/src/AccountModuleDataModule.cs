using System.Reflection;
using Autofac;
using AccountModuleCore;
using Module = Autofac.Module;

namespace AccountModuleApplication;
public class AccountModuleDataModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public AccountModuleDataModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        var coreAssembly = Assembly.GetAssembly(typeof(AccountModuleCoreModule));
        var infrastructureAssembly = Assembly.GetAssembly(typeof(AccountModuleInfrastructureModule));

        _assemblies.Add(coreAssembly!);
        _assemblies.Add(infrastructureAssembly!);

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

        foreach (var seedData in Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass && x.Name.Contains("SeedWithData"))
            .OrderBy(rs => rs.Name))
        {
            services.AddSingleton(seedData);
        }

        builder.RegisterGeneric(typeof(EfRepository<>))
            .As(typeof(IRepository<>))
            .As(typeof(IReadRepository<>))
            .InstancePerLifetimeScope();

        
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
