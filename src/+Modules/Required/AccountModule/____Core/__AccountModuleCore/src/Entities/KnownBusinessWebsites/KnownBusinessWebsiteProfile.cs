using System;
using System.Diagnostics.CodeAnalysis;

namespace AccountModuleCore.Entities;
public class KnownBusinessWebsiteProfile : BaseEntityTracked<Guid>, IAggregateRoot
{
    private KnownBusinessWebsiteProfile() { }
    public KnownBusinessWebsiteProfile(KnownBusinessWebsite knownBusinessWebsite, string defaultUrl, string landingUrl, string logoImage)
    {
        DefaultUrl = defaultUrl;
        LogoImage = logoImage;
        LandingUrl = landingUrl;
        KnownBusinessWebsite = knownBusinessWebsite;
    }
    public KnownBusinessWebsiteProfile(Guid id, KnownBusinessWebsite knownBusinessWebsite, string defaultUrl, string landingUrl, string logoImage) : this(knownBusinessWebsite, defaultUrl, landingUrl, logoImage)
    {
        Id = id;
    }

    public KnownBusinessWebsiteProfile(Guid id, string defaultUrl, string landingUrl, string logoImage) : this(null, defaultUrl, landingUrl, logoImage)
    {
        DefaultUrl = defaultUrl;
        LogoImage = logoImage;
        LandingUrl = landingUrl;
        Id = id;
    }
    [MaxLength(1000)]
    public string? DefaultUrl { get; set; }
    [MaxLength(1000)]
    public string? LandingUrl { get; set; }
    [MaxLength(100)]
    public string? RootFolder { get; set; }
    [MaxLength(100)]
    public string? LogoImage { get; set; }
    [MaxLength(100)]
    public string? Surface { get; set; }
    [MaxLength(100)]
    public string? Black { get; set; }
    [MaxLength(100)]
    public string? Background { get; set; }
    [MaxLength(100)]
    public string? BackgroundGrey { get; set; }
    [MaxLength(100)]
    public string? DrawerBackground { get; set; }
    [MaxLength(100)]
    public string? AppbarBackground { get; set; }
    [MaxLength(100)]
    public string? ActionDefault { get; set; }
    [MaxLength(100)]
    public string? ActionDisabled { get; set; }
    [MaxLength(100)]
    public string? ActionDisabledBackground { get; set; }
    [MaxLength(100)]
    public string? Divider { get; set; }
    [MaxLength(100)]
    public string? DividerLight { get; set; }
    [MaxLength(100)]
    public string? TableLines { get; set; }
    [MaxLength(100)]
    public string? LinesDefault { get; set; }
    [MaxLength(100)]
    public string? LinesInputs { get; set; }
    [MaxLength(100)]
    public string? Primary { get; set; }
    [MaxLength(100)]
    public string? Secondary { get; set; }
    [MaxLength(100)]
    public string? Info { get; set; }
    [MaxLength(100)]
    public string? Success { get; set; }
    [MaxLength(100)]
    public string? Warning { get; set; }
    [MaxLength(100)]
    public string? Error { get; set; }
    [MaxLength(100)]
    public string? AppbarText { get; set; }
    [MaxLength(100)]
    public string? TextPrimary { get; set; }
    [MaxLength(100)]
    public string? TextSecondary { get; set; }
    [MaxLength(100)]
    public string? TextDisabled { get; set; }
    [MaxLength(100)]
    public string? DrawerText { get; set; }
    [MaxLength(100)]
    public string? DrawerIcon { get; set; }
    [MaxLength(100)]
    public string? DrawerWidthLeft { get; set; }
    [MaxLength(100)]
    public string? DrawerWidthRight { get; set; }
    [MaxLength(100)]
    public string? DefaultFontFamily { get; set; }
    [MaxLength(100)]
    public string? DefaultFontSize { get; set; }
    public int? DefaultFontWeight { get; set; }
    public double? DefaultLineHeight { get; set; }
    [MaxLength(100)]
    public string? DefaultLetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H1FontFamily { get; set; }
    [MaxLength(100)]
    public string? H1FontSize { get; set; }
    public int? H1FontWeight { get; set; }
    public double? H1LineHeight { get; set; }
    [MaxLength(100)]
    public string? H1LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H2FontFamily { get; set; }
    [MaxLength(100)]
    public string? H2FontSize { get; set; }
    public int? H2FontWeight { get; set; }
    public double? H2LineHeight { get; set; }
    [MaxLength(100)]
    public string? H2LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H3FontFamily { get; set; }
    [MaxLength(100)]
    public string? H3FontSize { get; set; }
    public int? H3FontWeight { get; set; }
    public double? H3LineHeight { get; set; }
    [MaxLength(100)]
    public string? H3LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H4FontFamily { get; set; }
    [MaxLength(100)]
    public string? H4FontSize { get; set; }
    public int? H4FontWeight { get; set; }
    public double? H4LineHeight { get; set; }
    [MaxLength(100)]
    public string? H4LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H5FontFamily { get; set; }
    [MaxLength(100)]
    public string? H5FontSize { get; set; }
    public int? H5FontWeight { get; set; }
    public double? H5LineHeight { get; set; }
    [MaxLength(100)]
    public string? H5LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? H6FontFamily { get; set; }
    [MaxLength(100)]
    public string? H6FontSize { get; set; }
    public int? H6FontWeight { get; set; }
    public double? H6LineHeight { get; set; }
    [MaxLength(100)]
    public string? H6LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? Body1FontFamily { get; set; }
    [MaxLength(100)]
    public string? Body1FontSize { get; set; }
    public int? Body1FontWeight { get; set; }
    public double? Body1LineHeight { get; set; }
    [MaxLength(100)]
    public string? Body1LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? Body2FontFamily { get; set; }
    [MaxLength(100)]
    public string? Body2FontSize { get; set; }
    public int? Body2FontWeight { get; set; }
    public double? Body2LineHeight { get; set; }
    [MaxLength(100)]
    public string? Body2LetterSpacing { get; set; }
    [MaxLength(100)]
    public string? ButtonFontFamily { get; set; }
    [MaxLength(100)]
    public string? ButtonFontSize { get; set; }
    public int? ButtonFontWeight { get; set; }
    public double? ButtonLineHeight { get; set; }
    [MaxLength(100)]
    public string? ButtonLetterSpacing { get; set; }
    [MaxLength(100)]
    public string? CaptionFontFamily { get; set; }
    [MaxLength(100)]
    public string? CaptionFontSize { get; set; }
    public int? CaptionFontWeight { get; set; }
    public double? CaptionLineHeight { get; set; }
    [MaxLength(100)]
    public string? CaptionLetterSpacing { get; set; }
    [MaxLength(100)]
    public string? OverlineFontFamily { get; set; }
    [MaxLength(100)]
    public string? OverlineFontSize { get; set; }
    public int? OverlineFontWeight { get; set; }
    public double? OverlineLineHeight { get; set; }
    [MaxLength(100)]
    public string? OverlineLetterSpacing { get; set; }
    public Guid KnownBusinessWebsiteId { get; set; }
    public KnownBusinessWebsite? KnownBusinessWebsite { get; set; }

}