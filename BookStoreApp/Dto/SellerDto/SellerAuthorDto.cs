using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.SellerDto.BookDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;

namespace BookStoreApp.Dto.SellerDto
{
    public class SellerAuthorDto
    {
        public string SellerNameDto { get; set; }
        public int SellerAgeDto { get; set; }
        public LibraryDtoPost libraryDtos { get; set; }
        public List<CategoryDtoPost> categoryDtos { get; set; }
        public List<BookCategoryDto> bookDtos { get; set; }
        public AuthorDtoPost authorDto { get; set; }

    }
}
