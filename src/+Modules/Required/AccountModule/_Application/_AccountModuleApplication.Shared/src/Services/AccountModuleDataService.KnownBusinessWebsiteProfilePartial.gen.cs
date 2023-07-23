// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownBusinessWebsiteProfileViewModel?> KnownBusinessWebsiteProfileUpdateAsync(KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessWebsiteProfileViewModel>();
    }

}
