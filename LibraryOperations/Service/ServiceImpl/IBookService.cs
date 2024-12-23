using LibraryOperations.Entity;

namespace LibraryOperations.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        void RemoveBook(Book book);
        Task DeleteBookByIdAsync(int id);
       
      
       
    }
}
