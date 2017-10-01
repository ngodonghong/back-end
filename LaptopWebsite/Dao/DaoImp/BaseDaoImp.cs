using LaptopWebsite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LaptopWebsite.Dao.DaoImp
{
    public class BaseDaoImp<T, Int16> : BaseDao<T, Int16>, IDisposable where T : class
    {
        private Boolean disposed;
        private LaptopDbContext context;

        public BaseDaoImp()
        {
            this.context = DataBaseFactory.context;
        }

        public void delete(Int16 id)
        {
            T instance = context.Set<T>().Find();
            this.context.Set<T>().Remove(instance);
        }

        public virtual void Dispose(Boolean disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public IEnumerable<T> get()
        {
            return this.context.Set<T>().ToList();
        }

        public T getById(Int16 id)
        {
            return this.context.Set<T>().Find(id);
        }

        public void insert(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void save()
        {
            this.context.SaveChanges();
        }

        public void update(T entity)
        {
            this.context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}