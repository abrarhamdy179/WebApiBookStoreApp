using BookStoreApp.Dto.SellerDto;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStoreApp.Repositories.SellerRelationsRepo
{
    public interface ISellerRelationsRepo
    {
        public List<SellerDtoRelations> GetAllSellerCategoryLibrary();
        public SellerDtoRelations GetSellerCategoryLibraryById (int id);
        public void UpdateSellerCategoryLibrary(int id, SellerAuthorDto sellerDto);
        public void AddSellerCategoryLibrary(SellerAuthorDto sellerDto);
        public void DeleteSellerCategoryLibrary(int id);
    }
}
