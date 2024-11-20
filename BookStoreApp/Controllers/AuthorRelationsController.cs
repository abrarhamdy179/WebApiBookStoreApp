using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.Repositories.AuthorRelationsRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorRelationsController : ControllerBase
    {
        private readonly IAuthorRelationsRepo _repo;

        public AuthorRelationsController(IAuthorRelationsRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("AddAuthorBookCategory")]
        public IActionResult AddAuthorBookCategory (AuthorDtoRelations authorDto)
        {
            _repo.AddAuthorBookCategory(authorDto);
            return Ok();
        }
        [HttpGet("GetAllAuthorBookCategory")]
        public IActionResult GetAllAuthorBookCategory()
        {
            var result = _repo.GetAllAuthorBookCategory();
            return Ok(result);
        }
        [HttpGet("GetAuthorBookCategoryById")]
        public IActionResult GetAuthorBookCategoryById(int id)
        {
            var result = _repo.GetAuthorBookCategoryById(id);
            return Ok(result);
        }
        [HttpPut("UpdateAuthorBookCategory")]
        public IActionResult UpdateAuthorBookCategory(int id, AuthorDtoRelations authorDto)
        {

            _repo.UpdateAuthorBookCategory(id, authorDto);
            return Ok();
        }
        [HttpDelete("DeleteAuthorBookCategory")]
        public IActionResult DeleteAuthorBookCategory(int id)
        {
            _repo.DeleteAuthorBookCategory(id);
            return Ok();    
        }
    }
}
