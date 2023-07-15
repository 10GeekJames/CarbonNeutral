namespace CarbonNeutral.Common.Services;
public class RandomizerService
{
    public string RandomBackgroundClass()
    {
        var rnd = new Random().Next(1, 30);
        return $"background{rnd}";
    }
    public string RandomBackgroundStyle()
    {
        var rnd = new Random().Next(1, 30);
        return $"background-image: url('./ithepubliclibrary/big_background ({rnd}).png'); height: 100vh;background-repeat: no-repeat;background-size: cover;background-attachment: fixed;background-position: center center";
    }
    public string RandomBackgroundStyle(long count)
    {
        var tempStr = "";
        for (int i = 0; i < count; i++)
        {
            var rnd = new Random().Next(1, 30);
            tempStr += $"url('./ithepubliclibrary/big_background ({rnd}).png'),";
        }
        
        return $"background-image: {tempStr.Substring(0, tempStr.Length-1)}; height: 100vh;background-repeat: no-repeat;background-size: cover;background-attachment: fixed;background-position: center center";
    }
    public string RandomGradientStyle()
    {
        var rnd = new Random();
        var color1 = String.Format("#{0:X6}", rnd.Next(0x1000000));
        var color2 = String.Format("#{0:X6}", rnd.Next(0x1000000)); 
        return $"background-image: linear-gradient({color1}, {color2}); -webkit-background-clip: text; -webkit-text-fill-color: transparent;";
    }
    public string RandomBackgroundGradientStyle()
    {
        var rnd = new Random();
        var color1 = String.Format("#{0:X6}", rnd.Next(0x1000000));
        var color2 = String.Format("#{0:X6}", rnd.Next(0x1000000)); 
        return $"background: linear-gradient({color1}, {color2});";
    }
}