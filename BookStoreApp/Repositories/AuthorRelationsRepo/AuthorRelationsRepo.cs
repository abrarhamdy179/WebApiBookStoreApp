using BookStoreApp.Data;
using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;
using BookStoreApp.SellerDto.SellerDto;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repositories.AuthorRelationsRepo
{
    public class AuthorRelationsRepo : IAuthorRelationsRepo
    {
        private readonly ApplicationDbContext _context;

        public AuthorRelationsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthorBookCategory(AuthorDtoRelations authorDto)
        {
            Author author = new Author
            {
                AuthorName = authorDto.AuthorNameDto,
                AuthorBio = authorDto.AuthorBioDto, 

                Books = authorDto.bookDtos
                .Select(i => new Book
                {
                    BookTitle = i.BookTitleDto,
                    BookDescription = i.BookDescriptionDto,
                    BookPrice = i.BookPriceDto,

                    Categories = authorDto.categoryDtos
                    .Select(c => new Category
                    {
                        CategoryName = c.CategoryNameDto,
                    }).ToList(),

                    libraries = authorDto.libraryDtos
                    .Select(l => new Library
                    {
                        LibraryName = l.LibraryNameDto,
                        LibraryAddress = l.LibraryAddressDto,
                        Seller  = new Seller
                        {
                            SellerName = l.SellerDto.SellerNameDto,
                            SellerAge = l.SellerDto.SellerAgeDto,
                        }
                    }).ToList(),
                    
                }).ToList(),
            };

            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthorBookCategory(int id)
        {
            var author = _context.authors.FirstOrDefault(a => a.AuthorId == id);
            _context.authors.Remove(author);
            _context.SaveChanges();
        }

        public List<AuthorDtoRelations> GetAllAuthorBookCategory()
        {
            var Authors = _context.authors
                .Include(i => i.Books)
                .ThenInclude(l => l.libraries)
                .ThenInclude(s => s.Seller)
                .Include(i => i.Books)
                .ThenInclude(c => c.Categories)
                .Select(a => new AuthorDtoRelations
                {
                    AuthorNameDto = a.AuthorName,
                    AuthorBioDto  = a.AuthorBio,
                    bookDtos = a.Books.Select(b => new SellerDto.BookDto.BookCategoryDto
                    {
                        BookTitleDto = b.BookTitle,
                        BookDescriptionDto = b.BookDescription,
                        BookPriceDto = b.BookPrice,
                    }).ToList(),

                    categoryDtos = a.Books
                    .SelectMany(x => x.Categories)
                    .Select(c => new CategoryDtoPost
                    {
                        CategoryNameDto = c.CategoryName,
                    }).ToList(),

                    libraryDtos = a.Books
                    .SelectMany(x => x.libraries)
                    .Select(l => new SellerLibraryDto
                    {
                        LibraryNameDto = l.LibraryName,
                        LibraryAddressDto = l.LibraryAddress,
                        SellerDto = new SellerDto.SellerDto.SellerDtoPost
                        {
                            SellerNameDto = l.Seller.SellerName,
                            SellerAgeDto = l.Seller.SellerAge,
                        }
                       
                    }).ToList(),
                })
                .ToList();
            return Authors;
        }

        public AuthorDtoRelations GetAuthorBookCategoryById(int id)
        {
            var author = _context.authors
                .Where(a => a.AuthorId == id)
                .Include(i => i.Books)
                .ThenInclude(l => l.libraries)
                .ThenInclude(s => s.Seller)
                .Include(i => i.Books)
                .ThenInclude(c => c.Categories)
                .Select(a => new AuthorDtoRelations
                {
                    AuthorNameDto = a.AuthorName,
                    AuthorBioDto = a.AuthorBio,
                    bookDtos = a.Books.Select(b => new SellerDto.BookDto.BookCategoryDto
                    {
                        BookTitleDto = b.BookTitle,
                        BookDescriptionDto = b.BookDescription,
                        BookPriceDto = b.BookPrice,
                    }).ToList(),

                    categoryDtos = a.Books
                    .SelectMany(x => x.Categories)
                    .Select(c => new CategoryDtoPost
                    {
                        CategoryNameDto = c.CategoryName,
                    }).ToList(),

                    libraryDtos = a.Books
                    .SelectMany(x => x.libraries)
                    .Select(l => new SellerLibraryDto
                    {
                        LibraryNameDto = l.LibraryName,
                        LibraryAddressDto = l.LibraryAddress,
                        SellerDto = new SellerDto.SellerDto.SellerDtoPost
                        {
                            SellerNameDto = l.Seller.SellerName,
                            SellerAgeDto = l.Seller.SellerAge,
                        }

                    }).ToList(),
                }).FirstOrDefault();
            return author;
        }

        public void UpdateAuthorBookCategory (int id, AuthorDtoRelations authorDto)
        {
            var author = _context.authors
                .Include(i => i.Books)
                .ThenInclude(l => l.libraries)
                .ThenInclude(s => s.Seller)
                .Include(i => i.Books)
                .ThenInclude(c => c.Categories)
                .FirstOrDefault(a => a.AuthorId == id);

            author.AuthorName = authorDto.AuthorNameDto;
            author.AuthorBio = authorDto.AuthorBioDto;

            author.Books = authorDto.bookDtos.Select(b => new Book
            {
               BookTitle = b.BookTitleDto,
               BookDescription = b.BookDescriptionDto,
               BookPrice = b.BookPriceDto,
               libraries = authorDto.libraryDtos.Select(l => new Library
               {
                   LibraryName = l.LibraryNameDto,
                   LibraryAddress = l.LibraryAddressDto,
                   Seller = new Seller
                   {
                       SellerName = l.SellerDto.SellerNameDto,
                       SellerAge = l.SellerDto.SellerAgeDto,
                   }
               }).ToList(),
               Categories = authorDto.categoryDtos.Select(c => new Category
               {
                   CategoryName = c.CategoryNameDto,
               }).ToList(),

            }).ToList();

            _context.authors.Update(author);
            _context.SaveChanges();
        }
    }
}