namespace AccountModuleCore.TestData.Entities;
public static class KnownBusinessTestData {
    
    public readonly static KnownBusiness JamesBusiness;
    public readonly static KnownBusiness KpBusiness;

    public readonly static IEnumerable<KnownBusiness> AllKnownBusinesses;


    static KnownBusinessTestData() {
        JamesBusiness = new("10geek corp");
        KpBusiness = new ("kp corp");
        
        JamesBusiness.AddKnownBusinessWebsite(KnownBusinessWebsiteTestData.JamesBusinessWebsite);
        KpBusiness.AddKnownBusinessWebsite(KnownBusinessWebsiteTestData.KpBusinessWebsite);
        
        AllKnownBusinesses = new List<KnownBusiness> {
            JamesBusiness,
            KpBusiness
        }
        .AsReadOnly();
    }
}