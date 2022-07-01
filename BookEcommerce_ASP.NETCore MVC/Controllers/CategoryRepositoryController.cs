using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Entities;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
   [Route("api/category")]
   [ApiController]
    public class CategoryRepositoryController : Controller
    {
        ICategoryRepository _repository;
        public CategoryRepositoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Category> GetAllCategory()
        {
            List<Category> categories = _repository.getAllCategory();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            Category category = _repository.getCategory(id);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] Category newcategory)
        {
            _repository.addCategory(newcategory);
            List<Category> authors = _repository.getAllCategory();
            return Ok(authors);
        }

        [HttpPut]
        public ActionResult UpdateCategory([FromBody] Category newcategory)
        {
            _repository.updateCategory(newcategory);
            return Ok(newcategory);
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            _repository.deleteCategory(id);
            List<Category> categories = _repository.getAllCategory();
            return Ok(categories);
        }
    }
}
