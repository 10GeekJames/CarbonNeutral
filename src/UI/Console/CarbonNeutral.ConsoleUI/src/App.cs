namespace CarbonNeutral.ConsoleUI;

public class App
{   
    private IWskDataService _wskDataService;
    public App(IWskDataService wskDataService) {
        _wskDataService = wskDataService;
    }

    public async Task RunAsync()
    {
        Console.WriteLine("I LIVE!");
        var bookQry = new BooksFindQry("a");
        var books = await _wskDataService.BooksFindAsync(bookQry);
        foreach(var book in books) {
            Console.WriteLine($"{book.Title}");
        }
    }
}