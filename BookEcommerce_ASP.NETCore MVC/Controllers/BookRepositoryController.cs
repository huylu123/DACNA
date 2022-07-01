using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Entities;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL.Repository.Interface;


namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookRepositoryController : Controller
    {
        IBookRepository _repository;
        public BookRepositoryController(IBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Book> getAllBooks()
        {
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> getDetailBook(int id)
        {
            Book book = _repository.getDetailBook(id);
            return Ok(book);
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] Book newbook)
        {
            _repository.addBook(newbook);
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }

        [HttpPut]
        public ActionResult UpdateBook([FromBody] Book newbook)
        {
            _repository.updateBook(newbook);
            return Ok(newbook);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            _repository.deleteBook(id);
            List<Book> books = _repository.getAllBook();
            return Ok(books);
        }
    }
}
