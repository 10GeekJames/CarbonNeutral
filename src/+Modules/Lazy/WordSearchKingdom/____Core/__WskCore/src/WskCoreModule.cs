using System.Reflection;
using Module = Autofac.Module;

namespace WskCore;
public class WskCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        /* foreach (var wskTestData in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(IWskTestData)) && x.IsClass)
                    .OrderBy(rs => rs.Name))
        {
            builder.RegisterType(wskTestData);
        } */        
    }
}
