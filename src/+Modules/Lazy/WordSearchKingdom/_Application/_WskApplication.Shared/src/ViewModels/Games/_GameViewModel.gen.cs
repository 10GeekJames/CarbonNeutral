// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public Guid KnownUserId { get; set; }
     public int Height { get; set; } = 0;
     public int Width { get; set; } = 0;
     public GameDifficulties GameDifficulty { get; set; }
     public List<GameGridViewModel> GameGrids { get; set; } = new();
     public string HiddenWordsData { get; set; } = "";
     public string GameTagsData { get; set; } = "";
     public string GameCategoriesData { get; set; } = "";

     public GameGridViewModel? GameGrid => GameGrids.FirstOrDefault(); 

     public IEnumerable<string>? HiddenWords => !string.IsNullOrWhiteSpace(HiddenWordsData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(HiddenWordsData) : null;  

     public IEnumerable<string>? GameTags => !string.IsNullOrWhiteSpace(GameTagsData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(GameTagsData) : null; 

     public IEnumerable<string>? GameCategories => !string.IsNullOrWhiteSpace(GameCategoriesData) ? Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>?>(GameCategoriesData) : null; 


} 
        