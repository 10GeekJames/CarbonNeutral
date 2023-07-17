namespace WskApplication.Shared.Interfaces;

public partial interface IWskDataService {
    Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request);    
    Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request);    
    Task<GameViewModel?> GameRecreateGridAsync(GameRecreateGridRequest request);    
    
}