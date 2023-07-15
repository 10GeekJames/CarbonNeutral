using MudBlazor;
namespace CarbonNeutral.BlazorClient;
public static class MudStaticDefaultTheme
{
    public static MudTheme Default = new MudTheme()
    {
        Palette = new MudBlazor.Palette()
        {
            Surface = "rgba(1, 1, 1, 0.65)",
            Black = "rgb(26, 26, 26)",
            Background = "rgb(253, 253, 253)",
            BackgroundGrey = "rgb(200, 200, 200)",
            DrawerBackground = "rgb(26, 26, 26)",
            AppbarBackground = "rgb(255, 255, 255)",

            ActionDefault = "#BEBEBD",
            ActionDisabled = "rgba(255,255,255, 0.25)",
            ActionDisabledBackground = "rgba(255,255,255, 0.50)",
            Divider = "rgba(255,255,255, 0.15)",
            DividerLight = "rgba(255,255,255, 0.8)",
            TableLines = "rgba(255,255,255, 0.2)",
            LinesDefault = "rgba(255,255,255, 0.15)",
            LinesInputs = "rgba(255,255,255, 0.35)",

            Primary = "#7E6FFF",
            Secondary = "#FF4081",
            Tertiary = "#1EC8A5",
            Info = "#4A86FF",
            Success = "#3DCB6C",
            Warning = "#FFB545",
            Error = "#FF3F5F",

            AppbarText = "#3c3c3c",
            TextPrimary = "#FCFCFF",
            TextSecondary = "rgb(175, 175, 175)",
            TextDisabled = "#ffffff",

            DrawerText = "rgba(255,255,255, 0.50)",
            DrawerIcon = "rgba(255,255,255, 0.50)"

        },
        Typography = new MudBlazor.Typography()
        {
            Default = new Default()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H1 = new H1()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "6rem",
                FontWeight = 800,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H2 = new H2()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "3.75rem",
                FontWeight = 700,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H3 = new H3()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "2.5rem",
                FontWeight = 600,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H4 = new H4()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "2.125rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H5 = new H5()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "1.5rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            H6 = new H6()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "1.25rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            
            Subtitle1 = new Subtitle1()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            Subtitle2 = new Subtitle2()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            Body1 = new Body1()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            Body2 = new Body2()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "0.875rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            Button = new Button()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"  
            },
            Caption = new Caption()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            },
            Overline = new Overline()
            {
                FontFamily = new[] { "Montserrat", "sans-serif" },
                FontSize = "0.75rem",
                FontWeight = 400,
                LineHeight = 1.23,
                LetterSpacing = ".01071em"
            }
            
        },
        LayoutProperties = new MudBlazor.LayoutProperties()
        {
            DrawerWidthLeft = "260px",
            DrawerWidthRight = "300px"
        }
    };
}