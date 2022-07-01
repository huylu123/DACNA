using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary_RepositoryDLL.Entities;

namespace ClassLibrary_RepositoryDLL.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<Category> searchCate(string keyword);
        List<Category> getAllCategory();
        void addCategory(Category category);
        bool updateCategory(Category category);
        bool deleteCategory(int categoryId);
        Category getCategory(int categoryId);

        //Create Search by Name follow the name in the website
        //Category getCategoryByName(string productName);
    }
}
