using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookEcommerceContext _context;
        public RoleRepository(BookEcommerceContext context) => _context = context;
        public void addRole(Role newrole)
        {
            try
            {
                _context.Roles.Add(newrole);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteRole(int roleId)
        {
            Role role = _context.Roles.Find(roleId);
            if (role != null)
            {
                try
                {
                    _context.Roles.Remove(role);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public List<Role> getAllRole()
        {
            List<Role> roles = _context.Roles.ToList();
            return roles;
        }

        public Role getRole(int roleId)
        {
            Role role = _context.Roles.Find(roleId);
            return role;
        }

        public bool updateRole(Role newrole)
        {
            Role role = _context.Roles.SingleOrDefault(role => role.Id.Equals(newrole.Id));
            if (role != null)
            {
                try
                {
                    role.Rolename = newrole.Rolename;
                    _context.Roles.Update(role);
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
    }
}
