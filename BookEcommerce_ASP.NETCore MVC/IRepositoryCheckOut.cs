using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using BookEcommerce_ASP.NETCore_MVC.Entities;

namespace BookEcommerce_ASP.NETCore_MVC
{
    public interface IRepositoryCheckOut
    {
        Task<IEnumerable<Checkout>> GetCheckouts();
    }
}
