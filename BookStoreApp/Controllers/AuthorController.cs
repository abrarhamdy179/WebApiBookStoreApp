using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.Repositories.AuthorRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _repo;

        public AuthorController(IAuthorRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public IActionResult AddAuthor (AuthorDtoPost authorDtoPost)
        {
            _repo.AddAuthor(authorDtoPost);
            return Ok();
        }
        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors ()
        {
            var author = _repo.GetAllAuthors();
            return Ok(author);
        }

        [HttpGet("GetAuthor")]
        public IActionResult GetAuthor(int id)
        {
            var author = _repo.GetAuthor(id);
            return Ok(author);
        }

        [HttpPut("UpdateAuthor")]
        public IActionResult UpdateAuthor(int id, AuthorDtoPost authorDtoPost)
        {
            _repo.UpdateAuthor(id, authorDtoPost);
            return Ok();
        }
        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor (int id)
        {
            _repo.DeleteAuthor(id);
            return Ok();
        }
    }
}
