
namespace WskApplication.Shared.Services;
public partial class WskModuleHttpDataService
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllQry qry)
    {
        var response = await _httpClient.GetAsync(GamesGetAllRequest.BuildRoute());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<GameViewModel>>();
    }     
}
