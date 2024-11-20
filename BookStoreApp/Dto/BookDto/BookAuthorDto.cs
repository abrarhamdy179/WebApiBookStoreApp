using BookStoreApp.SellerDto.AuthorDto;

namespace BookStoreApp.Dto.BookDto
{
    public class BookAuthorDto
    {
        public string BookTitleDto { get; set; }
        public string BookDescriptionDto { get; set; }
        public double BookPriceDto { get; set; }
        public AuthorDtoPost authorDto { get; set; }

    }
}
