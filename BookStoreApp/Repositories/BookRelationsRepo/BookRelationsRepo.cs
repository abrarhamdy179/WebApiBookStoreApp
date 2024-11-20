using BookStoreApp.Data;
using BookStoreApp.SellerDto.BookDto;
using BookStoreApp.SellerDto.CategoryDto;
using BookStoreApp.SellerDto.LibraryDto;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Dto.CategoryDto;
using BookStoreApp.Dto.BookDto;
using System.Linq;

namespace BookStoreApp.Repositories.BookRelationsRepo
{
    public class BookRelationsDto : IBookRelationsRepo
    {
        private readonly ApplicationDbContext _context;
        public BookRelationsDto(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBookCategoryLibrary(BookDtoRelations bookDto)
        {
            Book book = new Book
            {
                BookTitle = bookDto.BookTitleDto,
                BookDescription = bookDto.BookDescriptionDto,
                BookPrice = bookDto.BookPriceDto,
                Categories = bookDto.categoryDtos
                .Select(i => new Category
                {
                    CategoryName = i.CategoryNameDto,
                }).ToList(),
                libraries = bookDto.libraryDtos
                .Select(x => new Library
                {
                    LibraryName = x.LibraryNameDto,
                    LibraryAddress = x.LibraryAddressDto,
                    Seller = new Seller
                    {
                        SellerName = x.SellerDto.SellerNameDto,
                        SellerAge = x.SellerDto.SellerAgeDto,
                    }
                }).ToList(),
                Author = new Author
                {
                    AuthorName = bookDto.authorDto.AuthorNameDto,
                    AuthorBio = bookDto.authorDto.AuthorBioDto,
                }
            };
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public List<BookDtoRelations> GetAllBookCategoryLibraries()
        {
            var books = _context.books
                .Include(x => x.Categories)
                .Include(a => a.Author)
                .Include(x => x.libraries)
                .ThenInclude(s => s.Seller)
                .Select(b => new BookDtoRelations
                {
                    BookTitleDto = b.BookTitle,
                    BookDescriptionDto = b.BookDescription,
                    BookPriceDto = b.BookPrice,
                    categoryDtos = b.Categories.Select(c => new CategoryDtoPost
                    {
                        CategoryNameDto = c.CategoryName,
                    }).ToList(),
                    libraryDtos = b.libraries.Select(l => new SellerLibraryDto
                    {
                        LibraryNameDto = l.LibraryName,
                        LibraryAddressDto = l.LibraryAddress,
                        SellerDto = new SellerDto.SellerDto.SellerDtoPost
                        {
                            SellerNameDto = l.Seller.SellerName,
                            SellerAgeDto = l.Seller.SellerAge,
                        }

                    }).ToList(),
                    authorDto = new  SellerDto.AuthorDto.AuthorDtoPost
                    {
                        AuthorNameDto = b.Author.AuthorName,
                        AuthorBioDto = b.Author.AuthorBio,
                    }
                })
                .ToList();
            return books;
        }

        public BookDtoRelations GetBookCategoryLibraryById(int id)
        {
            var books = _context.books.Where(b => b.BookId == id)
                .Include(x => x.Categories)
                .Include(a => a.Author)
                .Include(x => x.libraries)
                .ThenInclude(s => s.Seller)
                .Select(b => new BookDtoRelations
                {
                    BookTitleDto = b.BookTitle,
                    BookDescriptionDto = b.BookDescription,
                    BookPriceDto = b.BookPrice,

                    categoryDtos = b.Categories.Select(c => new CategoryDtoPost
                    {
                        CategoryNameDto = c.CategoryName,
                    }).ToList(),
                    libraryDtos = b.libraries.Select(l => new SellerLibraryDto
                    {
                        LibraryNameDto = l.LibraryName,
                        LibraryAddressDto = l.LibraryAddress,
                        SellerDto = new SellerDto.SellerDto.SellerDtoPost
                        {
                            SellerNameDto = l.Seller.SellerName,
                            SellerAgeDto = l.Seller.SellerAge,
                        }
                    }).ToList(),
                    authorDto = new SellerDto.AuthorDto.AuthorDtoPost
                    {
                        AuthorNameDto = b.Author.AuthorName,
                        AuthorBioDto = b.Author.AuthorBio,
                    }
                })
                .FirstOrDefault();
            return books;
        }

        public void DeleteBookCategoryLibrary(int id)
        {
            var book = _context.books.FirstOrDefault(b => b.BookId== id);
            _context.books.Remove(book);
            _context.SaveChanges();
        }

        public void UpdateBookCategoryLibrary(int id, BookDtoRelations bookDto)
        {
            var book = _context.books
                .Include(x => x.Categories)
                .Include(a => a.Author)
                .Include(x => x.libraries)
                .ThenInclude(s => s.Seller)
                .FirstOrDefault(x => x.BookId== id);
            book.BookTitle = bookDto.BookTitleDto;
            book.BookPrice = bookDto.BookPriceDto;

            book.Categories = bookDto.categoryDtos.Select(c => new Category
            {
                CategoryName = c.CategoryNameDto,
            }).ToList();

            book.libraries = bookDto.libraryDtos.Select(l => new Library
            {
                LibraryName = l.LibraryNameDto,
                LibraryAddress = l.LibraryAddressDto,
                Seller = new Seller
                {
                    SellerName = l.SellerDto.SellerNameDto,
                    SellerAge = l.SellerDto.SellerAgeDto,
                }
            }).ToList();

            book.Author = new Author
            {
                AuthorName = bookDto.authorDto.AuthorNameDto,
                AuthorBio = bookDto.authorDto.AuthorBioDto,
            };

            _context.books.Update(book);
            _context.SaveChanges();

        }

        public void AddBookCategoryWithhidId(BookCategDto bookDto)
        {

            var categories = _context.categories
                .Where(x => bookDto.categoryDtos
                .Select(i => i.CategoryIdDto).ToList()
                .Contains(x.CategoryId)).ToList();   

            Book book = new Book
            {
                BookTitle = bookDto.BookTitleDto,
                BookDescription = bookDto.BookDescriptionDto,
                BookPrice = bookDto.BookPriceDto,
                Categories = categories,
                Author = new Author
                {
                    AuthorName =bookDto.authorDto.AuthorBioDto,
                    AuthorBio = bookDto.authorDto.AuthorBioDto,
                }
            };
            _context.books.Add(book);
            _context.SaveChanges();
        }
        
    }
}
