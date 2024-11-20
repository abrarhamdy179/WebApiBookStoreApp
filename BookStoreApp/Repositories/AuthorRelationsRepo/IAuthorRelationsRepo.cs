using BookStoreApp.SellerDto.AuthorDto;
using Microsoft.Identity.Client;

namespace BookStoreApp.Repositories.AuthorRelationsRepo
{
    public interface IAuthorRelationsRepo
    {
        public void AddAuthorBookCategory(AuthorDtoRelations authorDto);
        public List<AuthorDtoRelations> GetAllAuthorBookCategory();
        public AuthorDtoRelations GetAuthorBookCategoryById(int id);
        public void UpdateAuthorBookCategory(int id, AuthorDtoRelations authorDto);
        public void DeleteAuthorBookCategory(int id);
    }
}
