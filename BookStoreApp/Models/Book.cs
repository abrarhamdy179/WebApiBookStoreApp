namespace BookStoreApp.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public double BookPrice { get; set; }
        public Author Author { get; set; }
        public List<Category> Categories { get; set; }  
        public List<Library> libraries { get; set; }
    }
}
