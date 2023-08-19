// ag=yes
namespace LiveRoomApi.Controllers; 
public partial class LiveRoomSessionController : BaseController
{
    public LiveRoomSessionController(IMediator mediator, IMapper mapper, ILiveRoomDataService dataService) : base(mediator, mapper, dataService) { }

}
