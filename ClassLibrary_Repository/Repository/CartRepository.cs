using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary_RepositoryDLL.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly BookEcommerceContext _context;
        public CartRepository(BookEcommerceContext context) => _context = context;
        public void addCart(Cart newcart)
        {
            try
            {
                _context.Carts.Add(newcart);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteCart(int cartId)
        {
            Cart cart = _context.Carts.Find(cartId);
            if (cart != null)
            {
                try 
                { 
                    _context.Carts.Remove(cart);
                    _context.SaveChanges(); 
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
        public bool updateCart(Cart newcart)
        {
            Cart cart = _context.Carts.SingleOrDefault(cart => cart.Id.Equals(newcart.Id));
            if(cart != null)
            {
                try
                {
                    cart.AccountId = newcart.AccountId;
                    _context.Carts.Update(newcart);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
        public List<Cart> getAllCart()
        {
            List<Cart> carts = _context.Carts.ToList();
            return carts;
        }
        public Cart getDetailCart(int cartId)
        {
            Cart cart = _context.Carts.Find(cartId);
            return cart;
        }

        public bool searchCart(Cart keyword)
        {
            throw new NotImplementedException();
        }
    }
}
