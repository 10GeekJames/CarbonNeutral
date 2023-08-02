using MudBlazor;
namespace CarbonNeutral.Common;
public static class MudStaticDefaultTheme
{
    public static MudTheme Default = new MudTheme()
    {
        Palette = new PaletteLight()
        {
            // Primary = Colors.Pink.Default,
            // Secondary = Colors.Green.Accent4,
            // AppbarBackground = Colors.Red.Default,
        },
        PaletteDark = new PaletteDark()
        {
            // Primary = "green",
        },
        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "200px",
            DrawerWidthRight = "300px",
            AppbarHeight = "110px",
        },
        Typography = new Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] { "Courier New", "Helvetica", "Arial", "sans-serif" }
            },
            // H1 = new H1()
            // {
            //     FontFamily = new[] { "Roboto", "Helvetica", "Arial", "sans-serif" },
            //     FontSize = "1.25rem",
            //     FontWeight = 500,
            //     LineHeight = 1.6,
            //     LetterSpacing = ".0075em"
            // }
        }
    };
}