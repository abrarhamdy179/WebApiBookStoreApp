using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;

namespace BookStoreApp.SellerDto.BookDto
{
    public class BookDtoRelations
    {
        public string BookTitleDto { get; set; }
        public string BookDescriptionDto { get; set; }
        public double BookPriceDto { get; set; }
        public List<CategoryDtoPost> categoryDtos { get; set; }
        public List<SellerLibraryDto> libraryDtos { get; set; }
        public AuthorDtoPost authorDto {  get; set; }

    }
}
