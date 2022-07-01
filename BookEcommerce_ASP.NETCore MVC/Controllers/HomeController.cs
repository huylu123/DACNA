using AutoMapper;
using BookEcommerce_ASP.NETCore_MVC.Models;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookEcommerce_ASP.NETCore_MVC.Controllers;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookrepo;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IBookRepository bookrepo)
        {
            _logger = logger;
            _bookrepo = bookrepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult ProductDetail(int Id)
        {
            Book product = _bookrepo.getDetailBook(Id);
            return View(product);
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}