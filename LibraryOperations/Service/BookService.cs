
using LibraryOperations.Entity;
using LibraryOperations.Repository;
using LibraryOperations.Service;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAllBooks();
    }

    public Book GetBookById(int id)
    {
        return _bookRepository.GetBookById(id);
    }

    public Book AddBook(Book book)
    {
        return _bookRepository.AddBook(book);
    }

    public Book UpdateBook(Book book)
    {
        return _bookRepository.UpdateBook(book);
    }

    public void RemoveBook(Book book)
    {
        _bookRepository.RemoveBook(book);
    }

    public async Task DeleteBookByIdAsync(int id)
    {
        await _bookRepository.DeleteBookByIdAsync(id);
    }
}
