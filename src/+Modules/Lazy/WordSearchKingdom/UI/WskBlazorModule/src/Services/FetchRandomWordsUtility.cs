using System.Drawing;
using System.Net.Http.Json;
using Newtonsoft.Json;

public class WordData
{
    public string Word { get; set; }
    public int Score { get; set; }
    public List<string> Tags { get; set; }
}
public class ThemeData
{
    public string Word { get; set; }
    public string Definition { get; set; }
    public string Pronunciation { get; set; }
}

public class License
{
    public string Name { get; set; }
    public string Url { get; set; }
}
public class DefinitionItem
{
    public string Definition { get; set; }
    public List<string> Synonyms { get; set; }
    public List<string> Antonyms { get; set; }
    public string Example { get; set; }
}

public class Phonetics
{
    public string Text { get; set; }
    public string Audio { get; set; }
    public string SourceUrl { get; set; }
    public License License { get; set; }
}
public class Definition
{
    public string PartOfSpeech { get; set; }
    public List<DefinitionItem> Definitions { get; set; }
    public List<string> Synonyms { get; set; }
    public List<string> Antonyms { get; set; }
}

public class WordDefinition
{
    public string Word { get; set; }
    public string Phonetic { get; set; }
    public List<Phonetics> Phonetics { get; set; }
    public List<Definition> Meanings { get; set; }
    public List<string> SourceUrls { get; set; }
}


public class FetchRandomWordsUtility
{
    public static async Task<string> getRandomWordsFromApi(string themeWord, int wordCount = 16)
    {
        // call api to get random words
        var wordString = "";
        var client = new HttpClient();
        var response = await client.GetAsync("https://api.datamuse.com/words?ml=" + themeWord);
        
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<WordData> _randomWords = JsonConvert.DeserializeObject<List<WordData>>(jsonResponse);
            
            if (_randomWords.Count > 0)
            {
                for (var i = 0; i < wordCount && i < _randomWords.Count; i++)
                {
                    wordString += _randomWords[i].Word + ",";
                }
                return wordString;
            }
            else
            {
                // Handle the case where no words were found
                return "No words found for the given theme.";
            }
        }
        else
        {
            // Handle the case where the API request was not successful
            return "API request failed.";
        }
    }
    public static async Task<ThemeData> getRandomDefaultTheme()
    {
        // call api to get random word
        var client = new HttpClient();
        var response = await client.GetAsync("https://random-words-api.vercel.app/word");
        
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var _randomWords = JsonConvert.DeserializeObject<List<ThemeData>>(jsonResponse);
            
            if (_randomWords != null)
            {
                return _randomWords[0];
                
            }
            else
            {
                // Handle the case where no words were found
                return new ThemeData() { Word = "No words found for the given theme." };
            }
        }
        else
        {
            // Handle the case where the API request was not successful
            return new ThemeData() { Word = "API request failed." };
        }
    }
    public static async Task<string> getThemeWordDefinition(string themeWord)
    {
        // call api to get random word
        var client = new HttpClient();
        var returnString = "";
        var response = await client.GetAsync("https://api.dictionaryapi.dev/api/v2/entries/en/" + themeWord);
        
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var wordDefinitions = JsonConvert.DeserializeObject<List<WordDefinition>>(jsonResponse);
            returnString = wordDefinitions[0].Meanings[0].Definitions[0].Definition + "#" + wordDefinitions[0].Phonetic;
            
            if (wordDefinitions != null)
            {
                return returnString;
                
            }
            else
            {
                // Handle the case where no words were found
                return "No words found for the given theme.";
            }
        }
        else
        {
            // Handle the case where the API request was not successful
            return "API request failed.";
        }
    }


}
