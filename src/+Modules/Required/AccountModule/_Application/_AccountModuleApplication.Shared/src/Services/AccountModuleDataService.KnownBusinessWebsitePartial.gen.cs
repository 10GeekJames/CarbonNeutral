// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetByUrlAsync(KnownBusinessWebsiteGetByUrlRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
    }
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteGetAsync(KnownBusinessWebsiteGetRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
    }
    public async Task<KnownBusinessWebsiteViewModel?> KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
    }

}
