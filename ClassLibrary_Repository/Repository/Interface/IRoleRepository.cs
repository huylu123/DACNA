using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IRoleRepository
    {
        List<Role> getAllRole();
        void addRole (Role newrole);
        bool updateRole (Role newrole);
        bool deleteRole(int roleId);
        Role getRole(int roleId);
    }
}
