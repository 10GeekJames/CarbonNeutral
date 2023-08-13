using System.Reflection;
using Module = Autofac.Module;

namespace LiveRoomCore;
public class LiveRoomCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        /* foreach (var liveRoomTestData in Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsAssignableTo(typeof(ILiveRoomTestData)) && x.IsClass)
                    .OrderBy(rs => rs.Name))
        {
            builder.RegisterType(liveRoomTestData);
        } */        
    }
}
