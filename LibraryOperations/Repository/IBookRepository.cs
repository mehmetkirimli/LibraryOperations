using LibraryOperations.Entity;

namespace LibraryOperations.Repository
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        void RemoveBook(Book book);
        Task DeleteBookByIdAsync(int id);
        Book UpdateBook(Book book);
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        void SaveChanges(); // Save changes to the database
    }
}
