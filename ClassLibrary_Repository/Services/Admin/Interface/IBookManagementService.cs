using ClassLibrary_RepositoryDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Services.Admin.Interface
{
    interface IBookManagementService
    {
        void addBook(Book newbook);
        bool updateBook(Book newbook);
        bool delBook(int bookId);
        bool UpdateImage(Book newbook);
        List<Book> SelectByKeyword(string keyword);
        List<Book> GetDetailsByAuthorId(int authorId);
        List<Book> GetDetailsByCateId(int cateId);
        List<Book> GetDetailsByPubId(int pubId);
        Book viewDetailBook(int bookId);
        Author viewAuthor(int authorId);
        void addAuthor(Author newauthor);
        bool updateAuthor(Author newauthor);
        bool delAuthor(int authorId);
        Category viewCategory(int cateId);
        Publisher viewPublisher(int pubId);
        void addCate(Category newcate);
        bool updateCate(Category newcate);
        bool delCate(int categoryId);
        List<Author> viewAllAuthor();
        List<Checkout> viewAllCheckOut();
        List<Publisher> viewAllPub();
        List<Category> viewAllCategory();
        void addPublisher(Publisher newpub);
        bool delPublisher(int pubId);
    }
}
