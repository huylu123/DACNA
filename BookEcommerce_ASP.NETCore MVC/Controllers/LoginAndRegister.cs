using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Entities;
using System.Collections.Generic;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
  

    public class LoginAndRegister : Controller
    {
        BookEcommerceContext _ctx = new BookEcommerceContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account sp)
        {

            _ctx.Accounts.Add(sp);
            _ctx.SaveChanges();
            return RedirectToAction("/Views/LoginAndRegister/Login");
        }
        [HttpPost]
        public ActionResult Authen(Account cus)
        {
            var check = _ctx.Accounts.Where(s => s.Username.Equals(cus.Username)
            && s.Password.Equals(cus.Password)).FirstOrDefault();
            if (check == null)
            {
                cus.LoginErrorMessage = "Error Email or Password! Try Again!!!";
                return View("Login", cus);
            }
            else
            {              
                return RedirectToAction("Index", "Home");
            }
            // return View();
        }
       
        public ActionResult Logout()
        {
           
            return RedirectToAction("Login", "Account");
        }

      
    }
}
