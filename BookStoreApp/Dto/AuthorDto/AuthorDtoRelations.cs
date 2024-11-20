using BookStoreApp.SellerDto.BookDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;
using BookStoreApp.SellerDto.SellerDto;
using BookStoreApp.Models;

namespace BookStoreApp.SellerDto.AuthorDto
{
    public class AuthorDtoRelations
    {
        public string AuthorNameDto { get; set; }
        public string AuthorBioDto { get; set; }
        public List<BookCategoryDto> bookDtos { get; set; }
        public List<CategoryDtoPost> categoryDtos { get; set; }
        public List<SellerLibraryDto> libraryDtos { get; set; }
    }
}
