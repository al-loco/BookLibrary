using BookLibraryAPI.Models;

namespace BookLibraryAPI.Services
{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll() => _context.Books;

        public Book? GetById(int id) => _context.Books.Find(id);

        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(Book updatedBook)
        {

            _context.Books.Update(updatedBook);
            _context.SaveChanges();
            
            return GetById(updatedBook.Id);
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
