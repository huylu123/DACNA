using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Entities;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
   [Route("api/authors")]
   [ApiController]
    public class AuthorRepositoryController : Controller
    {
        IAuthorRepository _repository;

        public AuthorRepositoryController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Author> getAllAuthor()
        {
            List<Author> authors = _repository.getAllAuthor();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> getAuthor(int id)
        {
            Author book = _repository.getAuthor(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] Author newauthor)
        {
            _repository.addAuthor(newauthor);
            List<Author> authors = _repository.getAllAuthor();
            return Ok(authors);
        }

        [HttpPut]
        public ActionResult UpdateAuthor([FromBody] Author newauthor)
        {
            _repository.updateAuthor(newauthor);
            return Ok(newauthor);
        }

        [HttpDelete("{id}")]
        public ActionResult<Author> DeleteAuthor(int id)
        {
            _repository.deleteAuthor(id);
            List<Author> authors = _repository.getAllAuthor();
            return Ok(authors);
        }
    }
}
