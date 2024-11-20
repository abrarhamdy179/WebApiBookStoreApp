namespace BookStoreApp.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBio { get; set; }
        public List<Book> Books { get; set; }
    }
}
