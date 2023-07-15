namespace WskCore.UnitTests;

public class LibraryInventoryTests
{
    [Fact]
    public void LibraryCanHaveAnInventoryOfBooks()
    {
        var library = LibraryWskTestData.FirstStreetLibrary;
        var book = BookWskTestData.BookAlfradoTheGreat;
        
        library.AddBookToInventory(book);
        library.Books.FirstOrDefault(rs => rs.Isbn == book.Isbn && rs.Title == book.Title).Should().NotBeNull();
    }
}
