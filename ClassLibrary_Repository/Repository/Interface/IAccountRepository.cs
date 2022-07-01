using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IAccountRepository
    {
      

        List<Account> searchAccount(string keyword);
        List<Account> getAllAccount();
        void addAccount(Account newaccount);
        bool updateAccount(Account newaccount);
        bool deleteAccount(int accountId);
        Account getAccount(int accountId);
        bool checkLogin(string username, string password);
    }
}
