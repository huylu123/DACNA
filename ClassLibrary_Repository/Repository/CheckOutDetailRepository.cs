using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using ClassLibrary_RepositoryDLL.Services;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ClassLibrary_RepositoryDLL.Repository
{
    internal class CheckOutDetailRepository : ICheckOutDetailRepository
    {
        private readonly string _connectionString;
        public CheckOutDetailRepository (IOptions<AppDbConnection> config)
        {
            _connectionString = config.Value.ConnectionString;

        }
        public Task<IEnumerable<CheckoutDetail>> GetCheckoutDetails()
        {
            using(IDbConnection db = new SqlConnection (_connectionString))
            {
                return db.QueryAsync<CheckoutDetail>("select Id, BookId, Quantity, Total from CheckoutDetail", commandType: CommandType.Text);
            }
        }
    }
}
