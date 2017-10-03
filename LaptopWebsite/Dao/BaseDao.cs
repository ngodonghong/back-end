using LaptopWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopWebsite.Dao
{
    public interface BaseDao<T, Int16> : IDisposable where T : class
    {
        IEnumerable<T> get();
        T getById(Int16 id);
        void insert(T entity);
        void delete(Int16 id);
        void update(T entity);
        void save();
        PageResult<T> PageView(IQueryable<T> query, int page, int pageSize);

    }
}