﻿namespace BookLibraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public DateTime? LoanedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsExtended { get; set; }
    }
}
