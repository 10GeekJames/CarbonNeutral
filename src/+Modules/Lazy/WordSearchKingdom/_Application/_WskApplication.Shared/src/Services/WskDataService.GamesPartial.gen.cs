// ag=yes
namespace WskApplication.Shared.Services; 
public partial class WskHttpDataService
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<GameViewModel>>();
    }

}
