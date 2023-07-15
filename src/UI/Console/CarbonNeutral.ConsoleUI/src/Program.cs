namespace CarbonNeutral.ConsoleUI;
public class Program
{
    static async Task Main(string[] args)
    {
        var builder = CreateHostBuilder(args);
        var startup = new Startup();
        var services = startup.ServiceProvider;

        // do more interesting stuff.

        var app = services.GetService<App>();
        await app.RunAsync();
        Console.WriteLine("Completed");
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        ;

}