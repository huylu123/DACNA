using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IAuthorRepository
    {
        List<Author> searchAuthor(string keyword);
        List<Author> getAllAuthor();
        void addAuthor(Author newauthor);
        bool updateAuthor(Author newauthor);
        bool deleteAuthor(int authorId);
        Author getAuthor(int authorId);
    }
}
