// ag=yes
namespace LiveRoomApplication.Shared.Services; 
public partial class LiveRoomHttpDataService
{
    public async Task<List<LiveRoomSessionViewModel>?> LiveRoomSessionsGetAllAsync(LiveRoomSessionsGetAllRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<LiveRoomSessionViewModel>>();
    }

}
