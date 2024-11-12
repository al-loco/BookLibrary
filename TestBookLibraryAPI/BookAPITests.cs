using BookLibraryAPI.Services;
using BookLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TestBookLibraryAPI
{
    public class BookAPITests
    {
        private static LibraryContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDatabase")
                .Options;

            var context = new LibraryContext(options);
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public void Test1_GetAll()
        {
            var context = CreateInMemoryDbContext();
            var service = new BookService(context);

            var expectedResult = 7;
            var result = service.GetAll().Count();
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Test2_GetById()
        {
            var context = CreateInMemoryDbContext();
            var service = new BookService(context);

            var bookId = 3;
            var result = service.GetById(bookId);

            if (result is null) Assert.Fail();

            Assert.Equal(bookId, result.Id);
            Assert.Equal("The Colour of Magic", result.Title);
            Assert.Equal("Terry Pratchett", result.Author);
            Assert.Equal("Fantasy", result.Genre);
            Assert.Equal(1983, result.YearPublished);
            Assert.Equal(new DateTime(2024, 10, 26), result.LoanedDate);
            Assert.Equal(new DateTime(2024, 11, 16), result.DueDate);
            Assert.True(result.IsExtended);
        }

        [Fact]
        public void Test3_AddBook()
        {
            var context = CreateInMemoryDbContext();
            var service = new BookService(context);
            
            var expectedId = service.GetAll().Max(x => x.Id) + 1;
            var book = new Book { Title = "Test Book", Author = "Author", Genre = "Fiction", YearPublished = 2022 };
            var addedBook = service.Add(book);

            Assert.Equal(expectedId, addedBook.Id);
            Assert.Equal("Test Book", addedBook.Title);
            Assert.Equal("Author", addedBook.Author);
            Assert.Equal("Fiction", addedBook.Genre);
            Assert.Equal(2022, addedBook.YearPublished);
            Assert.Null(addedBook.LoanedDate);
            Assert.Null(addedBook.DueDate);
            Assert.False(addedBook.IsExtended);
        }

        [Fact]
        public void Test4_UpdateBook()
        {
            var context = CreateInMemoryDbContext();
            var service = new BookService(context);

            var bookId = 1;
            var book = new Book { Id = 1, Title = "Jurassic Park", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 1990, LoanedDate = new DateTime(2024, 11, 01), DueDate = new DateTime(2024, 11, 22), IsExtended = true };
            var addedBook = service.Update(book);

            Assert.Equal(bookId, addedBook.Id);
            Assert.Equal("Jurassic Park", addedBook.Title);
            Assert.Equal("Michael Crichton", addedBook.Author);
            Assert.Equal("Science Fiction", addedBook.Genre);
            Assert.Equal(1990, addedBook.YearPublished);
            Assert.Equal(new DateTime(2024, 11, 01), addedBook.LoanedDate);
            Assert.Equal(new DateTime(2024, 11, 22), addedBook.DueDate);
            Assert.True(addedBook.IsExtended);
        }

        [Fact]
        public void Test5_DeleteBook()
        {
            var context = CreateInMemoryDbContext();
            var service = new BookService(context);

            var bookId = 6;
            var result = service.Delete(bookId);

            Assert.True(result);
        }
    }
}