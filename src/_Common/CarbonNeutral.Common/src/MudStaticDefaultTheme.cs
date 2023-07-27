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
            // Primary = Colors.Blue.Lighten1
        },

        LayoutProperties = new LayoutProperties()
        {
            DrawerWidthLeft = "200px",
            DrawerWidthRight = "300px"
        },

        Typography = new Typography()
        {
            H1 = new H1()
            {
                FontFamily = new[] { "Roboto", "Helvetica", "Arial", "sans-serif" },
                FontSize = "1.25rem",
                FontWeight = 500,
                LineHeight = 1.6,
                LetterSpacing = ".0075em"
            }
        }
    };
}