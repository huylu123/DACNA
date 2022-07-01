using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookEcommerceContext _context;
        public AuthorRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public AuthorRepository()
        {
            _context = new BookEcommerceContext();
        }

        public void addAuthor(Author newauthor)
        {
            try
            {
                _context.Authors.Add(newauthor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool deleteAuthor(int authorId)
        {
            Author author = _context.Authors.Find(authorId);
            if (author != null)
            {
                try
                {
                    _context.Authors.Remove(author);
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

        public List<Author> getAllAuthor()
        {
            List<Author> authors = _context.Authors.ToList();
            return authors;
        }

        public Author getAuthor(int authorId)
        {
            Author author = _context.Authors.Find(authorId);
            return author;
        }
        public List<Author> searchAuthor(string keyword)
        {
            List<Author> authors = _context.Authors.Where(a => a.Authorname.Contains(keyword)).ToList();
            return authors;
        }

        public bool updateAuthor(Author newauthor)
        {
            Author author = _context.Authors.SingleOrDefault(author => author.Id.Equals(newauthor.Id));
            if (author != null)
            {
                try
                {
                    author.Authorname = newauthor.Authorname;
                    //_context.Authors.Update(newauthor);
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
