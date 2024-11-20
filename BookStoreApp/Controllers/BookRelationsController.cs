using BookStoreApp.SellerDto.BookDto;
using BookStoreApp.Repositories.BookRelationsRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreApp.Dto.BookDto;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRelationsController : ControllerBase
    {
        private readonly IBookRelationsRepo _repo;

        public BookRelationsController(IBookRelationsRepo repo)
        {
            _repo = repo;
        }

        [HttpPost("AddBookCategoryLibrary")]
        public IActionResult AddBookCategoryLibrary(BookDtoRelations bookDto)
        {
            _repo.AddBookCategoryLibrary(bookDto);
            return Ok();
        }
        [HttpGet("GetAllBookCategoryLibraries")]
        public IActionResult GetAllBookCategoryLibraries()
        {
            var books = _repo.GetAllBookCategoryLibraries();
            return Ok(books);
        }
        [HttpGet("GetBookCategoryLibraryById")]
        public IActionResult GetBookCategoryLibraryById(int id)
        {
            var books = _repo.GetBookCategoryLibraryById(id);
            return Ok(books);
        }
        [HttpDelete("DeleteBookCategoryLibrary")]
        public IActionResult DeleteBookCategoryLibrary(int id)
        {
            _repo.DeleteBookCategoryLibrary(id);
            return Ok();    
        }

        [HttpPut("UpdateBookCategoryLibrary")]
        public IActionResult UpdateBookCategoryLibrary(int id, BookDtoRelations bookDto)
        {
            _repo.UpdateBookCategoryLibrary(id, bookDto);
            return Ok();    
        }

        [HttpPost("AddBookCategoryWithhidId")]
        public IActionResult AddBookCategoryWithhidId(BookCategDto bookDto)
        {
            _repo.AddBookCategoryWithhidId(bookDto);
            return Ok();
        }
    }
}
