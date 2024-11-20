namespace BookStoreApp.Models
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string LibraryName { get; set; }
        public string LibraryAddress { get; set; }
        public List<Book> Books { get; set; }
        public Seller Seller { get; set; }
    }
}
