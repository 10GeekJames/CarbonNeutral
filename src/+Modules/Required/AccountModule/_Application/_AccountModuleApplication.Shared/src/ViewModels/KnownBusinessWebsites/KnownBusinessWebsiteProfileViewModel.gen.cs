// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownBusinessWebsiteProfileViewModel : BaseViewModel<Guid>
{ 

     [MaxLength(1000)]
     public string? DefaultUrl { get; set; } = null;
     [MaxLength(1000)]
     public string? LandingUrl { get; set; } = null;
     [MaxLength(100)]
     public string? RootFolder { get; set; } = null;
     [MaxLength(100)]
     public string? LogoImage { get; set; } = null;
     [MaxLength(100)]
     public string? Surface { get; set; } = null;
     [MaxLength(100)]
     public string? Black { get; set; } = null;
     [MaxLength(100)]
     public string? Background { get; set; } = null;
     [MaxLength(100)]
     public string? BackgroundGrey { get; set; } = null;
     [MaxLength(100)]
     public string? DrawerBackground { get; set; } = null;
     [MaxLength(100)]
     public string? AppbarBackground { get; set; } = null;
     [MaxLength(100)]
     public string? ActionDefault { get; set; } = null;
     [MaxLength(100)]
     public string? ActionDisabled { get; set; } = null;
     [MaxLength(100)]
     public string? ActionDisabledBackground { get; set; } = null;
     [MaxLength(100)]
     public string? Divider { get; set; } = null;
     [MaxLength(100)]
     public string? DividerLight { get; set; } = null;
     [MaxLength(100)]
     public string? TableLines { get; set; } = null;
     [MaxLength(100)]
     public string? LinesDefault { get; set; } = null;
     [MaxLength(100)]
     public string? LinesInputs { get; set; } = null;
     [MaxLength(100)]
     public string? Primary { get; set; } = null;
     [MaxLength(100)]
     public string? Secondary { get; set; } = null;
     [MaxLength(100)]
     public string? Info { get; set; } = null;
     [MaxLength(100)]
     public string? Success { get; set; } = null;
     [MaxLength(100)]
     public string? Warning { get; set; } = null;
     [MaxLength(100)]
     public string? Error { get; set; } = null;
     [MaxLength(100)]
     public string? AppbarText { get; set; } = null;
     [MaxLength(100)]
     public string? TextPrimary { get; set; } = null;
     [MaxLength(100)]
     public string? TextSecondary { get; set; } = null;
     [MaxLength(100)]
     public string? TextDisabled { get; set; } = null;
     [MaxLength(100)]
     public string? DrawerText { get; set; } = null;
     [MaxLength(100)]
     public string? DrawerIcon { get; set; } = null;
     [MaxLength(100)]
     public string? DrawerWidthLeft { get; set; } = null;
     [MaxLength(100)]
     public string? DrawerWidthRight { get; set; } = null;
     [MaxLength(100)]
     public string? DefaultFontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? DefaultFontSize { get; set; } = null;
     public int? DefaultFontWeight { get; set; } = null;
     public double? DefaultLineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? DefaultLetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H1FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H1FontSize { get; set; } = null;
     public int? H1FontWeight { get; set; } = null;
     public double? H1LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H1LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H2FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H2FontSize { get; set; } = null;
     public int? H2FontWeight { get; set; } = null;
     public double? H2LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H2LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H3FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H3FontSize { get; set; } = null;
     public int? H3FontWeight { get; set; } = null;
     public double? H3LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H3LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H4FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H4FontSize { get; set; } = null;
     public int? H4FontWeight { get; set; } = null;
     public double? H4LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H4LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H5FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H5FontSize { get; set; } = null;
     public int? H5FontWeight { get; set; } = null;
     public double? H5LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H5LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? H6FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? H6FontSize { get; set; } = null;
     public int? H6FontWeight { get; set; } = null;
     public double? H6LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? H6LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? Body1FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? Body1FontSize { get; set; } = null;
     public int? Body1FontWeight { get; set; } = null;
     public double? Body1LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? Body1LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? Body2FontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? Body2FontSize { get; set; } = null;
     public int? Body2FontWeight { get; set; } = null;
     public double? Body2LineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? Body2LetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? ButtonFontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? ButtonFontSize { get; set; } = null;
     public int? ButtonFontWeight { get; set; } = null;
     public double? ButtonLineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? ButtonLetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? CaptionFontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? CaptionFontSize { get; set; } = null;
     public int? CaptionFontWeight { get; set; } = null;
     public double? CaptionLineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? CaptionLetterSpacing { get; set; } = null;
     [MaxLength(100)]
     public string? OverlineFontFamily { get; set; } = null;
     [MaxLength(100)]
     public string? OverlineFontSize { get; set; } = null;
     public int? OverlineFontWeight { get; set; } = null;
     public double? OverlineLineHeight { get; set; } = null;
     [MaxLength(100)]
     public string? OverlineLetterSpacing { get; set; } = null;
     public Guid KnownBusinessWebsiteId { get; set; }
     public KnownBusinessWebsiteViewModel? KnownBusinessWebsite { get; set; } = null;

} 
        