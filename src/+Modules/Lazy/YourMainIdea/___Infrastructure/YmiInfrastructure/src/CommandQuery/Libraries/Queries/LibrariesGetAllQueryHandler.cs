namespace YmiInfrastructure.CommandQuery;

public class LibrariesGetAllQueryHandler : IRequestHandler<LibrariesGetAllQuery, List<Library>>
{
    private readonly IRepository<Library> _repository;
    public LibrariesGetAllQueryHandler(IRepository<Library> repository)
    {
        _repository = repository;
    }
    public async Task<List<Library>> Handle(LibrariesGetAllQuery qry, CancellationToken cancellationToken)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}