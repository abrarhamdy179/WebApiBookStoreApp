using BookStoreApp.Data;
using BookStoreApp.SellerDto.AuthorDto;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repositories.AuthorRepository
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDbContext _context;
        public AuthorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorDtoPost authorDtoPost)
        {

            var x = _context.authors.FirstOrDefault(i=>i.AuthorName == authorDtoPost.AuthorNameDto);
            if(x != null)
            {
                throw new Exception($"The author Arleady Exists :( {x}");
            }

            Author author = new Author
            {
                AuthorName = authorDtoPost.AuthorNameDto,
                AuthorBio = authorDtoPost.AuthorBioDto,
            };
            _context.authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.authors.FirstOrDefault(a => a.AuthorId == id);
            _context.authors.Remove(author);
            _context.SaveChanges(); 
        }

        public List<AuthorDtoPost> GetAllAuthors()
        {
           var authors = _context.authors.Select(a => new AuthorDtoPost
           {
               AuthorNameDto = a.AuthorName,
               AuthorBioDto = a.AuthorBio,
           })
                .ToList();
            return authors;
        }

        public AuthorDtoPost GetAuthor(int id)
        {
            var authors = _context.authors.Where(x => x.AuthorId == id)
                .Select(a => new AuthorDtoPost
                {
                    AuthorNameDto = a.AuthorName,
                    AuthorBioDto = a.AuthorBio,
                }).FirstOrDefault();
            return authors;
        }

        public void UpdateAuthor(int id, AuthorDtoPost authorDtoPost)
        {
            var author = _context.authors.FirstOrDefault(a => a.AuthorId == id);
            author.AuthorName = authorDtoPost.AuthorNameDto;
            author.AuthorBio = authorDtoPost.AuthorBioDto;
            _context.authors.Update(author);
            _context.SaveChanges();
        }
    }
}
