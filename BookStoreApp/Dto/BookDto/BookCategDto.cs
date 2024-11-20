using BookStoreApp.Dto.CategoryDto;
using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.SellerDto.LibraryDto;

namespace BookStoreApp.Dto.BookDto
{
    public class BookCategDto
    {
        public string BookTitleDto { get; set; }
        public string BookDescriptionDto { get; set; }
        public double BookPriceDto { get; set; }
        public List<Categ> categoryDtos { get; set; }  
        public List<SellerLibraryDto> libraryDtos { get; set; }
        public AuthorDtoPost authorDto { get; set; }
    }
}
