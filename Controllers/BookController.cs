using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using BookLibraryAPI.Services;

namespace BookLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService) => _bookService = bookService;

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll() =>Ok(_bookService.GetAll());

        [HttpGet("Id")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _bookService.GetById(id);
            return book != null ? Ok(book) : NotFound();
        }

        [HttpPost]
        public ActionResult<Book> Add(Book book)
        {
            var addedBook = _bookService.Add(book);
            return CreatedAtAction(nameof(GetById), new { id = addedBook.Id }, addedBook);
        }

        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            return _bookService.Delete(id) ? NoContent() : NotFound();
        }
    }
}
