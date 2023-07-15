namespace AccountModuleCore;
public class AccountModuleCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<KnownAccount>();
        /*     .As<IToDoItemSearchService>().InstancePerLifetimeScope(); */
    }
}
