using LibraryOperations.Entity;
using LibraryOperations.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryOperations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase // Controller'dan extend edilseydi View yapısı olurdu ama şimdilik Swagger'da gözükecek şekilde API yapısı olacak. 
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Book ID mismatch.");
            }
            if (ModelState.IsValid)
            {
                var updatedBook = bookService.UpdateBook(book);
                if (updatedBook == null)
                {
                    return NotFound();
                }
                return Ok(updatedBook);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            bookService.DeleteBookByIdAsync(id);
            return NoContent();
        }
    }
}
