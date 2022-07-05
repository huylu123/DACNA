using BookEcommerce_ASP.NETCore_MVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookEcommerce_ASP.NETCore_MVC
{
    public interface ICheckoutRepository
    {
        Task<IEnumerable<Checkout>> GetCheckout();
    }
}
