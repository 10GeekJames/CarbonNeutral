namespace WskApplication.Shared.Interfaces;

public partial interface IWskDataService {
    Task<BookViewModel?> BookAddAsync(BookAddCmd cmd);
    Task<List<BookViewModel>?> BooksGetAllAsync(BooksGetAllQry qry);
    Task<List<BookViewModel>?> BooksFindAsync(BooksFindQry qry);
}