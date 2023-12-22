using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cinema.DAL
{
        public interface IRepository<T> where T : class
        {
            IQueryable<T> GetAll();
            T GetById(object id);
            void Insert(T entity);
            void Update(T entity);
            void Delete(object id);
            void Save();
        }

        public class GenericRepository<T> : IRepository<T> where T : class
        {
            private readonly CinemaContext _context;

            public GenericRepository(CinemaContext context)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }

            public IQueryable<T> GetAll()
            {
                return _context.Set<T>();
            }

            public T GetById(object id)
            {
                return _context.Set<T>().Find(id);
            }

            public void Insert(T entity)
            {
                _context.Set<T>().Add(entity);
            }

            public void Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }

            public void Delete(object id)
            {
                T entityToDelete = _context.Set<T>().Find(id);
                if (entityToDelete != null)
                    _context.Set<T>().Remove(entityToDelete);
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
}