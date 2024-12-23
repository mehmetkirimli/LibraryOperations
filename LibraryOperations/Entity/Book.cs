using System.ComponentModel.DataAnnotations;

namespace LibraryOperations.Entity
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }  
        public DateTime PublishedDate { get; set; }
        [Range(0,10000)]
        public int pages { get; set; }   

    }
}
