namespace YmiApplication.Shared.Interfaces;

public partial interface IYmiDataService {
    Task<BookViewModel?> BookAddAsync(BookAddCmd cmd);
    Task<List<BookViewModel>?> BooksGetAllAsync(BooksGetAllQry qry);
    Task<List<BookViewModel>?> BooksFindAsync(BooksFindQry qry);
}