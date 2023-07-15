namespace CarbonNeutral.Common.Interfaces;
public interface IHttpClientService : IDisposable
{
    public event Action OnChange;
    //Task<NoBugViewModel> NoBugCreate(NoBugCreateRequest request);
}
