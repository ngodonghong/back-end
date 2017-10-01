using LaptopWebsite.Dao.DaoImp;
using LaptopWebsite.Dao.IDao;
using LaptopWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace LaptopWebsite.Dao
{
    public class CategoryDaoImp : BaseDaoImp<Category, Int16>, CategoryDao, IDisposable
    {
        public CategoryDaoImp() : base()
        {

        }
        public void DeleteCategory(Int16 CategoryId)
        {
            base.delete(CategoryId);
        }

        public IEnumerable<Category> GetCategory()
        {
            return base.get();
        }

        public Category GetCategoryById(Int16 categoryId)
        {
            return base.getById(categoryId);
        }

        public void InsertCategory(Category category)
        {
            base.insert(category);
        }

        public void Save()
        {
            base.save();
        }

        public void UpdateCategory(Category category)
        {
            base.update(category);
        }

        public void dispose()
        {
            base.Dispose();
        }
    }
}