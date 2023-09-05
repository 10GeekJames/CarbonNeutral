// ag=yes
namespace WskApplication.Shared.Services; 
public partial class WskHttpDataService
{
    public async Task<GameViewModel?> GameCheckWordCoordsAsync(GameCheckWordCoordsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameGetFullGridAsync(GameGetFullGridRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }

}
