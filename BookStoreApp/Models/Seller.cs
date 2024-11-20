namespace BookStoreApp.Models
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public int SellerAge { get; set; }
        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
