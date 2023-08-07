namespace AccountModuleCore.TestData.Entities;
public static class KnownBusinessTestData {
    
    public readonly static KnownBusiness JamesBusiness;
    public readonly static KnownBusiness KpBusiness;

    public readonly static IEnumerable<KnownBusiness> AllKnownBusinesses;


    static KnownBusinessTestData() {
        JamesBusiness = new("10geek corp");
        KpBusiness = new ("kp corp");
        
        JamesBusiness.AddKnownBusinessWebsite(KnownBusinessWebsiteTestData.JamesBusinessWebsite);
        
        AllKnownBusinesses = new List<KnownBusiness> {
            JamesBusiness,
            KpBusiness
        }
        .AsReadOnly();
    }
}