

namespace CarbonNeutral.BlazorClient.Services
{
    public class DataService : IDataService, IDisposable
    {
        private KnownBusinessWebsiteViewModel? _knownBusinessWebsite = null;
        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<KnownBusinessWebsiteViewModel> KnownBusinessWebsiteGet()
        {
            var response = await _httpClient.GetAsync(KnownBusinessWebsiteGetRequest.BuildRoute());

            response.EnsureSuccessStatusCode();
            
            _knownBusinessWebsite = await response.Content.ReadFromJsonAsync<KnownBusinessWebsiteViewModel?>();

            if (_knownBusinessWebsite == null)
            {
                throw new Exception("InvalidReferralAccountException");
            }
            NotifyStateChanged();
            return _knownBusinessWebsite;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}