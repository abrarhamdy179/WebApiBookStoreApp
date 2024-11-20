using BookStoreApp.SellerDto.CategoryDto;
namespace BookStoreApp.SellerDto.BookDto

{
    public class BookCategoryDto 
    {
        public string BookTitleDto { get; set; }
        public string BookDescriptionDto { get; set; }
        public double BookPriceDto { get; set; }
        public List<CategoryDtoPost> categoryDto { get; set; }
    }
}
