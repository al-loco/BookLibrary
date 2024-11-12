using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using BookLibraryAPI.Services;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll() => Ok(_context.Books);

        [HttpGet("Id")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _context.Books.Find(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public ActionResult<Book> Add(Book newBook)
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
