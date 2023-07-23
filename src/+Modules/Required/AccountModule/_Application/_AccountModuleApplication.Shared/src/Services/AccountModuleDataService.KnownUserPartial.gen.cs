// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownUserViewModel?> KnownUserCreateByUserIdAsync(KnownUserCreateByUserIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }
    public async Task<KnownUserViewModel?> KnownUserGetByEmailAddressAsync(KnownUserGetByEmailAddressRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }
    public async Task<KnownUserViewModel?> KnownUserGetByUserIdAsync(KnownUserGetByUserIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }
    public async Task<KnownUserViewModel?> KnownUserGetByUserIdWebsiteIdAsync(KnownUserGetByUserIdWebsiteIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }
    public async Task<KnownUserViewModel?> KnownUserGetAsync(KnownUserGetRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }
    public async Task<KnownUserViewModel?> KnownUserUpdateAccountAsync(KnownUserUpdateAccountRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownUserViewModel>();
    }

}
