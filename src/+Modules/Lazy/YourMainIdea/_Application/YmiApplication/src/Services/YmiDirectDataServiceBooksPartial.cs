namespace YmiApplication.Services;
public partial class YmiDirectDataService
{
    public async Task<BookViewModel?> BookAddAsync(BookAddCmd cmd)
    {
        return _mapper.Map<BookViewModel>(await _mediator.Send(cmd));
    }
    public async Task<List<BookViewModel>?> BooksGetAllAsync(BooksGetAllQry qry)
    {
        return _mapper.Map<List<BookViewModel>>(await _mediator.Send(qry));
    }
    public async Task<List<BookViewModel>?> BooksFindAsync(BooksFindQry qry)
    {
        return _mapper.Map<List<BookViewModel>>(await _mediator.Send(qry));
    }
}
