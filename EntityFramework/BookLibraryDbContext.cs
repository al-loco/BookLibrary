using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Models;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Jurassic Park", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 1990, LoanedDate = new DateTime(2024, 11, 01), DueDate = new DateTime(2024, 11, 14), IsExtended = false },
            new Book { Id = 2, Title = "The Lost World", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 1995, LoanedDate = null, DueDate = null, IsExtended = false },
            new Book { Id = 3, Title = "The Colour of Magic", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1983, LoanedDate = new DateTime(2024, 10, 26), DueDate = new DateTime(2024, 11, 16), IsExtended = true },
            new Book { Id = 4, Title = "Guards! Guards!", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1989, LoanedDate = null, DueDate = null, IsExtended = false },
            new Book { Id = 5, Title = "Mort", Author = "Terry Pratchett", Genre = "Fantasy", YearPublished = 1987, LoanedDate = new DateTime(2024, 11, 11), DueDate = new DateTime(2024, 11, 25), IsExtended = false },
            new Book { Id = 6, Title = "Prey", Author = "Michael Crichton", Genre = "Science Fiction", YearPublished = 2002, LoanedDate = null, DueDate = null, IsExtended = false },
            new Book { Id = 7, Title = "Good Omens", Author = "Terry Pratchett & Neil Gaiman", Genre = "Fantasy", YearPublished = 1990, LoanedDate = new DateTime(2024, 10, 25), DueDate = new DateTime(2024, 11, 08), IsExtended = false }
        );
    }
}