using BookEcommerce_ASP.NETCore_MVC.Entities;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace BookEcommerce_ASP.NETCore_MVC
{
    public class RepositoryCheckOut : IRepositoryCheckOut
    {
        private readonly string _connectionString;

        public RepositoryCheckOut(IOptions<AppDbConnection> config)
        {
            _connectionString = config.Value.ConnectionString;
        }

        public async Task<IEnumerable<Checkout>> GetCheckouts()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<Checkout>("select AccountId, CreateDate, ShippingfeeId from Checkout", commandType:CommandType.Text);
            }
        }
    }
}
