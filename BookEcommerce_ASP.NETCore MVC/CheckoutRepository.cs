using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEcommerce_ASP.NETCore_MVC.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;

namespace BookEcommerce_ASP.NETCore_MVC
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly string _connectionString;
        public CheckoutRepository(IOptions<AppDbConnection> config)
        {
            _connectionString = config.Value.ConnectionString;

        }
        public async Task<IEnumerable<Checkout>> GetCheckout()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Checkout>("select AccountId, CreateDate, ShippingfeeId from Checkout", commandType: CommandType.Text);
            }
        }
        private readonly BookEcommerceContext _context;
        public CheckoutRepository(BookEcommerceContext context) => _context = context;
        public CheckoutRepository()
        {
            _context = new BookEcommerceContext();
        }
    }
}
