namespace WskApplication.Shared.Interfaces;

public partial interface IWskDataService {
    Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllQry qry);    
}