using BookStoreApp.SellerDto.AuthorDto;

namespace BookStoreApp.Repositories.AuthorRepository
{
    public interface IAuthorRepo
    {
        public List<AuthorDtoPost> GetAllAuthors ();
        public AuthorDtoPost GetAuthor(int id);
        public void AddAuthor (AuthorDtoPost authorDtoPost);
        public void UpdateAuthor (int id ,AuthorDtoPost authorDtoPost);
        public void DeleteAuthor (int id);
    }
}
