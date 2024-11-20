using BookStoreApp.Dto.SellerDto;
using BookStoreApp.Repositories.SellerRelationsRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRelationsRepo _repo;

        public SellerController(ISellerRelationsRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllSellerCategoryLibrary")]
        public IActionResult GetAllSellerCategoryLibrary()
        {
           var sellers = _repo.GetAllSellerCategoryLibrary();
            return Ok(sellers);
        }

        [HttpGet("GetSellerCategoryLibraryById")]
        public IActionResult GetSellerCategoryLibraryById(int id)
        {
            var sellers = _repo.GetSellerCategoryLibraryById(id);
            return Ok(sellers);
        }
        [HttpPost("AddSellerCategoryLibrary")]
        public IActionResult AddSellerCategoryLibrary(SellerAuthorDto sellerDto)
        {
            _repo.AddSellerCategoryLibrary(sellerDto);
            return Ok();
        }
        [HttpDelete("DeleteSellerCategoryLibrary")]
        public IActionResult DeleteSellerCategoryLibrary(int id)
        { 
            _repo.DeleteSellerCategoryLibrary(id);
            return Ok();    
        }

        [HttpPut("UpdateSellerCategoryLibrary")]
        public IActionResult UpdateSellerCategoryLibrary(int id, SellerAuthorDto sellerDto)
        {
            _repo.UpdateSellerCategoryLibrary(id, sellerDto);
            return Ok();
        }
    }
}