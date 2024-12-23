using LibraryOperations.Context;
using LibraryOperations.Entity;

namespace LibraryOperations.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;   

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks() 
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book AddBook(Book book)
        {
            var saveData = _context.Books.Add(book).Entity;
            SaveChanges();
            return saveData;
        }

        public Book UpdateBook(Book book)
        {
            var updatedData = _context.Books.Update(book).Entity;
            SaveChanges();
            return updatedData;
        }

        public void RemoveBook(Book book)
        {
            _context.Books.Remove(book);
            SaveChanges();
            Console.WriteLine(book.Title.ToString() + " Kitabı Kütüphaneden Kaldırıldı ... ");
        }

        public async Task DeleteBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id); // Asenkron bulma işlemi.
            if (book != null)
            {
                _context.Books.Remove(book); // Kitabı siler.
                await _context.SaveChangesAsync(); // Asenkron kaydetme işlemi.
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //TODO eğer bazı metotlar hata verirse try-catch blokları dene !!

    }
}
