// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownBusinessWebsiteViewModel?> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
    }
    public async Task<KnownBusinessWebsiteViewModel?> WebsitePageUpdateAsync(WebsitePageUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
    }

}
