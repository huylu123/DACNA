using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookEcommerceContext _context;
        public AccountRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public AccountRepository()
        {
            _context = new BookEcommerceContext();
        }

        public void addAccount(Account newaccount)
        {
            try
            {
                _context.Accounts.Add(newaccount);
                newaccount.RoleId = 1;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool checkLogin(string username, string password)
        {
            var inputData = from destination in _context.Accounts where destination.Username == username && destination.Password == password && destination.RoleId == 1
                            select destination;
            if (inputData.Any())
            {
                return true;
            }
            return false;
            //Or
            //Account user = _context.Accounts.SingleOrDefault(user => user.Username.Equals(username));
            //if (user != null)
            //{
            //    if(user.Password == password)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public bool deleteAccount(int accountId)
        {
            Account account = _context.Accounts.Find(accountId);
            if (account != null)
            {
                try
                {
                    _context.Accounts.Remove(account);
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

        public Account getAccount(int accountId)
        {
            Account account = _context.Accounts.Find(accountId);
            return account;
        }

        public List<Account> getAllAccount()
        {
            List<Account> accounts = _context.Accounts.ToList();
            return accounts;
        }

        public List<Account> searchAccount(string keyword)
        {
            List<Account> accounts = _context.Accounts.Where(a => a.Fullname == keyword).ToList();
            return accounts;
        }

        public bool updateAccount(Account newaccount)
        {
            Account account = _context.Accounts.SingleOrDefault(account => account.Id.Equals(newaccount.Id));
            if (account != null)
            {
                try
                {
                    account.Address = newaccount.Address;
                    account.RoleId = newaccount.RoleId;
                    account.Fullname = newaccount.Fullname;
                    account.Password = newaccount.Password;
                    account.Phone = newaccount.Phone;
                    _context.Accounts.Update(newaccount);
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
        public List<Account> selectByAccountId(int cateId)
        {
            List<Account> Accounts = _context.Accounts.Where(b => b.Id == cateId).ToList();
            return Accounts;
        }
    }
}
