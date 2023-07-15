namespace AccountModuleCore.TestData.Entities;
public static class KnownBusinessWebsiteTestData {
    
    public readonly static KnownBusinessWebsite JamesBusinessWebsite;
    public readonly static KnownBusinessWebsite KpBusinessWebsite;

    public readonly static IEnumerable<KnownBusinessWebsite> AllKnownBusinessWebsites;


    static KnownBusinessWebsiteTestData() {
        JamesBusinessWebsite = new(KnownBusinessTestData.JamesBusiness, "localhost:5020", "10geek website");
        KpBusinessWebsite = new (KnownBusinessTestData.KpBusiness, "localhost:5020", "kp corp");
        
        AllKnownBusinessWebsites = new List<KnownBusinessWebsite> {
            JamesBusinessWebsite,
            KpBusinessWebsite
        }
        .AsReadOnly();
    }
}