using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Models;

namespace ClassLibrary_RepositoryDLL.Services
{
    public interface IAuthorService
    {
        List<Author> getAllAuthor();
    }
}