using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Services.Admin.Interface
{
    public interface IAccountManagementService
    {
        bool checkLogin(string username, string password);
    }
}
