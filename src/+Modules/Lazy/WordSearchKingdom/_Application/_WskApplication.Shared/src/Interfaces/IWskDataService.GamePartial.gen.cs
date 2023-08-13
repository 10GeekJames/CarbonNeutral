// ag=yes
namespace WskApplication.Shared.Interfaces; 
public partial interface IWskDataService
{
    Task<GameViewModel?> GameCheckWordCoordsAsync(GameCheckWordCoordsRequest request);
    Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request);
    Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request);
    Task<GameViewModel?> GameRecreateGridAsync(GameRecreateGridRequest request);

}