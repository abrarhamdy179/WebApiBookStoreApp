using BookStoreApp.Data;
using BookStoreApp.Dto.BookDto;
using BookStoreApp.Dto.SellerDto;
using BookStoreApp.Models;
using BookStoreApp.SellerDto.BookDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repositories.SellerRelationsRepo
{
    public class SellerRelationsRepo : ISellerRelationsRepo
    {
        private readonly ApplicationDbContext _context;

        public SellerRelationsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddSellerCategoryLibrary(SellerAuthorDto sellerDto)
        {
            Seller seller = new Seller
            {
                SellerName = sellerDto.SellerNameDto,
                SellerAge = sellerDto.SellerAgeDto,
                Library = new Library
                {
                    LibraryName = sellerDto.libraryDtos.LibraryNameDto,
                    LibraryAddress = sellerDto.libraryDtos.LibraryAddressDto,
                    Books = sellerDto.bookDtos.Select(b => new Book
                    {
                        BookTitle = b.BookTitleDto,
                        BookDescription = b.BookDescriptionDto,
                        BookPrice = b.BookPriceDto,
                        Categories = b.categoryDto.Select(c => new Category
                        {
                            CategoryName = c.CategoryNameDto,
                        }).ToList(),
                        Author = new Author
                        {
                            AuthorName = sellerDto.authorDto.AuthorNameDto,
                            AuthorBio = sellerDto.authorDto.AuthorBioDto,    
                        }
                    }).ToList(),
                },
            };
            _context.sellers.Add(seller);
            _context.SaveChanges();
        }

        public void DeleteSellerCategoryLibrary(int id)
        {
            var seller = _context.sellers.FirstOrDefault(s => s.SellerId == id);
            _context.sellers.Remove(seller);
            _context.SaveChanges();
        }

        public List<SellerDtoRelations> GetAllSellerCategoryLibrary()
        {
            var sellers = _context.sellers
                .Include(l => l.Library)
                .ThenInclude(x => x.Books)
                .ThenInclude(c => c.Categories)
                .Select(s => new SellerDtoRelations
                { 
                    SellerNameDto = s.SellerName,
                    SellerAgeDto = s.SellerAge,
                    libraryDtos = new LibraryDtoPost
                    {
                        LibraryNameDto = s.Library.LibraryName,
                        LibraryAddressDto = s.Library.LibraryAddress, 
                    },
                    bookDtos = s.Library.Books.Select(g => new BookCategoryDto
                    {
                        BookPriceDto = g.BookPrice,
                        BookDescriptionDto = g.BookDescription,
                        BookTitleDto = g.BookTitle,
                        categoryDto = g.Categories.Select(w => new CategoryDtoPost
                        {
                            CategoryNameDto = w.CategoryName,
                            
                        }).ToList() 
                    }).ToList(),
                })
                .ToList();
            return sellers;
        }

        public SellerDtoRelations GetSellerCategoryLibraryById(int id)
        {
            var seller = _context.sellers.Where(x => x.SellerId == id)
                .Include(l => l.Library)
                .ThenInclude(b => b.Books)
                .ThenInclude(c => c.Categories)
                .Select(s => new SellerDtoRelations
                {
                    SellerNameDto = s.SellerName,
                    SellerAgeDto = s.SellerAge,
                    libraryDtos = new LibraryDtoPost
                    {
                        LibraryNameDto = s.Library.LibraryName,
                        LibraryAddressDto = s.Library.LibraryAddress,
                    },
                    
                    bookDtos = s.Library.Books.Select(b => new BookCategoryDto
                    {
                        BookTitleDto = b.BookTitle,
                        BookDescriptionDto = b.BookDescription,
                        BookPriceDto = b.BookPrice,
                        categoryDto = b.Categories.Select(c => new CategoryDtoPost
                        {
                            CategoryNameDto =c.CategoryName,
                        }).ToList(),
                    }).ToList(),
                }).ToList()
                .FirstOrDefault();
            return seller;
        }

        public void UpdateSellerCategoryLibrary(int id, SellerAuthorDto sellerDto)
        {
            var seller = _context.sellers
                .Include(l => l.Library)
                .ThenInclude(b => b.Books)
                .ThenInclude(c => c.Categories)
                .FirstOrDefault(x => x.SellerId == id);

            seller.SellerName = sellerDto.SellerNameDto;
            seller.SellerAge = sellerDto.SellerAgeDto;
            seller.Library.LibraryName = sellerDto.libraryDtos.LibraryNameDto;
            seller.Library.LibraryAddress = sellerDto.libraryDtos.LibraryAddressDto;
            seller.Library.Books = sellerDto.bookDtos.Select(b => new Book
            {
                BookTitle = b.BookTitleDto,
                BookDescription = b.BookDescriptionDto,
                BookPrice = b.BookPriceDto,
                Author = new Author
                {
                    AuthorName = sellerDto.authorDto.AuthorNameDto,
                    AuthorBio = sellerDto.authorDto.AuthorBioDto,
                },
                Categories = sellerDto.categoryDtos.Select(c => new Category
                {
                    CategoryName = c.CategoryNameDto,
                }).ToList(),
            }).ToList();

            _context.sellers.Update(seller); 
            _context.SaveChanges();
        }
    }
}
