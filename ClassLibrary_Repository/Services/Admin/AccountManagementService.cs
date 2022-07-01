using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Services.Admin
{
    public class AccountManagementService
    {
        AccountRepository _accountRepo = new AccountRepository();
        public bool checkLogin(string username, string password)
        {
            return _accountRepo.checkLogin(username, password);
        }
        public void AddAccount(Account newAccount)
        {
            _accountRepo.addAccount(newAccount);
        }

        public bool isExistUserName(string username)
        {
            List<Account> lst = _accountRepo.getAllAccount();
            foreach (Account account in lst)
            {
                string email_indb = account.Username;
                if (email_indb.Trim() == username)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
