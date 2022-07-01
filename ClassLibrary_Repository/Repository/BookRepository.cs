using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookEcommerceContext _context;
        public BookRepository(BookEcommerceContext context)
        {
            _context = context;
        }
        public BookRepository()
        {
            _context = new BookEcommerceContext();
        }
        public List<Book> getAllBook()
        {
            List<Book> books = _context.Books.ToList();
            return books;
        }

        public Book getDetailBook(int bookId)
        {
            Book book = _context.Books.Find(bookId);
            return book;
        }
        public void addBook(Book newbook)
        {
            try
            {
                _context.Books.Add(newbook);
                _context.SaveChanges();
            }
            catch(Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message);
            }
        }
        public bool updateBook(Book newbook)
        {
            Book book = _context.Books.SingleOrDefault(book => book.Id.Equals(newbook.Id));
            if (book != null)
            {
                try
                {
                    book.Bookname = newbook.Bookname;
                    book.AuthorId = newbook.AuthorId;
                    book.PublisherId = newbook.PublisherId;
                    book.Price = newbook.Price;
                    book.Image = newbook.Image;
                    book.Description = newbook.Description;
                    book.CategoryId = newbook.CategoryId;
                    book.StorageQuantity = newbook.StorageQuantity;

                    //_context.Books.Update(newbook);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }

        public bool deleteBook(int bookId)
        {
            //Book book = _context.Books.Find(bookId);
            Book book = _context.Books.SingleOrDefault(book => book.Id == bookId);
            if (book != null)
            {
                try
                {
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }

        public List<Book> searchBook(string keyword)
        {
            List<Book> books = _context.Books.Where(book => book.Bookname.Contains(keyword)).ToList();
            return books;
        }

        public bool updateImage(Book newbook)
        {
            Book book = _context.Books.SingleOrDefault(book => book.Id.Equals(newbook.Id));
            if (book != null)
            {
                try
                {
                    book.Image = newbook.Image;
                    //_context.Books.Update(newbook);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception.Message);
                }
            }
            return false;
        }

        public List<Book> selectByAuthorId(int authorId)
        {
            List<Book> books = _context.Books.Where(b => b.AuthorId == authorId).ToList();
            return books;
        }

        public List<Book> selectByCateId(int cateId)
        {
            List<Book> books = _context.Books.Where(b => b.CategoryId == cateId).ToList();
            return books;
        }

        public List<Book> selectByPubId(int pubId)
        {
            List<Book> books = _context.Books.Where(b => b.PublisherId == pubId).ToList();
            return books;
        }
    }
}
