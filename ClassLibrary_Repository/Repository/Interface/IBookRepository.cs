using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface IBookRepository
    {
        List<Book> searchBook(string keyword); 
        List<Book> getAllBook();
        void addBook(Book newbook);
        bool updateBook(Book newbook);
        bool deleteBook(int bookId);
        Book getDetailBook(int bookId);
        bool updateImage(Book newbook);
        List<Book> selectByAuthorId(int authorId);
        List<Book> selectByCateId(int cateId);
        List<Book> selectByPubId(int pubId);
    }
}
