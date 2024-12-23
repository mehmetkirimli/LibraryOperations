using LibraryOperations.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryOperations.Context
{
    public class LibraryContext : DbContext
    {
        private readonly IConfiguration _configuration;

        // Constructor'ı doğru şekilde ekledik.
        public LibraryContext(DbContextOptions<LibraryContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // appsettings.json'dan bağlantı dizesini okuyarak kullanıyoruz.
            var connectionString = _configuration.GetConnectionString("Library");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
