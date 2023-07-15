namespace AccountModuleApplication.Services;

public class AccountModuleDirectDataServiceNotAuthed : AccountModuleDirectDataService
{ 
    public AccountModuleDirectDataServiceNotAuthed(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        
    }
}   
