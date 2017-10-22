namespace ArqLibrarianClassic.Library
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; }
        public string Author { get; }
        public string Isbn { get; }
        public string Publisher { get; }
        public int Year { get; }
        public string Category { get; }
        public int Rating { get; set; }

        public Book(string title, string author, string isbn, string publisher, int year, string category)
        {
            this.Title = title;
            this.Author = author;
            this.Isbn = isbn;
            this.Publisher = publisher;
            this.Year = year;
            this.Category = category;
            this.Rating = -1;
        }

        public override string ToString()
        {
            return $"{this.Id}: '{this.Title}' - {this.Author} [{this.Isbn}] '{this.Publisher}', {this.Year}, '{this.Category}'" +
                   $" {RatingString()}";
        }

        private string RatingString()
        {
            return this.Rating > 0 ? $"rating: {this.Rating.ToString()}" : ". Not rated yet.";
        }
    }
}