using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface ICartRepository
    {
        void addCart(Cart newcart);
        bool updateCart(Cart newcart);
        bool deleteCart(int cartId);
        List<Cart> getAllCart();
        Cart getDetailCart(int cartId);
    }
}
