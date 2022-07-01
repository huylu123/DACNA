using Microsoft.AspNetCore.Mvc;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Entities;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountRepositoryController : Controller
    {
        IAccountRepository _repository;

        public AccountRepositoryController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<Account> GetAllAccount()
        {
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            Account account = _repository.getAccount(id);
            return Ok(account);
        }

        [HttpPost]
        public ActionResult AddAccount([FromBody] Account newaccount)
        {
            _repository.addAccount(newaccount);
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }

        [HttpPut]
        public ActionResult UpdateAccount([FromBody] Account newaccount)
        {
            _repository.updateAccount(newaccount);
            return Ok(newaccount);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAccount(int id)
        {
            _repository.deleteAccount(id);
            List<Account> accounts = _repository.getAllAccount();
            return Ok(accounts);
        }
    }
}
