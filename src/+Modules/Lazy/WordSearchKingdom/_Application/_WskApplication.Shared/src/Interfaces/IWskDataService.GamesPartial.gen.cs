// ag=yes
namespace WskApplication.Shared.Interfaces; 
public partial interface IWskDataService
{
    Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllRequest request);

}