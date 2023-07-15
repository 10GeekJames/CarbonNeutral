using System;
namespace WskCore.Entities;
public class Author : BaseEntityTracked<Guid>, IAggregateRoot
{
    public NameVO Name { get; private set; }

    private readonly List<Book> _books = new();
    public IEnumerable<Book> Books => _books.AsReadOnly();

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Author() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Author(NameVO name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return Name.ToString();
    }    
}
