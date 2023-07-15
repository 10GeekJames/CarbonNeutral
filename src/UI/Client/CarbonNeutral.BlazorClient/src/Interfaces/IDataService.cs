namespace CarbonNeutral.BlazorClient.Interfaces
{
    public interface IDataService : IDisposable
    {
        public event Action OnChange;
        Task<KnownBusinessWebsiteViewModel> KnownBusinessWebsiteGet();        
    }
}