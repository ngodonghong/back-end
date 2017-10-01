using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace LaptopWebsite.Dao.IDao
{
    public interface CategoryDao : IDisposable
    {
        IEnumerable<Category> GetCategory();
        Category GetCategoryById(Int16 categoryId);
        void InsertCategory(Category category);
        void DeleteCategory(Int16 CategoryId);
        void UpdateCategory(Category category);
        void Save();
        void Dispose();
    }
}