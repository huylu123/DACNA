using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{

    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IBookRepository _repo;

        public ProductController(ILogger<ProductController> logger, IBookRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //CART
        //  [Route("addcart/{id}")]
        public IActionResult AddToCart(int id)
        {
            Book book = _repo.getDetailBook(id);
            if (book == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }
            var cart = getCartItems();
            var cartItem = cart.Find(p => p.Book.Id == id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem()
                {
                    Quantity = 1,
                    Book = book
                });
            }
            SaveCart(cart);
            return RedirectToAction(nameof(Cart));
        }
        [Route("removecart/{id}", Name = "RemoveCartItem")]
        public IActionResult RemoveCartItem([FromRoute] int id)
        {
            var cart = getCartItems();
            var cartItem = cart.Find(p => p.BookId == id);
            if (cartItem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cart.Remove(cartItem);
            }

            SaveCart(cart);
            return RedirectToAction(nameof(Cart));
        }


        //[Route("/updatecart", Name = "UpdateCart")]
        [HttpPost]
        public IActionResult UpdateCart()
        {

            int id = int.Parse(Request.Form["BookId"].ToString());
            int quantity = int.Parse(Request.Form["Quantity"].ToString());

            // Cập nhật Cart thay đổi số lượng quantity ...
            List<CartItem> cart = getCartItems();
            CartItem cartItem = cart.Find(p => p.Book.Id == id);

            if (cartItem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartItem.Quantity = quantity;
            }
            SaveCart(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return RedirectToAction(nameof(Cart));
        }

        [Route("/cart", Name = "Cart")]
        public IActionResult Cart()
        {
            return View(getCartItems());
        }
        [Route("/checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Checkout(IFormCollection fc)
        //{
        //    List<CartItem> cartItems = (List <CartItem> ISession["cart"]);
        //    return View();
        //}

        //SESSION
        // JSON key 
        public const string KEY = "cart";

        public int? Quantity { get; private set; }

        List<CartItem> getCartItems()
        {
            var session = HttpContext.Session;
            string jsonCart = session.GetString(KEY);
            if (jsonCart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsonCart);
            }
            return new List<CartItem>();
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(KEY);
        }
        void SaveCart(List<CartItem> cartItems)
        {
            var session = HttpContext.Session;
            string jsonCart = JsonConvert.SerializeObject(cartItems);
            session.SetString(KEY, jsonCart);
        }
    }
}