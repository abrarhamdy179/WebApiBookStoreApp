using BookStoreApp.Dto.BookDto;
using BookStoreApp.SellerDto.BookDto;

namespace BookStoreApp.Repositories.BookRelationsRepo
{
    public interface IBookRelationsRepo
    {
        public void AddBookCategoryLibrary(BookDtoRelations bookDto);
        public void AddBookCategoryWithhidId(BookCategDto bookDto);
        public List<BookDtoRelations> GetAllBookCategoryLibraries ();
        public BookDtoRelations GetBookCategoryLibraryById (int id);
        public void UpdateBookCategoryLibrary(int id, BookDtoRelations bookDto);
        public void DeleteBookCategoryLibrary(int id);

    }
}
