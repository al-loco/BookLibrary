using BookLibraryAPI.Models;

namespace BookLibraryAPI.Services
{
    public class BookService
    {

        private readonly List<Book> _books;
        private int _nextId;

        public BookService()
        {
            _nextId = 1;
            _books = new List<Book>
            {
                new Book { Id = _nextId++, Title = "Jurassic Park", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 1990, LoanedDate = new DateTime(2024, 11, 01), DueDate = new DateTime(2024, 11, 14), IsExtended = false },
                new Book { Id = _nextId++, Title = "The Lost World", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 1995, LoanedDate = null, DueDate = null, IsExtended = false },
                new Book { Id = _nextId++, Title = "The Colour of Magic", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1983,  LoanedDate = new DateTime(2024, 10, 26), DueDate = new DateTime(2024, 11, 16), IsExtended = true },
                new Book { Id = _nextId++, Title = "Guards! Guards!", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1989, LoanedDate = null, DueDate = null, IsExtended = false },
                new Book { Id = _nextId++, Title = "Mort", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1987,  LoanedDate = new DateTime(2024, 11, 11), DueDate = new DateTime(2024, 11, 25), IsExtended = false },
                new Book { Id = _nextId++, Title = "Prey", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 2002,  LoanedDate = null, DueDate = null, IsExtended = false },
                new Book { Id = _nextId++, Title = "Good Omens", Author = "Terry Pratchett & Neil Gaiman", Genre = "Fantasy", YearPublished = 1990, LoanedDate = new DateTime(2024, 10, 25), DueDate = new DateTime(2024, 11, 08), IsExtended = false },
            };
        }

        public IEnumerable<Book> GetAll() => _books;

        public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public bool Update(int id, Book updatedBook)
        {
            var book = GetById(id);
            if (book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.YearPublished = updatedBook.YearPublished;
            book.DueDate = updatedBook.DueDate;
            book.LoanedDate = updatedBook.LoanedDate;
            book.IsExtended = updatedBook.IsExtended;

            return true;
        }

        public bool Delete(int id)
        {
            var book = GetById(id);
            return book != null && _books.Remove(book);
        }
    }
}
