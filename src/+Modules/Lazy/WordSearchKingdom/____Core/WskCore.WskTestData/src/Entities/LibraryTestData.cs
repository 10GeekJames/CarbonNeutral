namespace WskCore.WskTestData.Entities;
public static class LibraryWskTestData
{
    public static string FirstStreetLibraryName = "First Street Library";
    public static Library FirstStreetLibrary;
    public static PhysicalAddressVO FirstStreetLibraryAddress = new (
        "123 First Street",
        "Suite 100",
        "First City",
        "First State",
        "12345",
        "First Country"
    );

    public static string SecondStreetLibraryName = "Second Street Library";
    public static Library SecondStreetLibrary;
    public static PhysicalAddressVO SecondStreetLibraryAddress = new (
        "456 Second Street",
        "Suite 200",
        "Second City",
        "Second State",
        "67890",
        "Second Country"
    );

    public static IEnumerable<Library> AllLibraries;

    static LibraryWskTestData()
    {
        FirstStreetLibrary = new Library(FirstStreetLibraryName, FirstStreetLibraryAddress, null, null);
        SecondStreetLibrary = new Library(SecondStreetLibraryName, SecondStreetLibraryAddress, null, null);

        AllLibraries = new List<Library> {
            FirstStreetLibrary,
            SecondStreetLibrary
        };
    }
}
